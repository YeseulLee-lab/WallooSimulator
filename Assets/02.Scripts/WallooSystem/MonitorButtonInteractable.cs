using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonitorButtonInteractable : Interactable
{
    [SerializeField]
    private Image black;

    public override void PlayWallooAction()
    {
        base.PlayWallooAction();
        black.DOFade(0f, 0.8f).OnComplete(() =>
        {
            black.gameObject.SetActive(false);
        });

        WallooManager.instance.isWorkStart = true;
    }
}
