using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.XR.Interaction.Toolkit;

public class MonitorInteractable : CustomInteractableBase
{
    [SerializeField]
    private Image black;

    #region Unity Life Cycle
    protected override void Start()
    {
        base.Start();
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

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            black.DOFade(0f, 0.8f).OnComplete(() =>
            {
                black.gameObject.SetActive(false);
            });

            //����͸� �Ѿ� �� ������
            WallooManager.instance.isWorkStart = true;
        }
    }
}
