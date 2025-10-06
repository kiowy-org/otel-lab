# Instrumentation manuelle (.NET)

Dans ce TP, vous allez ajouter de l'instrumentation manuelle à l'application fournie.
Le setup est composé de :

1. [`client`](Client) - console application that makes a HTTP GET request
   instrumented with OpenTelemetry .NET Automatic Instrumentation.
2. [`service`](Service) - simple HTTP server using SQL Server.
   The application additionally has manual instrumentation (traces, metrics, logs)
   on top of the automatic instrumentation.
3. `sqlserver` - [Microsoft SQL Server](https://hub.docker.com/_/microsoft-mssql-server)
   used by `service`
4. `otel-collector` - [OpenTelemetry Collector](https://opentelemetry.io/docs/collector/)
   which collects the telemetry send by `client` and `service`
5. `jaeger` - [Jaeger](https://www.jaegertracing.io/) as traces backend
6. `prometheus` - [Prometheus](https://prometheus.io/) as metrics backend
7. `loki` - [Grafana Loki](https://grafana.com/oss/loki/) as logs backend
8. `grafana` - [Grafana](https://grafana.com/oss/grafana/) as telemetry UI

## Exécuter l'environnement

```sh
# Au choix
make
# ou
docker compose up -d --build
```

Grafana est disponible à http://localhost:3000/ et les logs sont dans le dossier `log`

Pour éteindre le setup :

```sh
make clean
# ou
docker compose down --remove-orphans
rm -rf log
```

## Exercice

- Ajoutez vos propres traces avec des attributs personalisés, dans le code

- Ajoutez votre propre métrique