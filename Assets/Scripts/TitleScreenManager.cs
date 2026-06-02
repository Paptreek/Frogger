using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _frog;
    [SerializeField] private GameObject _ribbitSoundObj;
    [SerializeField] private GameObject _muteButton;
    [SerializeField] private GameObject _unmuteButton;
    [SerializeField] private GameObject _optionsButton;

    private AudioSource _ribbitSound;

    void Awake()
    {
        _ribbitSound = _ribbitSoundObj.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _ribbitSound.Play();
            Instantiate(_frog);
        }

        UpdateMuteButton();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToggleMute()
    {
        MusicManager.ToggleMute();
    }

    private void UpdateMuteButton()
    {
        if (!_optionsButton.activeInHierarchy)
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
