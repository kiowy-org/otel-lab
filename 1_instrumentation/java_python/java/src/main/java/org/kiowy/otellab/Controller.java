package org.kiowy.otellab;

import java.util.Random;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class Controller {

  private static final Logger LOGGER = LogManager.getLogger(Controller.class);

  private final Random random = new Random();

  @GetMapping("/ping")
  public String ping() throws InterruptedException {
    int sleepTime = random.nextInt(200);
    doWork(sleepTime);
    return "pong";
  }

  private void doWork(int sleepTime) throws InterruptedException {
      Thread.sleep(sleepTime);
      LOGGER.info("A sample log message !");
  }
}