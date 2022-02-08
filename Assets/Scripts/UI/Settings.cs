using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Animator _animator;
    private WaitForSeconds _delay = new WaitForSeconds(1f);

    private void Awake()
    {
        _animator.SetTrigger("Start");
    }

    public void ReturnToMainMenu()
    {
        _audio.Play();
        _animator.SetTrigger("End");
        StartCoroutine(LoadSceneAfterSeconds("MainMenu"));
    }

    public void ChangeSoundVolume()
    {
        throw new NotImplementedException();
    }

    public void ChangeMusicVolume()
    {
        throw new NotImplementedException();
    }
    
    private IEnumerator LoadSceneAfterSeconds(string sceneName)
    {
        yield return _delay;
        SceneManager.LoadScene(sceneName);
    }
}