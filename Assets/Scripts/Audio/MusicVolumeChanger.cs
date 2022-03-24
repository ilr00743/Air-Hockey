using System;
using UnityEngine;

public class MusicVolumeChanger : MonoBehaviour
{
    private void Start()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Music");
    }
}