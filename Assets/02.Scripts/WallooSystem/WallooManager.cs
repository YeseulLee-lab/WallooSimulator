using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class WallooManager : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField]
    private TextMeshProUGUI _wallooScoreText;
    [SerializeField]
    private Button _youtubeBtn;
    [SerializeField]
    private Button _workBtn;
    [SerializeField]
    private Button _offBtn;

    [Header("Timer")]
    [SerializeField]
    private Timer _timer;

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
            if (_isWorkStart)
            {
                _timer.StartTimer();
            }
        }
    }

    private bool _isWallooing;
    public bool isWallooing
    {
        get
        {
            return _isWallooing;
        }
        set
        {
            _isWallooing = value;
        }
    }

    #region Unity Life Cycle
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Init();
    }

    #endregion

    private void Init()
    {
        _wallooScoreText.text = "월루 점수: " + _wallooScore;
    }
}
