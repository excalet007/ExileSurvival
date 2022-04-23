using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimeManagerEx : MonoBehaviour
{
    public float Time { get; private set; }

    public void OnUpdate()
    {
        switch (Managers.Game.State)
        {
            case Define.GameState.Play:
                Time += UnityEngine.Time.deltaTime * Managers.Game.GameSpeed;

                TMP_Text text = FindObjectOfType<TMP_Text>();
                var minute = Time / 60;
                var second = Time % 60;
                
                text.text = $"{(int)minute} : {(int)second}";
                break;
            
            case Define.GameState.Idle:
            case Define.GameState.Pause:
                break;
        }
    }

    public void Init()
    {
        Time = 0f;
    }
}

