FROM python:3

WORKDIR /app

RUN pip install "flask<3" "werkzeug<3"

ADD ./app.py .

CMD ["python", "app.py"]
