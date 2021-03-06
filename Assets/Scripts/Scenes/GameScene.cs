using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
        //TODO Managers.UI.ShowSceneUI<UI_Inven>();
        
        //spawn player, monster
        Managers.Game.Init();
        Managers.Time.Init();
        
        GameObject player = Managers.Resource.Instantiate("Player");
        Managers.Game.Player = player.GetComponent<Player>();
        
        
        //add ballLightning
        BallLightning ballLightning = new BallLightning();
        ballLightning.Cooldown = 1.5f; //TODO load from data
        ballLightning.Init(Managers.Game.Player);

        Managers.Game.Player.ActiveSkills.Add(ballLightning);
        
        
        CameraController camera = Camera.main.transform.gameObject.AddComponent<CameraController>();
        camera.camera = Camera.main;
        camera.SetFollow(player.transform);

        //input controller
        Managers.Input.keyAction += () =>
        {
            Vector3 move = Vector3.zero;
            float speed = 1f;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                move += Vector3.up * speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow))
                move += Vector3.down * speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
                move += Vector3.left * speed * Time.deltaTime;
            if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
                move += Vector3.right * speed * Time.deltaTime;

            Managers.Game.Player.transform.position += move;
            
            if(move != Vector3.zero)
                Managers.Game.Player.Controller.LastMoveDirection = move;

            SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
            if (move.x < 0f)
                spriteRenderer.flipX = true;
            else if (move.x > 0f)
                spriteRenderer.flipX = false;
        };
        
    } 
    
    public override void Clear()
    {
        
    }
}
