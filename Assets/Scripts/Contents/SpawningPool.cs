using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class SpawningPool : MonoBehaviour
{
    //생성
    //주기적 생성 <-- 주기적 생성의 수치 조절
    //그럼 시간은 어쩔 TV?
    //이벤트 생성 
    
    

    public void SpawnMonster(Define.MonsterType type, Vector3 position, Transform parent = null)
    {
        string name = Enum.GetName(typeof(Define.MonsterType), type);
        GameObject monster = Managers.Resource.Instantiate(name, parent);

        monster.transform.position = position;
    }

    [Button]
    public void SpawnMonsterInCircleRange(Define.MonsterType type, float minRange, float maxRange, Transform parent = null)
    {
        float radius = UnityEngine.Random.Range(minRange, maxRange);
        float randomRadian = UnityEngine.Random.Range(0, 2f) * Mathf.PI;
        float xPos = Mathf.Cos(randomRadian) * radius;
        float yPos = Mathf.Sin(randomRadian) * radius; 
        
        SpawnMonster(type, new Vector3(xPos, yPos, 0f), parent);
    }
}
