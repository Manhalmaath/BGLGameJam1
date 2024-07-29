using System;
using UnityEngine;
public class Battery : MonoBehaviour
    {
        [SerializeField] private float batteryCharge = SaveData.MaxBatteryLevel / 2;
        private GameManager _gameManager;

        private void Awake()
        {
            _gameManager = FindObjectOfType<GameManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            SFXManager.Instance.PlayBatteryPickupSound();
            _gameManager.RechargeBattery(batteryCharge);
            Destroy(gameObject);
        }
    }
