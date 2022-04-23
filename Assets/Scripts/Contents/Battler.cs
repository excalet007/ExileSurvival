using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Battler : MonoBehaviour
{
    public BattlerController Controller;
    
    public float MaxHp;
    public float CurrentHp;
    public float MoveSpeed;

    [ShowInInspector]
    public HashSet<ActiveSkill> ActiveSkills = new HashSet<ActiveSkill>();
    [ShowInInspector]
    public HashSet<SupportSkill> SupportSkills = new HashSet<SupportSkill>();
    
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        foreach (ActiveSkill activeSkill in ActiveSkills)
        {
            activeSkill.CurrentCooldown -= Time.deltaTime * Managers.Game.GameSpeed; //TODO GET COOL DOWN
            if (activeSkill.CurrentCooldown > 0)
                return;

            Cast.ActiveSkill(activeSkill);
            activeSkill.CurrentCooldown = activeSkill.Cooldown;
        }
    }


    public virtual void Init()
    {
        Controller = GetComponent<BattlerController>();
        
        CurrentHp = MaxHp;
        Managers.Game.Battlers.Add(gameObject, this);
    }
    public virtual void OnDestroy()
    {
        ActiveSkills.Clear();
        SupportSkills.Clear();
        
        Managers.Game.Battlers.Remove(gameObject);
    }
}
