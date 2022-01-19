

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;


namespace Assets.UIex.Editor
{
    [CustomEditor(typeof(SceneLoader))]
    public class SceneLoaderEditor : UnityEditor.Editor
    {
        private SceneLoader _target;
        bool isSceneInfoOpen=true;
        bool isTransitionInfoOpen=true;
        
        private void Awake()
        {
            _target = target as SceneLoader;
        }

        public override void OnInspectorGUI()
        {


             EditorGUI.BeginChangeCheck();


            isSceneInfoOpen = EditorGUILayout.BeginFoldoutHeaderGroup(isSceneInfoOpen, "SceneInfo"); 
            

            
            //EditorGUILayout.LabelField("SceneInfo",EditorStyles.boldLabel);

            if (isSceneInfoOpen)
            {
//                EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
//                {
//                    UnityEditor.EditorGUILayout.LabelField("    useSceneIndex");
//                    _target.useSceneIndex = EditorGUILayout.Toggle(_target.useSceneIndex);
//                }
//                EditorGUILayout.EndHorizontal();
                
                //_target.useSimpleTransition = EditorGUILayout.Toggle("    useSimpleTransition", _target.useSimpleTransition);
                
                using (var isUseIndex = new EditorGUILayout.ToggleGroupScope("useSceneIndex", _target.useSceneIndex))
                {
                    _target.useSceneIndex = isUseIndex.enabled;
                    _target.loadSceneName = (SceneNameEnum) EditorGUILayout.EnumPopup("    LoadSceneName", _target.loadSceneName);
                    
                }
            }
            
            EditorGUILayout.EndFoldoutHeaderGroup();
            
            
            
            
            
            isTransitionInfoOpen = EditorGUILayout.BeginFoldoutHeaderGroup(isTransitionInfoOpen, "TransitionInfo");


            if (isTransitionInfoOpen)
            {
                
                using (var UseTransition = new EditorGUILayout.ToggleGroupScope("useTransition", _target.useTransition))
                {
                    _target.useTransition = UseTransition.enabled;
                    
                    //_target.loadSceneName = (SceneNameEnum) EditorGUILayout.EnumPopup("    LoadSceneName", _target.loadSceneName);

                    _target.transitionTime = EditorGUILayout.FloatField("TransitionTime", _target.transitionTime);
                    
                    base.OnInspectorGUI();
                    
                    using (var isUseSimpleTransition =
                        new EditorGUILayout.ToggleGroupScope("useSimpleTransition", _target.useSimpleTransition))
                    {
                        _target.useSimpleTransition = isUseSimpleTransition.enabled;

                        _target.simpleTransitionEnum =
                            (SimpleTransitionEnum) EditorGUILayout.EnumPopup("SimpleTransition",
                                _target.simpleTransitionEnum);
                    }

                }

                //EditorGUILayout.LabelField("TransitionInfo",EditorStyles.boldLabel);

//                EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
//                {
//                    UnityEditor.EditorGUILayout.LabelField("    useTransition");
//                    _target.useTransition = EditorGUILayout.Toggle(_target.useTransition);
//
//                }
//                EditorGUILayout.EndHorizontal();

//                if (_target.useTransition)
//                {
//                    _target.transitionTime = EditorGUILayout.FloatField("    TransitionTime", _target.transitionTime);
//
//                    EditorGUILayout.BeginHorizontal(GUILayout.ExpandWidth(true));
//                    {
//                        UnityEditor.EditorGUILayout.LabelField("    useSimpleTransition");
//                        _target.useSimpleTransition =
//                            EditorGUILayout.Toggle(_target.useSimpleTransition);
//                    }
//                    EditorGUILayout.EndHorizontal();
//
//                    if (_target.useSimpleTransition)
//                    {
//                        _target.simpleTransitionEnum =
//                            (SimpleTransitionEnum) EditorGUILayout.EnumPopup("        SimpleTransition",
//                                _target.simpleTransitionEnum);
//                    }
//                }
            }
            
            EditorGUILayout.EndFoldoutHeaderGroup();
            

// GUIの更新があったら実行
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(_target);
            }
        }
    }
}
#endif
