using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.XR.Interaction.Toolkit;

public class MonitorInteractable : Interactable
{
    [SerializeField]
    private Image black;

    #region Unity Life Cycle
    protected override void Start()
    {
        base.Start();
        
        _interactableData = new InteractableData(0f, 0, 0f, 0f);
    }
    #endregion

    public override void PlayWallooAction(SelectEnterEventArgs args)
    {
        base.PlayWallooAction(args);

        Debug.Log("����� ����");

        GetComponent<BoxCollider>().enabled = false;

        black.DOFade(0f, 0.8f).OnComplete(() =>
        {
            black.gameObject.SetActive(false);
        });

        //����͸� �Ѿ� �� ������
        WallooManager.instance.isWorkStart = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            gameObject.transform.position = originTransform.position;
            gameObject.transform.rotation = originTransform.rotation;
        }
    }
}
