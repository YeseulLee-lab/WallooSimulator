using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class Timer : MonoBehaviour
{
    [Header("----------UI----------")]
    private TextMeshProUGUI _timeTMP;

    [Header("----------UI----------")]
    //�� �ٹ��ð�
    private float _time = 0f;
    private readonly Action _onTick;

    private int _minute;
    private int _hour;

    #region Unity Life Cycle
    private void Start()
    {
        _timeTMP = GetComponent<TextMeshProUGUI>();
        CalculateTime(0f);
        WallooManager.instance._workStateChangedAction = () => StartTimer();
    }
    #endregion

    #region Timer
    public void StartTimer()
    {
        UniTimer().Forget();
    }

    private void CalculateTime(float curTime)
    {
        //9�ÿ� �� �����ϹǷ� 9�� ������
        _hour = ((int)curTime / 3600) + 9;
        _minute = (int)curTime / 60 % 60;

        _timeTMP.text = _hour.ToString("00") + ":" + _minute.ToString("00");

        if (_hour < 12)
        {
            _timeTMP.text += " AM";
        }
        else
        {
            _timeTMP.text += " PM";
        }
    }

    async UniTaskVoid UniTimer()
    {
        while (true)
        {
            //�� �ٹ��ð��� 9�ð� �̸��̸�
            if (_time < 32400f)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(1f));
                _time += 6f;
                CalculateTime(_time);
                _onTick?.Invoke();
            }
        }
    }
    #endregion
}
