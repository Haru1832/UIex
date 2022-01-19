using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//参照->https://gamedev.stackexchange.com/questions/184826/efficient-way-to-implement-a-lot-of-singletons/184829#184829


public abstract class Singleton<T> : MonoBehaviour where T :Singleton<T>
{
    public static T Instance { get; private set; }

    private void Awake() {

        if(Instance != null) {
//            Debug.LogErrorFormat("Two copies of singleton {0} in the scene: ({1}, {2}). Please ensure only one is present.", 
//                (typeof(T)).FullName, Instance.name, name);
            Destroy(gameObject);
            return;
        }

        Instance = (T)this;
        DontDestroyOnLoad(gameObject);
    }
}
