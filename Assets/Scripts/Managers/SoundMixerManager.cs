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
        }
    }

    [SerializeField] private AudioMixer audioMixer;

    public void setMasterVolume(float level)
    {
        audioMixer.SetFloat("MasterVolume", scaleVolume(level));
    }

    public void setMusicVolume(float level)
    {
        audioMixer.SetFloat("MusicVolume", scaleVolume(level));
    }

    public void setSoundFXVolume(float level)
    {
        audioMixer.SetFloat("SoundFXVolume", scaleVolume(level));
    }

    private float scaleVolume(float level)
    {
        return Mathf.Log10(level) * 20f;
    }
}
