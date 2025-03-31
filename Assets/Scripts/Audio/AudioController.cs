using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public void PlaySFX(string sfxName)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySFX(sfxName);
        }
        else
        {
            Debug.LogError("AudioManager no está inicializado");
        }
    }

    public void PlayMusic(string musicName)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayMusic(musicName);
        }
        else
        {
            Debug.LogError("AudioManager no está inicializado");
        }
    }

    public void StopMusic()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.StopMusic();
        }
        else
        {
            Debug.LogError("AudioManager no está inicializado");
        }
    }
}