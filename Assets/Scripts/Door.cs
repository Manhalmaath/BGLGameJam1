using UnityEngine;

public class Door : MonoBehaviour
{
    private KeyManager _keyManager;
    private Collider2D _collider;
    
    private void Awake()
    {
        _keyManager = GetComponentInParent<KeyManager>();
        _keyManager.onDoorOpen.AddListener(OpenDoor);
        _collider = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("The Door is CLoSeD!");
        }
    }

    private void OpenDoor()
    {
        _collider.enabled = false;
    }
}