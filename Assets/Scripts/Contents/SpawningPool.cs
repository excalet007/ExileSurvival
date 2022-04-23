using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class SpawningPool : MonoBehaviour
{

    IEnumerator SpawnRoutine(float delay)
    {
        while (true)
        {
            if (Managers.Game.State != Define.GameState.Play)
            {
                yield return new WaitForSeconds(delay);
                continue;
            }
            
            //TODO stop when finish
            //delay를 game state에서 컨트롤 하는걸로.

            if (Managers.Game.Monsters.Count <= 200)
            {
                SpawnMonsterInCircleRange(Define.MonsterType.Ghost, 5f, 6f);
            }
            
            yield return new WaitForSeconds(delay);
        }
    }
    
    private void Start()
    {
        StartCoroutine(SpawnRoutine(0.5f));
    }


    public void SpawnMonster(Define.MonsterType type, Vector3 position, Transform parent = null)
    {
        string name = Enum.GetName(typeof(Define.MonsterType), type);
        GameObject monster = Managers.Resource.Instantiate(name, parent);

        monster.transform.position = position;

        Managers.Game.Monsters.Add(monster.GetComponent<Monster>());
    }

    [Button]
    public void SpawnMonsterInCircleRange(Define.MonsterType type, float minRange, float maxRange, Transform parent = null)
    {
        float radius = UnityEngine.Random.Range(minRange, maxRange);
        float randomRadian = UnityEngine.Random.Range(0, 2f) * Mathf.PI;
        float xPos = Mathf.Cos(randomRadian) * radius;
        float yPos = Mathf.Sin(randomRadian) * radius;

        Vector3 position = new Vector3(Managers.Game.Player.transform.position.x + xPos,
            Managers.Game.Player.transform.position.y + yPos, 0f);
        SpawnMonster(type, position, parent);
    }
}
