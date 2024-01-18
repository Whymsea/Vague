using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoClip[] videoClips;
    public GameObject[] quizzes;
    public Button nextButton;
    public Button prevButton;
    public SettingManager settingManager;

    public int currentVideoIndex = 0;
    public VideoPlayer videoPlayer;
    public GameObject sphere;  // Référence à votre sphère existante

    void Start()
    {
        // Assurez-vous d'assigner la sphère existante dans l'inspecteur Unity
        if (sphere == null)
        {
            Debug.LogError("Sphere reference not assigned. Please assign the existing sphere in the Unity Inspector.");
            return;
        }

        CreateVideoPlayer();
        ShowVideo(currentVideoIndex);

        nextButton.onClick.AddListener(NextVideo);
        prevButton.onClick.AddListener(PreviousVideo);
    }

    void CreateVideoPlayer()
    {
        videoPlayer = sphere.GetComponent<VideoPlayer>();

        // Assurez-vous que videoClips est correctement initialisé
        if (videoClips.Length > 0)
        {
            videoPlayer.source = VideoSource.VideoClip;
            videoPlayer.clip = videoClips[currentVideoIndex];
            videoPlayer.loopPointReached += VideoEnded;
        }
        else
        {
            Debug.LogError("No video clips assigned.");
        }
    }

    void ShowVideo(int index)
    {
        // Vérifiez si l'index est dans les limites du tableau
        if (index >= 0 && index < videoClips.Length)
        {
            if (videoPlayer != null)
            {
                videoPlayer.Stop();
                videoPlayer.clip = videoClips[index];
                videoPlayer.Play();

                // Assurez-vous que l'index est dans les limites de quizzes
                if (index < quizzes.Length)
                {
                    // Désactiver le MeshRenderer de la sphère
                    sphere.GetComponent<MeshRenderer>().enabled = false;
                    // quizzes[index].SetActive(false);
                }
                else
                {
                    Debug.LogError("Index is out of bounds for quizzes array.");
                }
            }
            else
            {
                Debug.LogError("VideoPlayer not properly initialized.");
            }
        }
        else
        {
            // Gérer le cas où l'index est hors limites (vous pouvez ajuster selon vos besoins)
            Debug.LogWarning("Index is out of bounds");
        }
    }

    void NextVideo()
    {
        // Arrêter la vidéo en cours
        videoPlayer.Stop();

        // Passer à la vidéo suivante
        currentVideoIndex = (currentVideoIndex + 1) % videoClips.Length;

        // Afficher la nouvelle vidéo
        ShowVideo(currentVideoIndex);
    }

    void PreviousVideo()
    {
        // Arrêter la vidéo en cours
        videoPlayer.Stop();

        // Passer à la vidéo précédente
        currentVideoIndex = (currentVideoIndex - 1 + videoClips.Length) % videoClips.Length;

        // Afficher la nouvelle vidéo
        ShowVideo(currentVideoIndex);
    }

    void VideoEnded(VideoPlayer vp)
{
    if (vp == videoPlayer)
    {
        // La vidéo en cours a atteint la fin
        // Vous pouvez ajouter ici une logique pour afficher le quiz ou passer à la vidéo suivante selon vos besoins
        // Par exemple, si vous souhaitez afficher le quiz après chaque vidéo, vous pouvez appeler la fonction ShowQuiz.

        // Pour passer à la vidéo suivante, appelez la fonction NextVideo
        NextVideo();
    }
}
}
