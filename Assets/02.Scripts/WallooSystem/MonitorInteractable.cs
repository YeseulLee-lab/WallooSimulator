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
    }

    public override void PlayWallooAction(SelectEnterEventArgs args)
    {
        Debug.Log("모니터 켜짐");

        GetComponent<BoxCollider>().enabled = false;

        black.DOFade(0f, 0.8f).OnComplete(() =>
        {
            black.gameObject.SetActive(false);
        });

        //모니터를 켜야 일 시작함
        WallooManager.instance.isWorkStart = true;
    }
}
