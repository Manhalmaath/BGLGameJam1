using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip darkRoomMusic;
    [SerializeField] private AudioClip lightRoomMusic;

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

    public void PlayDarkRoomMusic()
    {
        audioSource.clip = darkRoomMusic;
        audioSource.Play();
    }

    public void PlayLightRoomMusic()
    {
        audioSource.clip = lightRoomMusic;
        audioSource.Play();
    }
}