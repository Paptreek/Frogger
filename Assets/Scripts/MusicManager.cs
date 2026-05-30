using UnityEngine;

public static class MusicManager
{
    public static void ToggleMute()
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
