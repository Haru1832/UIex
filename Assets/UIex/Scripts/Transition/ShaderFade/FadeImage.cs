using UnityEngine;
using UnityEngine.UI;

namespace Assets.UIex.Scripts.Transition.ShaderFade
{
    public class FadeImage : MonoBehaviour,IFade
    {
        [Range(0,1)] private float RangeValue;
        //[SerializeField] private Texture _texture;

        private Material material;
        private Color color;
        public Image image { get; set; }
        public float Range
        {
            get { return RangeValue; }
            set
            {
                RangeValue = value;
                UpdateValue(RangeValue);
            }
        }


        private void Awake()
        {
            image= GetComponent<Image>();
            material = image.material;
            color = image.color;
        }

        void UpdateValue(float value)
        {
            material.SetFloat("_Alpha",value);
        }
        
        void UpdateTexture()
        {
            material.SetColor("_Color",color);
            //material.SetTexture("_MainTex",_texture);
        }
        
//        protected override void OnValidate ()
//        {
//            base.OnValidate ();
//            UpdateValue (Range);
//            UpdateTexture ();
//        }
//        
    }
}
