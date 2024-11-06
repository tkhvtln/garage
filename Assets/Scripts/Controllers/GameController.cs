using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameController : MonoBehaviour
{
    private bool _isSceneLoaded;

    [Inject]
    private void Construct()
    {
        LoadLevel();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void LoadLevel() 
    {
        UnloadScene();
        LoadScene();
    }

    private void LoadScene()
    {
        if (!_isSceneLoaded)
        {
            _isSceneLoaded = true;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        }
    }

    private void UnloadScene()
    {
        if (_isSceneLoaded)
        {
            _isSceneLoaded = false;
            SceneManager.UnloadSceneAsync(1);
        }
    }
}
