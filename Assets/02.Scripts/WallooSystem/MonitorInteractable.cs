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

    private Transform initialTransform;

    private void Start()
    {
        selectEntered.AddListener(PlayWallooAction);
        selectExited.AddListener(SelectExit);

        initialTransform = transform;
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

    public void SelectExit(SelectExitEventArgs args)
    {
        Debug.Log("선택 취소");

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            gameObject.transform.position = initialTransform.position;
            gameObject.transform.rotation = initialTransform.rotation;
        }
    }
}
