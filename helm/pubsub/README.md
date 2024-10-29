# Mon Projet Helm

## Description
Ce projet Helm déploie une application composée de plusieurs briques applicatives, incluant RabbitMQ, MSSQL, une API et une console. Il est conçu pour être déployé dans des environnements variés tels que développement, staging et production, avec une gestion des configurations contextuelles via des fichiers `values.yaml`.

## Structure du Projet

mon-chart/ ├── charts/ ├── templates/ │ ├── api.yaml │ ├── rabbitmq.yaml │ ├── mssql.yaml │ └── console.yaml ├── values.yaml ├── values-dev.yaml ├── values-prod.yaml └── Chart.yaml

markdown


## Prérequis
- **Helm** : Assurez-vous d'avoir installé Helm. Pour l'installer, suivez les instructions sur [le site officiel de Helm](https://helm.sh/docs/intro/install/).
- **Kubernetes** : Vous devez avoir accès à un cluster Kubernetes.

## Installation

### 1. Cloner le dépôt
```
git clone <URL_DU_DEPOT>
cd mon-chart
```

### 2. Packager le Chart (si nécessaire)

Si vous n'avez pas encore packagé le chart :

```
helm package mon-chart
```

### 3. Déployer l'application

Pour déployer l'application, utilisez la commande suivante, en spécifiant le fichier de valeurs approprié pour l'environnement :

#### Variables d'environnement
```
global:
  hostname: <app hostname>

mssql:
  mssql_pid: Developer

keyvault:
  userAssignedIdentityID: <keyvaultIdentityclientId>
  keyvaultName: <keyvaultName>>
  tenantId: <tenantId>
```

#### Environnement de Développement

```
helm install mon-application ./mon-chart -f values-dev.yaml`
```

#### Environnement de Production

```
helm install mon-application ./mon-chart -f values-prod.yaml
```

### 4. Surcharger des valeurs à l'installation

Vous pouvez également utiliser l'option --set pour ajuster des valeurs spécifiques :

```
helm install mon-application ./mon-chart --set image.tag="dev-latest" --set database.user="override-user"
```

### Gestion des Secrets

Pour gérer les informations sensibles, utilisez les secrets Kubernetes. Créez des secrets avant le déploiement ou intégrez-les dans le chart.
Exemple de création d'un secret

```
kubectl create secret generic database-secret --from-literal=password='votre_mot_de_passe'
```

### Mise à Jour et Désinstallation

Pour mettre à jour l'application, utilisez :

```
helm upgrade mon-application ./mon-chart -f values-prod.yaml
```

Pour désinstaller l'application :

```
helm uninstall mon-application
```

### Ressources

[Documentation de Helm](https://www.google.com/url?sa=t&source=web&rct=j&opi=89978449&url=https://helm.sh/fr/docs/&ved=2ahUKEwjDyZyU7bOJAxVadqQEHVKMLRUQFnoECBUQAQ&usg=AOvVaw09lanu-l9M3gledH9SUU4h)

[Documentation Kubernetes](https://kubernetes.io/docs/home/)

### Contribuer

Les contributions sont les bienvenues ! Veuillez ouvrir une issue ou soumettre une demande de tirage pour discuter des changements souhaités.
License

Ce projet est sous licence MIT. Voir le fichier LICENSE pour plus de détails.

### Personnalisation
N'hésite pas à modifier les sections en fonction de ton projet, en ajoutant des informations sur les dépendances, les commandes spécifiques, ou d'autres détails pertinents. Si tu as besoin d'ajouts spécifiques, fais-le moi savoir !