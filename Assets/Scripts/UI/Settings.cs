using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Animator _animator;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _musicSlider;
    private readonly WaitForSeconds _delay = new WaitForSeconds(1f);

    private void Start()
    {
        _animator.SetTrigger("Start");
        _soundSlider.value = PlayerPrefs.GetFloat("Sound");
        _musicSlider.value = PlayerPrefs.GetFloat("Music");
    }

    public void ReturnToMainMenu()
    {
        _audio.volume = PlayerPrefs.GetFloat("Sound");
        _audio.Play();
        _animator.SetTrigger("End");
        StartCoroutine(LoadSceneAfterSeconds("MainMenu"));
    }

    public void ChangeSoundVolume()
    {
        PlayerPrefs.SetFloat("Sound", _soundSlider.value);
        _audio.volume = PlayerPrefs.GetFloat("Sound");
    }
    
    public void ChangeMusicVolume()
    {
        PlayerPrefs.SetFloat("Music", _musicSlider.value);
    }
    
    private IEnumerator LoadSceneAfterSeconds(string sceneName)
    {
        yield return _delay;
        SceneManager.LoadScene(sceneName);
    }
}