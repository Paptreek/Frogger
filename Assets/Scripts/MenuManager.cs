using UnityEngine;
using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _screenPanel;
    [SerializeField] private GameObject _pauseMenuPanel;

    void Start()
    {
        
    }

    void Update()
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
                //Time.timeScale = 1;
                //_screenPanel.SetActive(false);

                ResumeGame();
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
}
