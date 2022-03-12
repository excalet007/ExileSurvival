using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MonsterController : MonoBehaviour
{
    protected Vector3 _destPos;
    protected GameObject _lockTarget;
    
    protected Define.MonsterState _state = Define.MonsterState.Idle;
    public Define.WorldObject WorldObjectType { get; protected set; } = Define.WorldObject.Unknown;
    

    public virtual Define.MonsterState State
    {
        get { return _state; }
        set
        {
            //TODO
            Animator anim = GetComponent<Animator>();
            switch (_state)
            {
                case Define.MonsterState.Idle:
                    //anim.CrossFade("WAIT", 0.1f);
                    break;
                
            }
        }
    }

    #region MonoBehaviour
    private void Start()
    {
        Init();
    }

    void Update()
    {
        switch (State)
        {
            case Define.MonsterState.Idle:
                UpdateIdle();
                break;
        }
    }

    #endregion
   
    public void Init()
    {
        WorldObjectType = Define.WorldObject.Monster;
        
        //TODO check this
        //_stat = gameObject.GetComponent<Stat>();

        if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
    }


    protected virtual void UpdateDie() { }
    protected virtual void UpdateMoving() { }
    protected virtual void UpdateIdle() { }
    protected virtual void UpdateSkill() { }
}
