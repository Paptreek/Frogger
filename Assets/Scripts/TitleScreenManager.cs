using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject _frog;
    [SerializeField] private GameObject _ribbitSoundObj;

    private AudioSource _ribbitSound;

    void Awake()
    {
        _ribbitSound = _ribbitSoundObj.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //_ribbitSound.Play();
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
