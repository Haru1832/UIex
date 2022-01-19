using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.UIex.Scripts.Transition.ShaderFade
{
    public class Fade : MonoBehaviour
    {
        private IFade _fade;

        private void Start()
        {
            _fade = GetComponent<IFade>();
        }


        private IEnumerator FadeInCoroutine(float time)
        {
            float current = 0;
            while (current < time)
            {
                _fade.Range = current / time;
                yield return new WaitForEndOfFrame();
                current += Time.deltaTime;
            }

            _fade.Range = 1;
        }
        
        
        private IEnumerator FadeOutCoroutine(float time)
        {
            float current = time;
            while (current >= 0)
            {
                _fade.Range = current / time;
                yield return new WaitForEndOfFrame();
                current -= Time.deltaTime;
            }

            _fade.Range = 0;
        }

        public Coroutine FadeIn(float time)
        {
            return StartCoroutine(FadeInCoroutine(time));
        }
        
        public Coroutine FadeOut(float time)
        {
            return StartCoroutine(FadeOutCoroutine(time));
        }
    }
}
