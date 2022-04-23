using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallLightningController : ActiveSkillController
{
    private BallLightning _ballLightning;
    private Vector3 _normalizedDirection;
    private float _duration;
    private float _tick;

    private CircleCollider2D _collider2D;
    
    //Damage
    private void Update()
    {
        if (_ballLightning == null)
        {
            Debug.Log("find skill object failed");
            return;
        }
        
        //Move
        transform.position += Time.deltaTime * Managers.Game.GameSpeed
                              * _ballLightning.ProjectileSpeed * _normalizedDirection;

        //Check Tick and Damage
        _tick -= Time.deltaTime;
        
        //Check Duration
        _duration -= Time.deltaTime;
        if (_duration <= 0)
        {
            Clear();
            Managers.Resource.Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (_tick > 0)
            return;

        if (other.tag == Define.NAME_TAG_MONSTER)
        {
            //TODO battler 데미지 check 사이클등등 아몰라
            Managers.Game.Battlers[other.gameObject].CurrentHp -= _ballLightning.Damage;
        }
    }


    public void Init(BallLightning ballLightning, Vector3 normalizedDirection)
    {
        Skill skill;
        
        _ballLightning = ballLightning;
        _tick = _ballLightning.TickInterval;
        _duration = _ballLightning.Duration;
        _normalizedDirection = normalizedDirection;
        
        if (_collider2D == null)
        {
            _collider2D = GetComponent<CircleCollider2D>();
            _collider2D.radius = _ballLightning.EffectRadius;
        }
    }

    public void Clear()
    {
        _ballLightning = null;
    }
}
