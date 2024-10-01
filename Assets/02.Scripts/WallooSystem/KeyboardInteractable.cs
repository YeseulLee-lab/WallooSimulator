using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyboardInteractable : Interactable
{
    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            /*if(isSelected)
                PlayWallooAction();*/
        }
    }

    public override void AttachCustomReticle(IXRInteractor interactor)
    {
        Debug.Log("Grab");
    }

    public override void PlayWallooAction(SelectEnterEventArgs args)
    {
        //base.PlayWallooAction();

        Debug.Log("타자치는중");
    }
}
