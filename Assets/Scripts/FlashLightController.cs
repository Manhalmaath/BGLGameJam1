using System;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject flashlightEffect;

    private GameManager _gameManager;
    private Camera _camera;

    private void Start()
    {
        if (Camera.main != null)
        {
            _camera = Camera.main;
        }
        else
        {
            Debug.LogError("Main camera not found");
        }
    }

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (_camera == null) return;

        var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        var direction = mousePosition - playerTransform.position;
        direction.Normalize();

        transform.right = direction;

        if (flashlightEffect.activeSelf)
        {
            _gameManager.batteryLevel -= Time.deltaTime;

            if (_gameManager.batteryLevel <= 0f)
            {
                flashlightEffect.SetActive(false);
            }

            _gameManager.onBatteryLevelChange.Invoke(_gameManager.batteryLevel);
        }
    }

    public void ToggleFlashlight()
    {
        if (_gameManager.batteryLevel <= 0f) return;
        flashlightEffect.SetActive(!flashlightEffect.activeSelf);
        SFXManager.Instance.PlayToggleFlashlightSound();
    }
}