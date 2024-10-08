using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Interactable : XRBaseInteractable
{
    //������Ʈ ������
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
        //��Ÿ���� �� á���� ���� �ൿ ����
        if (_curCoolTime <= 0f)
        {
            Debug.Log("���� �ൿ����");
            _isWallooing = true;
            if (_animator != null)
                _animator.enabled = true;

            UniCoolTime().Forget();
        }
        else
        {
            Debug.Log("���� ��Ÿ���� ��á���ϴ�.");
        }
    }

    //Grip ��ư Up
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
                //�� ��Ÿ�� ��ŭ _curCoolTime �÷���
                await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: _coolTimeCancel.Token);
                _curCoolTime += 1f;
                Debug.Log(_interactableData.name + "��Ÿ��: " + _curCoolTime);
            }
            else
            {
                _coolTimeCancel.Cancel();
                Debug.Log("unitask ���");
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