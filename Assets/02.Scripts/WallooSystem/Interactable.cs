using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Interactable : XRBaseInteractable
{
    private Animator _animator;
    [SerializeField]
    private float _wallooTime;
    [SerializeField]
    private int _walloScore;
    [SerializeField]
    private float _doubtRate;

    protected bool isTriggered;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public virtual void PlayWallooAction(SelectEnterEventArgs args)
    {
        if (WallooManager.instance.isWallooing)
        {
            return;
        }

        if(_animator != null)
            _animator.enabled = true;

        WallooManager.instance.isWallooing = true;
    }
}
