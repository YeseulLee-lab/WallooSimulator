using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Interactable : XRBaseInteractable
{
    //오브젝트 데이터
    public InteractableData _interactableData;
    protected Transform originTransform;
    protected bool _isWallooing;

    protected Animator _animator;

    //coolTime
    protected float _curCoolTime = 0f;
    protected CancellationTokenSource _coolTimeCancel = new CancellationTokenSource();

    #region Unity Life Cycle
    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        selectEntered.AddListener(PlayWallooAction);
        selectExited.AddListener(SelectExit);

        originTransform = transform;
    }
    #endregion

    #region Interact
    public virtual void PlayWallooAction(SelectEnterEventArgs args)
    {
        //쿨타임이 다 찼으면 월루 행동 가능
        if (_curCoolTime <= 0f)
        {
            Debug.Log("월루 행동시작");
            _isWallooing = true;
            if (_animator != null)
                _animator.enabled = true;

            UniCoolTime().Forget();
        }
        else
        {
            Debug.Log("아직 쿨타임이 안찼습니다.");
        }
    }

    //Grip 버튼 Up
    public virtual void SelectExit(SelectExitEventArgs args)
    {
        if (_animator != null)
            _animator.enabled = false;
    }
    #endregion

    #region CoolTime
    async UniTaskVoid UniCoolTime()
    {
        while (_interactableData.coolTime > 0f)
        {
            if (_coolTimeCancel.IsCancellationRequested)
            {
                return;
            }

            if (_curCoolTime < _interactableData.coolTime)
            {
                //총 쿨타임 만큼 _curCoolTime 플러스
                await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: _coolTimeCancel.Token);
                _curCoolTime += 1f;
                Debug.Log(_interactableData.name + "쿨타임: " + _curCoolTime);
            }
            else
            {
                _coolTimeCancel.Cancel();
                Debug.Log("unitask 취소");
                _curCoolTime = 0f;
                _isWallooing = false;
            }
        }
    }
    #endregion
}

[Serializable]
public class InteractableData
{
    private string _name;
    private float _skipTime;
    private int _wallooScore;
    private float _doubtRate;
    private float _coolTime;

    public InteractableData(string name, float skipTime, int wallooScore, float doubtRate, float coolTime)
    {
        _name = name;
        _skipTime = skipTime;
        _wallooScore = wallooScore;
        _doubtRate = doubtRate;
        _coolTime = coolTime;
    }

    public string name
    {
        get { return _name; }
    }

    public float skipTime
    {
        get
        {
            return _skipTime;
        }
    }

    public float wallooScoreme
    {
        get
        {
            return _wallooScore;
        }
    }

    public float doubtRate
    {
        get
        {
            return _doubtRate;
        }
    }

    public float coolTime
    {
        get
        {
            return _coolTime;
        }
    }
}