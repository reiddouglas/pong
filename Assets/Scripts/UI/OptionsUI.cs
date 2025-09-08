using UnityEngine;
using System;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{

    public event Action OnOptionsClosed;

    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundFXVolumeSlider;

    private void OnEnable()
    {
        masterVolumeSlider.onValueChanged.AddListener(SoundMixerManager.Instance.setMasterVolume);
        musicVolumeSlider.onValueChanged.AddListener(SoundMixerManager.Instance.setMusicVolume);
        soundFXVolumeSlider.onValueChanged.AddListener(SoundMixerManager.Instance.setSoundFXVolume);

        masterVolumeSlider.value = SoundMixerManager.Instance.getMasterVolume();
        musicVolumeSlider.value = SoundMixerManager.Instance.getMusicVolume();
        soundFXVolumeSlider.value = SoundMixerManager.Instance.getSoundFXVolume();
    }

    private void OnDisable()
    {
        masterVolumeSlider.onValueChanged.RemoveListener(SoundMixerManager.Instance.setMasterVolume);
        musicVolumeSlider.onValueChanged.RemoveListener(SoundMixerManager.Instance.setMusicVolume);
        soundFXVolumeSlider.onValueChanged.RemoveListener(SoundMixerManager.Instance.setSoundFXVolume);
    }

    public void Apply()
    {
        gameObject.SetActive(false);
        OnOptionsClosed?.Invoke();
    }
}
