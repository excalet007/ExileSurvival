using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MonsterController : MonoBehaviour
{
    protected Monster _monster;
    protected Vector3 _destPos;
    protected GameObject _lockTarget;
    protected Animator _animator;

    public Queue<(Define.MonsterAction, float)> actionQueue = new Queue<(Define.MonsterAction, float)>();
    public float actionTimer = 0f;
    
    protected Define.MonsterState _state = Define.MonsterState.Idle;
    public Define.WorldObject WorldObjectType { get; protected set; } = Define.WorldObject.Unknown;
    
    public virtual Define.MonsterState State
    {
        get { return _state; }
        set
        {
            if (_state == value)
                return;
            
            switch (_state)
            {
                case Define.MonsterState.Idle:
                    break;
                
                case Define.MonsterState.Action:
                    break;
                
                case Define.MonsterState.Stun:
                    break;
                
                case Define.MonsterState.Die:
                    break;
            }
            _state = value;
        }
    }

    #region MonoBehaviour
    void Update()
    {
        if (Managers.Game.State != Define.GameState.Play)
            return;
        
        switch (State)
        {
            case Define.MonsterState.Idle:
                UpdateIdle();
                break;
            
            case Define.MonsterState.Action:
                UpdateAction();
                break;
            
            case Define.MonsterState.Stun:
                UpdateStun();
                break;
            
            case Define.MonsterState.Die:
                UpdateDie();
                break;
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (Managers.Game.State != Define.GameState.Play)
            return;
        
        if (other.transform.CompareTag(Define.NAME_TAG_PLAYER))
        {
            //TODO DO DAMAGE
            _monster.OnDestroy();
        };
    }
    #endregion

    #region UpdateFunctions

    protected virtual void UpdateDie() { }

    protected virtual void UpdateAction()
    {
        if (actionQueue.Count <= 0)
            return;
        
        switch (actionQueue.Peek().Item1)
        {
            case Define.MonsterAction.PermanentChase:
                Move((_lockTarget.transform.position - transform.position).normalized);
                break;
            
            case Define.MonsterAction.Chase:
                Move((_lockTarget.transform.position - transform.position).normalized);
                actionTimer += Time.deltaTime;
                break;
            
            case Define.MonsterAction.Retreat:
                Move((_lockTarget.transform.position - transform.position).normalized* -1f) ;
                actionTimer += Time.deltaTime;
                break;
        }

        // if (actionTimer > 0f)
        //     actionQueue.Dequeue();
    }
    protected virtual void UpdateIdle() { }
    protected virtual void UpdateStun() {}


    

    #endregion
    

    #region methods
   
    public virtual void Init()
    {
        _animator = GetComponent<Animator>();
        _monster = GetComponent<Monster>();
        
        _state = Define.MonsterState.Action;
        
        actionQueue = new Queue<(Define.MonsterAction, float)>();
        actionTimer = 0f;

        _lockTarget = Managers.Game.Player.gameObject;
        
        //TODO Wourld object type이 꼭 필요할까?
        WorldObjectType = Define.WorldObject.Monster;
        
        actionQueue.Clear();
        actionQueue.Enqueue((Define.MonsterAction.PermanentChase, 1f));
        
        // //TODO UI_BAR가 꼭 필요할까? 존나필요함
        // if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
        //     Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
    }

    protected virtual void ChangeAnimationState(string animationName)
    {
        _animator.Play($"anim_{name}_{animationName}");
    }
    protected virtual void Move(Vector2 dir)
    {
        transform.Translate(dir * _monster.MoveSpeed * Time.deltaTime);
    }
    
    
    #endregion
}
