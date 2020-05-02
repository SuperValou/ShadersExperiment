using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LWRP;

namespace Assets.Scripts.Visors
{
    public class VisorSystem : MonoBehaviour
    {
        void Start()
        {
        
        }
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ActivateRadioVisor();
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Reset();
            }
        }

        private void ActivateRadioVisor()
        {
            print("Radio");
            
        }

        private void Reset()
        {
            print("Normal");
            
        }
    }
}
