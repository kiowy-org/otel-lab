import logging
from flask import Flask, request, jsonify

logging.basicConfig(level=logging.INFO)

app = Flask(__name__)

@app.route("/")
def hello_world():
    print(request.args.get("param"))
    logging.info("Hello, World!")
    return "<p>Hello, World!</p>"

if __name__ == "__main__":
  app.run(port=8080, host="0.0.0.0")
