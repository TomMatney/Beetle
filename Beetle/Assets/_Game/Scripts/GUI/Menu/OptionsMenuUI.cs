using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuUI : MonoBehaviour
{
    private const string MusicVolumePrefsKey = "MusicVolume";
    private const string SFXVolumePrefsKey = "SFXVolume";
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private AudioMixer mixer;

    void Start()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat(MusicVolumePrefsKey, 0.7f);
        OnMusicVolumeChanged(musicVolumeSlider.value);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat(SFXVolumePrefsKey, 0.7f);
        OnSFXVolumeChanged(sfxVolumeSlider.value);
    }

    private void OnEnable()
    {
        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
    }

    private void OnDisable()
    {
        musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
        sfxVolumeSlider.onValueChanged.RemoveListener(OnSFXVolumeChanged);
    }

    private void OnSFXVolumeChanged(float volume)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log(volume) * 20f);
        PlayerPrefs.SetFloat(SFXVolumePrefsKey, volume);
    }

    private void OnMusicVolumeChanged(float volume)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log(volume) * 20f);
        PlayerPrefs.SetFloat(MusicVolumePrefsKey, volume);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Launcher");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
