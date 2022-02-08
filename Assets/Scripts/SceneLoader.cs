using System;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    
    private void Awake()
    {
        _animator.SetTrigger("Start");
    }
}
