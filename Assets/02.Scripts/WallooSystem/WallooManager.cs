using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallooManager : MonoBehaviour
{
    public static WallooManager instance;

    private Interactable _curWallooInteractable;

    private float _wallooScore;
    public float wallooScore
    {
        get
        {
            return _wallooScore;
        }
        set
        {
            _wallooScore = value;
        }
    }

    private float _doubtRate;
    public float doubtRate
    {
        get
        {
            return _doubtRate;
        }
        set
        {
            _doubtRate = value;
        }
    }

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

    #region Unity Life Cycle
    private void Awake()
    {
        instance = this;
    }
    #endregion
}
