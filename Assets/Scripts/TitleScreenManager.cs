using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _frog;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Instantiate(_frog);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToggleMute()
    {
        MusicManager.ToggleMute();
    }
}
