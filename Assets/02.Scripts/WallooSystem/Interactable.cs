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
        if (WallooManager.instance.isWallooing)
        {
            return;
        }

        WallooManager.instance.isWallooing = true;

        //��Ÿ���� �� á���� ���� �ൿ ����
        if (_curCoolTime <= 0f)
        {
            Debug.Log("���� �ൿ����");
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
        WallooManager.instance.isWallooing = false;

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
                Debug.Log("unitask ���");
                _curCoolTime = 0f;
                break;
            }

            //�� ��Ÿ�� ��ŭ _curCoolTime �÷���
            await UniTask.Delay(TimeSpan.FromSeconds(1f), _curCoolTime >= _interactableData.coolTime, cancellationToken: _coolTimeCancel.Token);
            _curCoolTime += 1f;
            Debug.Log(_interactableData.name + "��Ÿ��: " + _curCoolTime);
        }
    }
    #endregion
}

[Serializable]
public class InteractableData
{
    private string _name;
    private float _wallooTime;
    private int _wallooScore;
    private float _doubtRate;
    private float _coolTime;

    public InteractableData(string name, float wallooTime, int wallooScore, float doubtRate, float coolTime)
    {
        _name = name;
        _wallooTime = wallooTime;
        _wallooScore = wallooScore;
        _doubtRate = doubtRate;
        _coolTime = coolTime;
    }

    public string name
    {
        get { return _name; }
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