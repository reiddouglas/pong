using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    private static SoundMixerManager _Instance;
    public static SoundMixerManager Instance { get { return _Instance; } }
    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [SerializeField] private AudioMixer audioMixer;

    public void setMasterVolume(float level)
    {
        audioMixer.SetFloat("MasterVolume", scaleVolume(level));
    }

    public float getMasterVolume()
    {
        float output;
        audioMixer.GetFloat("MasterVolume", out output);
        return unscaleVolume(output);
    }

    public void setMusicVolume(float level)
    {
        audioMixer.SetFloat("MusicVolume", scaleVolume(level));
    }

    public float getMusicVolume()
    {
        float output;
        audioMixer.GetFloat("MusicVolume", out output);
        return unscaleVolume(output);
    }

    public void setSoundFXVolume(float level)
    {
        audioMixer.SetFloat("SoundFXVolume", scaleVolume(level));
    }

    public float getSoundFXVolume()
    {
        float output;
        audioMixer.GetFloat("SoundFXVolume", out output);
        return unscaleVolume(output);
    }

    private float scaleVolume(float level)
    {
        return Mathf.Log10(level) * 20f;
    }

    private float unscaleVolume(float level)
    {
        return Mathf.Pow(10f, level / 20f);
    }
}
