using System.Collections;
using System.Collections.Generic;
using Assets.UIex.Scripts.Transition.ShaderFade;
using UnityEngine;
using UnityEngine.UI;

public class SceneMaterialProvider : MonoBehaviour
{
    [SerializeField] private FadeImage _fadePanel;

    public FadeImage panel => _fadePanel;
    

    [SerializeField] private Sprite _RuleTexture;

    public Sprite ruleTexture => _RuleTexture;
    
    [SerializeField] private Material _simpleMaterial;

    public Material simpleMaterial => _simpleMaterial;
    
    [SerializeField] private Material _ruleMaterial;

    public Material ruleMaterial => _ruleMaterial;
    
}
