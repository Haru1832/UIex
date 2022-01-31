using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SceneLoader))]
public class UseSceneLoad : MonoBehaviour
{
    private SceneLoader _loader;
    public enum HowToLoadEnum
    {
        ButtonClick,
        MouseLeftButtonClick,
        MouseRightButtonClick1,
    }

    [SerializeField] private HowToLoadEnum howToLoad;
    
    // Start is called before the first frame update
    void Awake()
    {
        _loader = GetComponent<SceneLoader>();
    }

    private void Start()
    {
        if (howToLoad == HowToLoadEnum.ButtonClick)
        {
            ButtonClick();
            return;
        }
    }


    void ButtonClick()
    {
        Button button;
        button = GetComponent<Button>();
        button.onClick.AddListener(_loader.LoadScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (howToLoad == HowToLoadEnum.MouseLeftButtonClick)
        {
            if(Input.GetMouseButtonDown(0))
                _loader.LoadScene();
        }
        else if (howToLoad == HowToLoadEnum.MouseRightButtonClick1)
        {
            if (Input.GetMouseButtonDown(1))
                _loader.LoadScene();
        }
    }
}
