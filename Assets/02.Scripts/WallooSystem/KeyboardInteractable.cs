using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyboardInteractable : XRSimpleInteractable
{
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if(isSelected)
                PlayWallooAction();
        }
    }

    public void PlayWallooAction()
    {
        //base.PlayWallooAction();

        Debug.Log("타자치는중");
    }
}
