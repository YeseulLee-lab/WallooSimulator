using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterInteractable : CustomGrabInteractableBase
{
    [SerializeField]
    private GameObject _waterParticle;
    [SerializeField]
    private AudioClip _waterAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WaterPoint>() != null)
        {
            other.GetComponent<WaterPoint>()._plantAnimator.SetBool("isWallooing", true);
            AudioManager.instance.PlaySound(_waterAudioClip);
            WaterToPlant();
        }
    }

    public void WaterToPlant()
    {
        _waterParticle.SetActive(true);
    }
}
