using System.Collections;
using System.Collections.Generic;
using Assets.UIex.Scripts.Transition.ShaderFade;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ColorFade : ITransition
{
    LoadInfo Info;
    FadeImage Panel;
    private Image image;

    private SceneLoadManager loadManager;
    
    public ColorFade(LoadInfo info,FadeImage panel)
    {
        Info = info;
        Panel = panel;
    }
    
    public void Transition()
    {
        loadManager = SceneLoadManager.Instance;
        loadManager.IsTransition = true;
        Panel.image.DOFade(1, Info.TransitionTime)
            .OnComplete(AfterFade);

    }

    private void AfterFade()
    {
        loadManager.IsTransition = false;
        loadManager.LoadAfterFade(Info);
        Panel.image.DOFade(0, Info.TransitionTime);
    }
}
