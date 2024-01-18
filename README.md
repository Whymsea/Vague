# SAE501PortCrosTHOMY

- Version 0.5
  
# Installation


1. **Téléchargement du Projet :** Cliquez sur le bouton vert "Code" en haut de cette page, puis sélectionnez "Download ZIP".


2. **Extraction de l'Archive :** Une fois le téléchargement terminé, extrayez le contenu de l'archive ZIP dans un dossier de votre choix.


## Configuration d'Unity


1. **Ouverture du Projet dans Unity Hub :** Ouvrez Unity Hub et cliquez sur "Add" pour ajouter le projet Unity. Sélectionnez le dossier que vous venez d'extraire.


## Exécution du Projet


1. **Lancement d'Unity :** Ouvrez le projet que vous venez d'importer en cliquant sur son nom.

2. **Vérification du Mode de Build :** Assurez-vous que le mode de build est correctement configuré pour Android. Pour cela, suivez ces étapes :
    - Allez dans File -> Build Settings.
    - Sélectionnez la plateforme "Android" dans la liste des plateformes disponibles.
    - Si "Android" n'est pas dans la liste, cliquez sur "Switch Platform" pour le sélectionner.

 Vérification de votre projet pour la VR pour un Oculus

3.1 **Vérification de XR Plug-in Management :** Assurez-vous que XR Plug-in Management est correctement configuré :  
   - Allez dans Edit -> Project Settings -> XR Plug-in Management.  
   - Assurez-vous que "OpenXR" est coché pour le support VR sur PC.  
   - Cliquez si le panneau ⚠️ figure à côté de Open-XR pour régler les différentes erreurs.  
   - Ensuite, cliquez sur Open-XR qui doit maintenant se retrouver en dessous de XR Plug-in Management dans project setting sur la gauche.  
   - Dans "Interaction Profile", en cliquant sur le "+" sélectionnez le type de contrôleur que vous utilisez (si vous utilisez Oculus, cela sera "Oculus Touch Controller Profile").

⚠️ Si XR Plug-in Management n'est pas installé, passez directement au 4.1⚠️

3.2 **Vérification de Open XR :** Assurez-vous que Open XR Management est correctement configuré :  
   - Cliquer sur Open-XR qui doit maintenant se retrouver en dessous de XR Plug-in Management dans project setting sur la gauche.  
   - Dans l'onglet PC vous trouverez dans render mode par défaut "Single Pass Instanced" changer le en cliquant dessus par "Multi-Pass".  
   - Dans l'onglet PC vous trouverez "Interaction Profile" en cliquant sur le "+" sélectionner le type de controller que vous utilisez (si vous utilisez oculus cela sera "Oculus Touch Controller Profile).  
   - Maintenant dans l'onglet Android

3.3 **Vérification de Oculus :**  
   - Cliquer sur Oculus qui doit maintenant se retrouver en dessous de Open XR dans project setting sur la gauche.  
   - Vérifier bien que Stereo Rendering mode soit bien en Multi Pass et que dans Target Device le bon matériel soit coché (nous utilisons des Quest 2).

3.4 **Vérification de XR Interaction Toolkit:**  
   - Allez dans Window -> Package Manager -> XR Interaction Toolkit. ⚠️Vérifier que XR Interaction Toolkit soit dans la liste dans package manager sinon passer à l'étape 4.4⚠️.  
   - Vérifier dans Samples puis cliquez sur import sur ce qui sont disponibles pour être sûr d'avoir tous les fichiers.

Configuration de votre projet pour la VR pour un Oculus

4.1 **Configuration de XR Plug-in Management s'il n'est pas installé :**  
   - Allez dans Edit -> Project Settings -> XR Plug-in Management.  
   - Appuyer sur installer XR Plug-in Management  
   - Cocher Open-XR dans l'onglet PC de XR Plug-in Management.  
   - Cliquer si le panneau ⚠️ figure à côté de Open-XR pour régler les différentes erreurs.  
   - Maintenant dans l'onglet Android cochez Oculus

4.2 **Configuration de Open XR s'il n'est pas installé :**  
   - Cliquer sur Open-XR qui doit maintenant se retrouver en dessous de XR Plug-in Management dans project setting sur la gauche.  
   - Dans l'onglet PC vous trouverez dans render mode par défaut "Single Pass Instanced" changer le en cliquant dessus par "Multi-Pass".  
   - Dans l'onglet PC vous trouverez "Interaction Profile" en cliquant sur le "+" sélectionnez le type de controller que vous utilisez (si vous utilisez oculus cela sera "Oculus Touch Controller Profile).

4.3 **Vérification de Oculus :**  
   - Cliquer sur Oculus qui doit maintenant se retrouver en dessous de Open XR dans project setting sur la gauche.  
   - Vérifier bien que Stereo Rendering mode soit bien en Multi Pass et que dans Target Device le bon matériel soit coché (nous utilisons des Quest 2).

4.4 **Configuration de XR Interaction Toolkit :**  
   - Allez dans Window -> Package Manager.  
   - Cliquer sur "+" puis sur "Add package from git Url"  
   - L'Url à rentrer est : com.unity.xr.interaction.toolkit  
   - Lorsque celui-ci a été téléchargé une fenêtre est susceptible de venir "XR InteractionMask Update Required", vous pouvez appuyer sur "I made a backup Go ahead".  
   - Package Manager -> XR Interaction Toolkit, cliquer sur Samples puis cliquez sur import sur ce qui sont disponibles pour être sûr d'avoir tous les fichiers.



    
La Configuration étant fini vous pouvez à présent fermé Package Manager et revenir sur l'écran de votre scène  



5. **Lancement du Jeu :** Appuyez sur le bouton "Play" dans Unity pour lancer le jeu.  
