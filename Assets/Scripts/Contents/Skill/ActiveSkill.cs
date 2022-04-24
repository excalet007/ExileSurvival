using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : Skill
{
    public Define.CastType CastType = Define.CastType.None;
    public float Cooldown;
    public float CurrentCooldown = 0f;
    
    public virtual void Init(Battler owner)
    {
        Owner = owner;
        SkillType = Define.SkillType.Active;
    }

    public virtual void Activate()
    { }

    public virtual bool OnCooldown()
    {
        CurrentCooldown -= Time.deltaTime * Managers.Game.GameSpeed; 
        
        if (CurrentCooldown < 0)
            return false;
        
        return true;
    }

    public virtual void ResetCooldown()
    {
        CurrentCooldown = Cooldown;
    }

}
