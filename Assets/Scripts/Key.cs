using UnityEngine;

public class Key : MonoBehaviour
{
    private KeyManager _keyManager;

    private void Awake()
    {
        _keyManager = transform.parent.GetComponent<KeyManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _keyManager.onDoorOpen.Invoke();
            SFXManager.Instance.PlayKeyPickupSound();
            Destroy(gameObject);
        }
    }
}
