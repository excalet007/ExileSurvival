using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Monster : Battler
{
    public MonsterController monsterController;

    public override void Init()
    {
        monsterController = GetComponent<MonsterController>();
        monsterController.Init();

        Managers.Game.Monsters.Add(this);
    }

    public void OnDestroy()
    {
        Managers.Game.Monsters.Remove(this);
        Managers.Resource.Destroy(gameObject);
    }
} 
