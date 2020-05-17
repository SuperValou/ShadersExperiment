using System;
using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Rendering
{
    public class VisorManager : MonoBehaviour
    {
        public Shader xrayReplacementShader;
        
        [Header("References")]
        public AbstractInputManager inputManager;
        public Camera playerEyes;
        public Camera weakpointHighlightCamera;

        // --
        public VisorMode VisorMode { get; private set; }

        public event Action<VisorMode> OnVisorStateChange;

        void Start()
        {
            if (weakpointHighlightCamera.clearFlags != CameraClearFlags.Depth)
            {
                Debug.LogWarning($"Weakpoint highlighting camera has ClearFlags set to {weakpointHighlightCamera.clearFlags}");
            }
        }

        void Update()
        {
            if (inputManager.XrayKeyDown())
            {
                if (VisorMode == VisorMode.Xray)
                {
                    playerEyes.ResetReplacementShader();
                    playerEyes.clearFlags = CameraClearFlags.Skybox;

                    weakpointHighlightCamera.gameObject.SetActive(false);

                    VisorMode = VisorMode.Normal;
                }
                else
                { 
                    playerEyes.SetReplacementShader(xrayReplacementShader, string.Empty);
                    playerEyes.clearFlags = CameraClearFlags.SolidColor;
                    
                    weakpointHighlightCamera.gameObject.SetActive(true);

                    VisorMode = VisorMode.Xray;
                }

                OnVisorStateChange?.Invoke(VisorMode);
            }
        }

        //void OnRenderImage(RenderTexture src, RenderTexture dest)
        //{
        //    Graphics.Blit(src, dest, postProcessMaterial);
        //}
    }
}
