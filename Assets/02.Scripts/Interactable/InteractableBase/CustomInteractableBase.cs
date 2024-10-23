using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CustomInteractableBase : MonoBehaviour
{
    //������Ʈ ������
    [SerializeField]
    protected InteractableData _interactableData;
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
        GetComponent<XRBaseInteractable>().selectEntered.AddListener(PlayWallooAction);
        GetComponent<XRBaseInteractable>().selectExited.AddListener(SelectExit);

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
            WallooManager.instance.doubtRate += _interactableData.doubtRate;
            WallooManager.instance.wallooScore += _interactableData.wallooScore;
            if (_animator != null)
            {
                _animator.SetBool("isWallooing", true);
                _animator.enabled = true;
            }
                

            UniCoolTime().Forget();
        }
        else
        {
            Debug.Log("���� ��Ÿ���� ��á���ϴ�.");
        }
    }

    //Grip Button Up
    public virtual void SelectExit(SelectExitEventArgs args)
    {
        if (_animator != null)
            _animator.SetBool("isWallooing", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�ٴڿ� ������ �����ڸ��� ���ư�
        if (collision.gameObject.layer == 0)
        {
            gameObject.transform.position = originTransform.position;
            gameObject.transform.rotation = originTransform.rotation;
        }
    }
    #endregion

    #region CoolTime
    public async UniTaskVoid UniCoolTime()
    {
        while (_interactableData.coolTime > 0f)
        {
            if (_coolTimeCancel.IsCancellationRequested)
            {
                _coolTimeCancel = new CancellationTokenSource();
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

