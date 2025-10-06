FROM eclipse-temurin:18-jdk as builder

ADD ./ . 

RUN ./gradlew bootJar

FROM eclipse-temurin:18-jre

COPY --from=builder build/libs/otellab-0.0.1-SNAPSHOT.jar /app.jar
# OTEL_AGENT

ENTRYPOINT java -jar /app.jar
