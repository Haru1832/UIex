using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Assets.UIex.Scripts.Transition.ShaderFade;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadManager : Singleton<SceneLoadManager>
{
//     [SerializeField]
//     private Image 
     
     private FadeImage panel;

     public SceneMaterialProvider MaterialProvider { get; private set; }

     public bool IsTransition;
     
     private Fade _fade;

     private void Start()
     {
          MaterialProvider = GetComponent<SceneMaterialProvider>();
          panel = MaterialProvider.panel;
          _fade = panel.gameObject.GetComponent<Fade>();
     }

     public void LoadScene(String sceneName)
     {
          SceneManager.LoadScene(sceneName);
     }
     
     public void LoadScene(LoadInfo info,SimpleTransitionEnum TransEnum)
     {
          SetMaterialTexture(MaterialProvider.simpleMaterial,null);
          Type transType = TransDictionary[TransEnum];
          ITransition transObj = (ITransition)Activator.CreateInstance(transType,new object[] {info, panel });
          transObj.Transition();
     }

     public void LoadScene(LoadInfo info)
     {
          SetMaterialTexture(MaterialProvider.ruleMaterial,MaterialProvider.ruleTexture);
          StartCoroutine(LoadSceneCoroutine(info));
     }
     
     public void LoadScene(LoadInfo info,Sprite sprite)
     {
          SetMaterialTexture(MaterialProvider.ruleMaterial,sprite);
          StartCoroutine(LoadSceneCoroutine(info));
     }

     public IEnumerator LoadSceneCoroutine(LoadInfo info)
     {
          IsTransition = true;
          yield return _fade.FadeIn(info.TransitionTime);
          SceneManager.LoadScene(info.SceneName.ToString());
          yield return _fade.FadeOut(info.TransitionTime);
          IsTransition = false;

     }
     
     

     public void LoadAfterFade(LoadInfo info)
     {
          SceneManager.LoadScene(info.SceneName.ToString());
     }
     
     private Dictionary<SimpleTransitionEnum, Type> TransDictionary=new Dictionary<SimpleTransitionEnum, Type>()
     {
          {SimpleTransitionEnum.WhiteOut,typeof(WhiteFade)},
          {SimpleTransitionEnum.BlackOut,typeof(BlackFade)},
          {SimpleTransitionEnum.ColorOut,typeof(ColorFade)}
     };

     private void SetMaterialTexture(Material material,Sprite texture)
     {
          Image image = MaterialProvider.panel.image;
          image.material = material;
          image.sprite = texture;
     }
}
