using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    private AudioSource _bgm;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _bgm = GetComponent<AudioSource>();
    }

    void Start()
    {
        if (!_bgm.isPlaying)
        {
            _bgm.Play(); // may need to try public static to stop music from stacking on reset
        }

        SceneManager.LoadScene("Title");
    }

    public static void ToggleAudioMute()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }
}
