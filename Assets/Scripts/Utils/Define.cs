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

    public const string NAME_TAG_PLAYER = "Player";
    public const string NAME_TAG_MONSTER = "Monster";
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
        Ghost,
        Skull,
        BurningSkull,
        Demon,
        HellHound,
        Nightmare,
        GreyWolf,
        WhiteWolf
    }

    public enum MonsterState
    {
        Idle,
        Action,
        Stun,
        Die,  
    }

    public enum MonsterAction
    {
        PermanentChase,
        Chase,
        Retreat
    }

    public enum SkillTag
    {
        Attack,Melee,Strike,Slam,Warcry,Spell,Arcane,Brand,Orb,Nova,Channelling,Physical,Fire,Cold,Lightning,Chaos,Bow,
        Projectile, Chaining,Prismatic,Minion,Mine,Trap,Totem,Golem,Aura,Herald, Stance,Guard,Movement,Travel,Blink,
        Curse,Hex,Mark,AoE,Duration,Vaal,Trigger,Critical,Link, Support,Exceptional,Blessing
    }
    
    public enum SkillType
    {
        None,
        Active,
        Support
    }

    public enum CastType
    {
        None,
        VolleyShot,
        
    }
    
    public enum ShootDirection
    {
        None,
        Random,
        HomingClosest,
        CasterMoveDirection180
    }
    
    #endregion
}
