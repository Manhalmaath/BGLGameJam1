using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class endScript : MonoBehaviour
{
    private VideoPlayer _videoPlayer;
    public GameObject _gameOver;

    private void Awake()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        _gameOver.SetActive(true);
    }
}