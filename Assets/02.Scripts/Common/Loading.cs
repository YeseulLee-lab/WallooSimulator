using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    private void OnEnable()
    {
        SceneSwitcher.Instance.SwitchScene();
    }
}