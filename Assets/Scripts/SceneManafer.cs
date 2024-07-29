using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instanse;
    
    private void Awake()
    {
        if (Instanse == null)
        {
            Instanse = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void NextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
