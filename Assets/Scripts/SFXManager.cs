using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip keyPickupSound;
    [SerializeField] private AudioClip batteryPickupSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJumpSound()
    {
        audioSource.clip = jumpSound;
        audioSource.Play();
    }
    
    public void PlayKeyPickupSound()
    {
        audioSource.clip = keyPickupSound;
        audioSource.Play();
    }
    
    public void PlayBatteryPickupSound()
    {
        audioSource.clip = batteryPickupSound;
        audioSource.Play();
    }
}