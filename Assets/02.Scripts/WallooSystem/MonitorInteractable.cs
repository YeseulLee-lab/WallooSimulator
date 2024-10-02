using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class MonitorInteractable : Interactable
{
    [SerializeField]
    private Image black;

    private void Start()
    {
        selectEntered.AddListener(PlayWallooAction);
        selectExited.AddListener(SelectExit);
    }

    public override void PlayWallooAction(SelectEnterEventArgs args)
    {
        Debug.Log("����� ����");

        GetComponent<BoxCollider>().enabled = false;

        black.DOFade(0f, 0.8f).OnComplete(() =>
        {
            black.gameObject.SetActive(false);
        });

        //����͸� �Ѿ� �� ������
        WallooManager.instance.isWorkStart = true;
    }

    public void SelectExit(SelectExitEventArgs args)
    {
        Debug.Log("���� ���");
    }
}
