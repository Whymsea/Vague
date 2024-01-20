using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoClip[] videoClips;
    public Button nextButton;
    public Button prevButton;
    public QuizManager quizManager;
    public GameObject sphere;
    public GameObject QuizRacine;
    public int currentVideoIndex = 0;
    public VideoPlayer videoPlayer;

    void Start()
    {
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

    public int GetCurrentVideoIndex()
    {
        return currentVideoIndex;
    }

    public void ShowVideo(int index)
    {
        if (index >= 0 && index < videoClips.Length)
        {
            if (videoPlayer != null)
            {
                videoPlayer.Stop();
                videoPlayer.clip = videoClips[index];
                videoPlayer.Play();

                quizManager.DisplayQuestionForVideo(index);
            }
            else
            {
                Debug.LogError("VideoPlayer not properly initialized.");
            }
        }
        else
        {
            Debug.LogWarning("Index is out of bounds");
        }
    }

    public void NextVideo()
    {
        videoPlayer.Stop();
        currentVideoIndex = (currentVideoIndex + 1) % videoClips.Length;
        ShowVideo(currentVideoIndex);
    }

    public void PreviousVideo()
    {
        videoPlayer.Stop();
        currentVideoIndex = (currentVideoIndex - 1 + videoClips.Length) % videoClips.Length;
        ShowVideo(currentVideoIndex);
    }

    public void VideoEnded(VideoPlayer vp)
    {
        if (vp == videoPlayer)
        {
            if (quizManager != null)
            {
                quizManager.StartQuiz();
                QuizRacine.SetActive(!QuizRacine.activeSelf);
            }
            else
            {
                Debug.LogError("QuizManager reference not assigned. Please assign the QuizManager in the Unity Inspector.");
            }
        }
    }
}
