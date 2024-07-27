using System;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject flashlightEffect;
    public float batteryLife = 100f; // Battery life in seconds

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        var direction = mousePosition - playerTransform.position;
        direction.Normalize();

        transform.right = direction;

        if (flashlightEffect.activeSelf)
        {
            batteryLife -= Time.deltaTime;

            if (batteryLife <= 0f)
            {
                flashlightEffect.SetActive(false);
            }

            _gameManager.onBatteryLevelChange.Invoke(batteryLife);
        }
    }

    public void RechargeBattery(float amount)
    {
        batteryLife += amount;
    }
}