using System;
using System.Collections;
using System.Collections.Generic;
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
                //TODO TIME TO UI Debug.Log($"{Time}");
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
