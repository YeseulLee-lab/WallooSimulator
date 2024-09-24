using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Interactable : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]
    private float _wallooTime;
    [SerializeField]
    private int _walloScore;
    [SerializeField]
    private float _doubtRate;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public virtual void PlayWallooAction()
    {
        _animator.enabled = true;
    }

    public virtual void HoverAction()
    {

    }
}
