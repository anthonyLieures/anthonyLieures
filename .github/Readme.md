# Documentation du CI

## Run l'image de build 

Entrez dans le conteneur :

```bash 
docker run -it --rm gableroux/unity3d:2019.4.11f1
```

Une fois à l'intérieur direction le dossier de l'Unity Editor 

```bash 
cd /opt/Unity/Editor
```

## Création et activation de la license 

### Création 

On crée notre fichier de licence puis on affiche son contenue :

```bash
./Unity -quit -batchmode -nographics -logfile -createManualActivationFile
# Affichage du contenu
cat Unity_v2019.4.11f1.alf
```

Puis on copie son contenu en local en recréant le même fichier.alf

### Actiavtion

Direction la [page d'activation de licence d'unity](https://license.unity3d.com/manual).
Identifiez vous, sélectionner votre fichier.alf que vous venez de créer, répondez aux questionnaire et enfin votre licence se téléharge.

### Crypter le fichier (Optionnel)

On va maintenant crypter ce fichier car il sera répertorier dans notre repo git.
Pour faire celà on utilise Openssl :

```bash
openssl aes-256-cbc -e -in ./Unity_v2019.x.ulf -out Unity_v2019.x.ulf.enc -k my_pswd
```
Ajoutez une variable secrète d ans les settings du repository

<strong>Placez votre fichiez de licence (encodé si vous l'avez fait) dans un dossier .github à la racine du repo</strong>

## Instruction du CI 