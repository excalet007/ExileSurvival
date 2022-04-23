using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Cast 
{
    public static void ActiveSkill(ActiveSkill skill)
    {
        switch (skill.CastType)
        {
            case Define.CastType.VolleyShot:
                CastVolleyShot(skill);
                break;
            
            case Define.CastType.None:
            default:
                Debug.Log($"check {skill.CastType}");
                break;
            
            
        }
    }

    
    //TODO get projectileCount ,get cast count, homing or not
    public static void CastVolleyShot(ActiveSkill skill)
    {
        Vector3 normalizedMoveDirection = skill.Owner.Controller.LastMoveDirection;
        
        float offset = 0.5f;
        
        //TODO YIELD return 
        
        int projectileCount = 5;
        int volleyDegree = 120;
        int unitDegree = volleyDegree / (projectileCount + 1);
        
        for (int i = 1; i <= projectileCount; i++)
        {
            GameObject skillObject = Managers.Resource.Instantiate($"Skill/{skill.SkillName}");
            Vector3 rotation = Quaternion.AngleAxis(-(volleyDegree/2) + unitDegree * i, Vector3.forward) * normalizedMoveDirection;
            skillObject.transform.position = skill.Owner.transform.position + rotation * offset;
            
            skillObject.GetComponent<BallLightningController>().Init(skill as BallLightning, rotation);
        }
        
    }
}
