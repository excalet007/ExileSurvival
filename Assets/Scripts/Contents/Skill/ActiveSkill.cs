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

    public virtual void Cast()
    { }
}
