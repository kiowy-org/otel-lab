FROM python:3

WORKDIR /app

RUN pip install "flask<3" "werkzeug<3" "opentelemetry-distro" "opentelemetry-exporter-otlp"
RUN opentelemetry-bootstrap -a install
ADD ./app.py .

CMD ["python", "app.py"]
