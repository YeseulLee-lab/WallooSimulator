using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MonitorInteractable : Interactable
{
    [SerializeField]
    private Image black;

    public override void PlayWallooAction()
    {
        GetComponent<BoxCollider>().enabled = false;

        black.DOFade(0f, 0.8f).OnComplete(() =>
        {
            black.gameObject.SetActive(false);
        });

        WallooManager.instance.isWorkStart = true;
    }
}
