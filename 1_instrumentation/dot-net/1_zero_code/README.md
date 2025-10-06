# Instrumentation Zero Code (.NET)

Objectif du TP : instrumenter l'application Minimal API (`src/`). Vous allez :

1. Construire et exécuter l'image "baseline" (sans instrumentation)
2. Construire et exécuter une image instrumentée automatiquement (zero code)
---
## 1. Pré‑requis

Uniquement :

- Docker (et éventuellement Docker Compose si vous voulez relier à un Collector existant)
- Connexion Internet (pour télécharger l'image .NET et l'agent OTel lors du build instrumenté)

Rien à installer côté hôte en dehors de Docker.

---
## 2. Arborescence

```
1_zero_code/
	Dockerfile                # Image .NET simple (baseline)
	Dockerfile.instrumented   # Image avec instrumentation automatique OTel
	src/Program.cs            # Application Minimal API
	src/src.csproj
```

Endpoint exposé : `GET /rolldice/{player?}` sur le port 8080.

---
## 3. Étape A – Image baseline (sans OTel)

Build :
```bash
docker build -t roll-dice:plain -f Dockerfile .
```

Run :
```bash
docker run --rm -p 8080:8080 --name roll-dice-plain roll-dice:plain
```

Dans un autre terminal (générer quelques requêtes) :
```bash
curl -w "\n" http://localhost:8080/rolldice
curl -w "\n" http://localhost:8080/rolldice/alice
```

---
## 4. Étape B – Image instrumentée

Adaptez le fichier `Dockerfile.instrumented` afin de réaliser l'instrumentation zero-code, en vous basand sur https://opentelemetry.io/docs/zero-code/dotnet/getting-started/#instrumentation

Build :
```bash
docker build -t roll-dice:otel -f Dockerfile.instrumented .
```

Run :
```bash
docker run --rm -p 8080:8080 --name roll-dice-otel roll-dice:otel
```

Dans un autre terminal :
```bash
curl -s http://localhost:8080/rolldice > /dev/null
curl -s http://localhost:8080/rolldice/bob > /dev/null
for i in $(seq 1 5); do curl -s http://localhost:8080/rolldice/alice > /dev/null; done
```

Qu'observez vous dans les logs du conteneur ?

---
## 5. Manipuler l'instrumentation

Ajouter des attributs de ressource :
```bash
-e OTEL_RESOURCE_ATTRIBUTES=deployment.environment=lab,team=demo
```

Exporter uniquement traces :
```bash
-e OTEL_TRACES_EXPORTER=otlp -e OTEL_METRICS_EXPORTER=none -e OTEL_LOGS_EXPORTER=none
```

---
## 6. Nettoyage

```bash
docker rm -f roll-dice-plain 2>/dev/null || true
docker rm -f roll-dice-otel 2>/dev/null || true
docker image rm roll-dice:plain roll-dice:otel 2>/dev/null || true
```
