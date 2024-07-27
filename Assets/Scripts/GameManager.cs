using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private Transform spawnPoint;
    public UnityEvent<float> onBatteryLevelChange;
}
