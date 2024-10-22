using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PenHolderInteractable : CustomInteractableBase
{
    protected override void Start()
    {
        base.Start();
    }

    public override void PlayWallooAction(SelectEnterEventArgs args)
    {
        base.PlayWallooAction(args);
    }

    public override void SelectExit(SelectExitEventArgs args)
    {
        base.SelectExit(args);
    }
}
