using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip keyPickupSound;
    [SerializeField] private AudioClip openDoorSound;
    [SerializeField] private AudioClip batteryPickupSound;
    [SerializeField] private AudioClip toggleFlashlightSound;

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

    public void PlaySound(AudioClip clip)
    {
        StartCoroutine(PlaySoundCoroutine(clip));
    }

    private IEnumerator PlaySoundCoroutine(AudioClip clip)
    {
        // Wait until the current sound has finished playing
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        // Play the new sound
        audioSource.clip = clip;
        audioSource.Play();
    }


    public void PlayJumpSound()
    {
        PlaySound(jumpSound);
    }

    public void PlayKeyPickupSound()
    {
        PlaySound(keyPickupSound);
    }

    public void PlayOpenDoorSound()
    {
        PlaySound(openDoorSound);
    }
    
    public void PlayBatteryPickupSound()
    {
        PlaySound(batteryPickupSound);
    }
    
    public void PlayToggleFlashlightSound()
    {
        PlaySound(toggleFlashlightSound);
    }
}