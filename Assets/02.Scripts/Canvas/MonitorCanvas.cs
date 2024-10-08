using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonitorCanvas : MonoBehaviour
{
    [Header("GUI")]
    [SerializeField]
    private TextMeshProUGUI _wallooScoreText;
    [SerializeField]
    private Button _youtubeBtn;
    [SerializeField]
    private Button _workBtn;
    [SerializeField]
    private Button _offBtn;

    [Header("Timer")]
    [SerializeField]
    private Timer _timer;

    #region Unity Life Cycle
    private void Start()
    {
        Init();
    }
    #endregion

    private void Init()
    {
        _wallooScoreText.text = "���� ����: " + WallooManager.instance.wallooScore;
    }
}
