using System;
using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Rendering
{
    public class VisorManager : MonoBehaviour
    {
        public Shader xrayReplacementShader;
        public Shader weakpointHighlightReplacementShader;
        
        [Header("References")]
        public AbstractInputManager inputManager;

        public Camera playerEyes;
        public Camera weakpointHighlightCamera;

        // --
        public VisorMode VisorMode { get; private set; }

        public bool VisorStateChange { get; private set; }

        void Start()
        {
            if (weakpointHighlightCamera.clearFlags != CameraClearFlags.Depth)
            {
                Debug.LogWarning($"Camera '{weakpointHighlightCamera.name}' should have Clear Flags set to '{CameraClearFlags.Depth}', " +
                                 $"but has '{weakpointHighlightCamera.clearFlags}' instead.");
            }

            weakpointHighlightCamera.SetReplacementShader(weakpointHighlightReplacementShader, string.Empty);
        }

        void Update()
        {
            VisorStateChange = false;

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

                VisorStateChange = true;
            }
        }

        //void OnRenderImage(RenderTexture src, RenderTexture dest)
        //{
        //    Graphics.Blit(src, dest, postProcessMaterial);
        //}
    }
}
