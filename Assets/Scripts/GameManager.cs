using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [HideInInspector] public UnityEvent<float> onBatteryLevelChange;
    [HideInInspector] public UnityEvent onGameOver;
    public float batteryLevel, timeLeft;

    private void Start()
    {

        timeLeft = SaveData.TimeLeft;
        batteryLevel = SaveData.BatteryLevel;
        
        var num = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
        switch (num.buildIndex)
        {
            case 1 or 3:
                MusicManager.Instance.PlayDarkRoomMusic();
                break;
            case 2:
                MusicManager.Instance.PlayLightRoomMusic();
                break;
        }
    }

    private void Update()
    {
        if (timeLeft <= 0)
        {
            onGameOver.Invoke();
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
    }

    private void OnDestroy()
    {
        SaveData.TimeLeft = timeLeft;
        SaveData.BatteryLevel = batteryLevel;
    }
}