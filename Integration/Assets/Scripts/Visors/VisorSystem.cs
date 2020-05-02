using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Rendering.LWRP;

namespace Assets.Scripts.Visors
{
    public class VisorSystem : MonoBehaviour
    {
        public Shader radioShader;
        public Camera eye;

        public ForwardRendererData renderData;

        // Update is called once per frame
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
            foreach (RenderObjects scriptableRendererFeature in renderData.rendererFeatures)
            {
                
            }

            print("Radio");
            eye.SetReplacementShader(radioShader, "");
            eye.cullingMask |= LayerMap.GetXRayLayer();
        }

        private void Reset()
        {
            print("Normal");
            eye.ResetReplacementShader();

            eye.cullingMask &= ~LayerMap.GetXRayLayer();
        }
    }

    public static class LayerMap
    {
        private const int XRayLayer = 10;

        public static LayerMask GetXRayLayer()
        {
            return new LayerMask()
            {
                value = 1 << 10
            };
        }
    }
}
