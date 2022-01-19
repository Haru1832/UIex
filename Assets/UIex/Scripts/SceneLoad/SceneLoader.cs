using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ステージのシーンをAdditiveで読み込む
/// 
/// 読み込むシーンの指定は、あらかじめ作っておいたEnumで行う
/// https://gist.github.com/negitamago/79688071f55e0a0537e2deac00f3102c
/// </summary>
public class SceneLoader : MonoBehaviour
{

    
    [HideInInspector] public bool useSimpleTransition =false;
    [HideInInspector] public SimpleTransitionEnum simpleTransitionEnum = SimpleTransitionEnum.WhiteOut;
    [HideInInspector] public float transitionTime=2;
    [HideInInspector] public bool useTransition = true;
    [HideInInspector] public bool useSceneIndex = true;
    [HideInInspector] public SceneNameEnum loadSceneName;

    [SerializeField] private Sprite OriginalSprite;
    
    
//    public bool useSimpleTransition { get; set; } = false;
//    public SimpleTransitionEnum simpleTransitionEnum { get; set; } = SimpleTransitionEnum.WhiteOut; 
//    public float transitionTime { get; set; }=2;
//    [SerializeField]public bool useTransition = true;
//    public bool useSceneIndex { get; set; }= true;
//    

    
    
    
    private SceneLoadManager _loadManager;

    // 読み込むシーンを記憶する static フィールド
    public static SceneNameEnum SCENE_INDEX;

    // インスペクターから読み込むシーンを指定する
    //[SerializeField] public SceneNameEnum loadSceneName;

    void Start()
    {
        _loadManager = SceneLoadManager.Instance;
    }

    public void LoadScene ()
    {
        LoadInfo loadInfo = new LoadInfo
        {
            SceneName = useSceneIndex ? loadSceneName : SCENE_INDEX,
            TransitionTime = transitionTime,
            UseTransition = useTransition
        };
        if (!loadInfo.UseTransition)
        {
            _loadManager.LoadScene(loadInfo.ToString());
            return;
        }
        
        if (useSimpleTransition)
        {
            _loadManager.LoadScene(loadInfo, simpleTransitionEnum);
        }
        else if (OriginalSprite!=null)
        {
            _loadManager.LoadScene(loadInfo,OriginalSprite);
        }
        else
        {
            _loadManager.LoadScene(loadInfo);
        }



    }
}

