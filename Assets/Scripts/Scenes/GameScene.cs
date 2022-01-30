using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;
        //Managers.UI.ShowSceneUI<UI_Inven>();
        //TODO
        //import data, controller, camera, character, spawn
    } 
    
    public override void Clear()
    {
        
    }
}
