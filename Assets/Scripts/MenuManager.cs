using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _screenPanel;
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private GameObject _gameOverPanel;

    void Update()
    {
        if (_gameOverPanel.activeInHierarchy == false)
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                if (_screenPanel.activeInHierarchy == false)
                {
                    Time.timeScale = 0;
                    _screenPanel.SetActive(true);
                }
                else
                {
                    ResumeGame();
                }
            }
        }

        if (_screenPanel.activeInHierarchy == true)
        {
            _pauseMenuPanel.SetActive(true);
        }
        else
        {
            _pauseMenuPanel.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _screenPanel.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Title");
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
