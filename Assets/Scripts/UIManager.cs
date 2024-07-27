using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private Image batteryLevelImage;
    [SerializeField] private Sprite[] batteryLevelSprites;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.onBatteryLevelChange.AddListener(UpdateBatteryLevel);
    }

    private void UpdateBatteryLevel(float level)
    {
        batteryLevelImage.sprite = level switch
        {
            <= 100 and >= 60 => batteryLevelSprites[3],
            <= 60 and >= 30 => batteryLevelSprites[2],
            <= 30 and >= 0 => batteryLevelSprites[1],
            _ => batteryLevelSprites[0]
        };
    }
}