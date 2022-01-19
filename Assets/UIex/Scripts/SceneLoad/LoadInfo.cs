public struct LoadInfo
{

    public LoadInfo(SceneNameEnum sceneName,float transitionTime,bool useTransition)
    {
        SceneName = sceneName;
        //TransEnum = transEnum;
        TransitionTime = transitionTime;
        UseTransition = useTransition;
    }
    
    public SceneNameEnum SceneName;
    //public TransitionEnum TransEnum;
    public float TransitionTime;
    public bool UseTransition;
}