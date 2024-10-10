using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BookInteractable : CustomGrabInteractableBase
{
    public override void PlayWallooAction(SelectEnterEventArgs args)
    {
        base.PlayWallooAction(args);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_curCoolTime <= 0f)
            {
                Debug.Log("월루 행동시작");
                _isWallooing = true;
                WallooManager.instance.doubtRate += _interactableData.doubtRate;
                WallooManager.instance.wallooScore += _interactableData.wallooScore;
                if (_animator != null)
                    _animator.enabled = true;

                UniCoolTime().Forget();
            }
            else
            {
                Debug.Log("아직 쿨타임이 안찼습니다.");
            }
        }
    }
}
