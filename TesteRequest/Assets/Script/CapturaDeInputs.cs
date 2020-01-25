using UnityEngine;

namespace Assets
{
    public class CapturaDeInputs : MonoBehaviour
    {

        public float Vertical { get; private set; }
        public float Horizontal { get; private set; }

        private void FixedUpdate()
        {
                Vertical = Input.GetAxisRaw("Vertical");
                Horizontal = Input.GetAxisRaw("Horizontal");
            
        }
    }
}
