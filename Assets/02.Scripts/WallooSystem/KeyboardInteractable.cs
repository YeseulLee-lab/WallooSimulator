using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyboardInteractable : Interactable
{
    protected override void Start()
    {
        base.Start();

        _interactableData = new InteractableData("Ű����", 0f, 0, -22f, 20f);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
        {
            if (_coolTimeCancel.IsCancellationRequested)
            {
                if (isSelected)
                    Debug.Log("Ÿ��ġ����");
            }
        }
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
