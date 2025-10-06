# Démo OpenTelemetry

## Prérequis

- Docker
- Docker Compose v2.0.0+
- 6 Go de RAM

## Exécuter la démo

1. Cloner le dépôt officiel :
	```bash
	git clone https://github.com/open-telemetry/opentelemetry-demo.git
	cd opentelemetry-demo/
	```
2. Démarrer la démo :
	```bash
	make start
	```

## Accès aux interfaces

- Web store : http://localhost:8080/
- Grafana : http://localhost:8080/grafana/
- Load Generator UI : http://localhost:8080/loadgen/
- Jaeger UI : http://localhost:8080/jaeger/ui/

Pour plus d'options et de documentation :
https://opentelemetry.io/docs/demo/docker-deployment/

