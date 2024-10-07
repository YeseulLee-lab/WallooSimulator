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

    private Animator _animator;

    //coolTime
    protected float _curCoolTime;
    private CancellationTokenSource _coolTimeCancel = new CancellationTokenSource();

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
        if (WallooManager.instance.isWallooing)
        {
            return;
        }

        WallooManager.instance.isWallooing = true;

        //��Ÿ���� �� á���� ���� �ൿ ����
        if (_curCoolTime >= _interactableData.coolTime)
        {
            if (_animator != null)
                _animator.enabled = true;

            UniCoolTime().Forget();
        }
        else
        {
            Debug.Log("���� ��Ÿ���� ��á���ϴ�.");
        }
    }

    public virtual void SelectExit(SelectExitEventArgs args)
    {
        Debug.Log("���� ���");
        WallooManager.instance.isWallooing = false;

        if (_animator != null)
            _animator.enabled = false;
    }
    #endregion

    #region CoolTime
    async UniTaskVoid UniCoolTime()
    {
        while (true)
        {
            if (_coolTimeCancel.IsCancellationRequested)
            {
                _curCoolTime = 0f;
                break;
            }

            //�� ��Ÿ�� ��ŭ _curCoolTime �÷���
            await UniTask.Delay(TimeSpan.FromSeconds(1f), _curCoolTime < _interactableData.coolTime, cancellationToken: _coolTimeCancel.Token);
            _curCoolTime += 1f;
        }
    }
    #endregion
}

[Serializable]
public class InteractableData
{
    private float _wallooTime;
    private int _wallooScore;
    private float _doubtRate;
    private float _coolTime;

    public InteractableData(float wallooTime, int wallooScore, float doubtRate, float coolTime)
    {
        _wallooTime = wallooTime;
        _wallooScore = wallooScore;
        _doubtRate = doubtRate;
        _coolTime = coolTime;
    }

    public float wallooTime
    {
        get
        {
            return _wallooTime;
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