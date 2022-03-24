using System;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Animator>().SetTrigger("Start");       
    }
}
