using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _screenPanel;
    [SerializeField] private GameObject _pauseMenuPanel;
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _muteButton;
    [SerializeField] private GameObject _unmuteButton;
    [SerializeField] private GameObject _optionsButton;

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

        UpdateMuteButton();
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

    public void ToggleMute()
    {
        MusicManager.ToggleMute();
    }

    private void UpdateMuteButton()
    {
        //Debug.Log($"Pause Panel: {_pauseMenuPanel.activeInHierarchy} Audio Listener: {AudioListener.volume}");

        if (_pauseMenuPanel.activeInHierarchy && !_optionsButton.activeInHierarchy)
        {
            if (AudioListener.volume == 1)
            {
                _muteButton.SetActive(true);
                _unmuteButton.SetActive(false);
            }
            else if (AudioListener.volume == 0)
            {
                _muteButton.SetActive(false);
                _unmuteButton.SetActive(true);
            }
        }
        else
        {
            _muteButton.SetActive(false);
            _unmuteButton.SetActive(false);
        }

    }
}
