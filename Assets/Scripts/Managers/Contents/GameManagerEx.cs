using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameManagerEx
{
    public Player Player;
    public HashSet<Monster> Monsters = new HashSet<Monster>();
    public Dictionary<GameObject, Battler> Battlers = new Dictionary<GameObject, Battler>();

    public Action<Monster> OnMonsterSpawn = null;
    public Action<Monster> OnMonsterDead = null;

    public Define.GameState State;
    public float GameSpeed = 1f;
    
    public void Init()
    {
        State = Define.GameState.Play;
    }

    public void Clear()
    {
        Monsters.Clear();
        Battlers.Clear();
        
        OnMonsterSpawn = null;
        OnMonsterDead = null;
    }

}
