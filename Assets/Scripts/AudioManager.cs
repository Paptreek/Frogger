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
            _bgm.Play();
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
