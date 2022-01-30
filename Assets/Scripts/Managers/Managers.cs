using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Managers : MonoBehaviour
{
    //singleton
    static Managers instance;
    static Managers Instance { get { Init(); return instance; } }
    
    #region Contents
    GameManagerEx _game = new GameManagerEx();

    public static GameManagerEx Game {  get { return Instance._game; } }
    #endregion
    
    #region Core
    DataManager _data = new DataManager();
    InputManager _input = new InputManager();
    PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    SceneManagerEx _scene = new SceneManagerEx();
    SoundManager _sound = new SoundManager();
    UIManager _ui = new UIManager();

    public static DataManager Data { get { return Instance._data; } }
    public static InputManager Input { get { return Instance._input; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static SceneManagerEx Scene { get { return Instance._scene; } }
    public static SoundManager Sound { get { return Instance._sound; } }
    public static UIManager UI { get { return Instance._ui; } }
    #endregion

    #region MonoBehaviour
    void Update()
    {
        _input.OnUpdate();
    }


    #endregion
    
    
    #region Init, Clear
    static void Init()
    {
        if (instance == null)
        {
            GameObject go = GameObject.Find($"{Define.NAME_MANAGERS}");
            if (go == null)
            {
                go = new GameObject{name = Define.NAME_MANAGERS};
                go.AddComponent<Managers>();
            }
            
            DontDestroyOnLoad(go);
            
            instance = go.GetComponent<Managers>();

            instance._data.Init();
            instance._pool.Init();
            instance._sound.Init();
        }
    }

    public static void Clear()
    {
        Input.Clear();
        Sound.Clear();
        Scene.Clear();
        UI.Clear();
        Pool.Clear();
    }
    #endregion
}