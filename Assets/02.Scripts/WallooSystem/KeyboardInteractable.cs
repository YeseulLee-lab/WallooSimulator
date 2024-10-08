using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyboardInteractable : CustomInteractableBase
{
    protected override void Start()
    {
        base.Start();
    }

    /*public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            _animator.SetBool("isWallooing", isSelected && _isWallooing);
        }
    }*/

    public override void PlayWallooAction(SelectEnterEventArgs args)
    {
        base.PlayWallooAction(args);
    }

    public override void SelectExit(SelectExitEventArgs args)
    {
        base.SelectExit(args);
    }
}
