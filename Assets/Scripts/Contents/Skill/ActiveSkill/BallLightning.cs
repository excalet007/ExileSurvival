using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class BallLightning : ActiveSkill
{
    public float ProjectileSpeed;
    public float Duration;
    public float TickInterval;
    public float EffectRadius;
    public float Damage;
    public Define.ShootDirection ShootDirection;
 
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
        ShootDirection = Define.ShootDirection.Closest;
    }

    public override void Activate()
    {
        //GetNormalizeDirection
        Vector3 normalizedDirection = Vector3.zero;
        switch (ShootDirection)
        {
            case Define.ShootDirection.Move:
            case Define.ShootDirection.Random:
                normalizedDirection = Owner.Controller.LastMoveDirection.normalized;
                break;
            
            case Define.ShootDirection.Closest:  
                float xPos = Owner.transform.position.x;
                float yPos = Owner.transform.position.y;
                float halfWidth = 3f;
                float halfHeight = 3f;
                Vector2 leftBottom = new Vector2( xPos - halfWidth, yPos - halfHeight);
                Vector2 rightTop = new Vector2(xPos + halfWidth, yPos + halfHeight);

                Collider2D[] collider2Ds = Physics2D.OverlapAreaAll(leftBottom, rightTop);
        
                float closestDistance = Mathf.Infinity;
                Transform closetTarget = null;
        
                foreach (Collider2D collider2D in collider2Ds)
                {
                    if (collider2D.CompareTag(Define.NAME_TAG_MONSTER) == false)
                        continue;

                    float currentDistance = Vector3.Distance(Owner.transform.position, collider2D.transform.position);
                    if (currentDistance < closestDistance)
                    {
                        closestDistance = currentDistance;
                        closetTarget = collider2D.transform;
                    }
                }

                if (closetTarget != null)
                    normalizedDirection = (closetTarget.position - Owner.transform.position).normalized;
                break;
            
            case Define.ShootDirection.None:
            default:
                Debug.Log($"ShootDirection is wrong {ShootDirection}");
                break;
                
        }

        if (normalizedDirection == Vector3.zero)
        {
            CurrentCooldown = Define.VALUE_FAIL_COOLDOWN;
            return;
        }
        
        float offset = 0.5f;
        
        int projectileCount = 8; //TODO GET PROJECTILE
        int volleyDegree = 120;
        int unitDegree = volleyDegree / (projectileCount + 1);
        
        for (int i = 1; i <= projectileCount; i++)
        {
            GameObject skillObject = Managers.Resource.Instantiate($"Skill/{SkillName}");

            int angle = -(volleyDegree / 2) + unitDegree * i;
            if (ShootDirection == Define.ShootDirection.Random)
                angle = Random.Range(0, 360);
            
            Vector3 rotation = Quaternion.AngleAxis(angle, Vector3.forward) * normalizedDirection;
            skillObject.transform.position = Owner.transform.position + rotation * offset;
            
            skillObject.GetComponent<BallLightningController>().Init(this, rotation);
        }
        
        ResetCooldown();
    }
}
