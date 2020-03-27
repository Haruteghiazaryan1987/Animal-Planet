using UnityEngine;

namespace Scrips
{
    public class ImageLoadingScript : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private float speed = 5;
    
        void Start(){
            _rectTransform = gameObject.GetComponent<RectTransform>();
        }

        void Update(){
            _rectTransform.Rotate(new Vector3(0, 0, speed));
        }
    }
}
