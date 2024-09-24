using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallooManager : MonoBehaviour
{
    public static WallooManager instance;

    private Interactable _curWallooInteractable;
    private float _wallooScore;
    private float _doubtRate;

    private bool _isWorkStart;
    public bool isWorkStart
    {
        get
        {
            return _isWorkStart;
        }
        set
        {
            _isWorkStart = value;
        }
    }

    private void Awake()
    {
        instance = this;
    }
}
