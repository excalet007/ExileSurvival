using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BallLightning : ActiveSkill
{
    public float ProjectileSpeed;
    public float Duration;
    public float TickInterval;
    public float EffectRadius;
    public float Damage;
 
    public override void Init(Battler owner)
    {
        //base. owner,activeSkillType
        base.Init(owner);
        SkillTags = new HashSet<Define.SkillTag>()
            {Define.SkillTag.Spell, Define.SkillTag.Projectile, Define.SkillTag.AoE, Define.SkillTag.Lightning};

        //Skill
        SkillName = "BallLightning";
        Level = 1;
        
        //ActiveSkill 
        CastType = Define.CastType.VolleyShot;

        //BallLightning
        ProjectileSpeed = 2f;
        Duration = 3f;
        TickInterval = 0.15f;
        EffectRadius = 0.16f;
        Damage = 5f;
    }
}
