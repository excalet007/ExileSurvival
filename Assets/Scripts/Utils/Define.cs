using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define
{
    #region Core Enums
    public enum State
    {
        Die,
        Moving,
        Idle,
        Skill,
    }

    public enum Layer
    {
        Monster = 8,
        Ground = 9,
        Block = 10,
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum UIEvent
    {
        Click,
        Drag,
    }

    public enum MouseEvent
    {
        Press,
        PointerDown,
        PointerUp,
        Click,
    }

    public enum CameraMode
    {
        QuarterView,
    }
    #endregion

    #region Core Names
    public const string NAME_MANAGERS = "@Managers";
    public const string NAME_UI_ROOT = "@UI_ROOT";
    public const string NAME_POOL_ROOT = "@Pool_Root";
    public const string NAME_EVENTSYSTEM = "@EventSystem";
    public const string NAME_SOUND = "@Sound";
    #endregion
    
    #region Core Values
    public const int UI_START_ORDER = 100;

    #endregion

    #region Contents Names
    public const string NAME_SPAWNINGPOOL = "@SpawningPool";
    public const string NAME_TIMEMANAGER = "@TimeManager";
    

    #endregion

    #region Contents Values

    

    #endregion
    

    #region Contents Enums
    public enum GameState
    {
        Idle,
        Play,
        Pause
    }
    
    public enum WorldObject
    {
        Unknown,
        Player,
        Monster,
    }

    public enum MonsterType
    {
        Monster,
        Halberdier
    }

    public enum MonsterState
    {
        Idle
    }
    #endregion
}
