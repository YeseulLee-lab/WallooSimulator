using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEvent : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clip;

    private void PlaySound()
    {
        AudioManager.instance.PlaySound(_clip);
    }
}
