using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private Image batteryLevelImage;
    [SerializeField] private Sprite[] batteryLevelSprites; 
    [SerializeField] private float maxBatteryLevel;
    [SerializeField] private Text timer;
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.onBatteryLevelChange.AddListener(UpdateBatteryLevel);
        _gameManager.onGameOver.AddListener(ShowGameOverScreen);
        maxBatteryLevel = SaveData.MaxBatteryLevel;
    }

    private void Update()
    {
        var timeSpan = TimeSpan.FromSeconds(_gameManager.timeLeft);
        timer.text = $"{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}";
    }

    private void UpdateBatteryLevel(float level)
    {
        batteryLevelImage.sprite = level switch
        {
            _ when level > maxBatteryLevel * 0.75f => batteryLevelSprites[3],
            _ when level > maxBatteryLevel * 0.5f => batteryLevelSprites[2],
            _ when level > maxBatteryLevel * 0.25f => batteryLevelSprites[1],
            _ when level >= 0 => batteryLevelSprites[0],
            _ => batteryLevelSprites[0] 
        };
    }
    
    private void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        MusicManager.Instance.GetComponent<AudioSource>().Stop();
    }
    
}