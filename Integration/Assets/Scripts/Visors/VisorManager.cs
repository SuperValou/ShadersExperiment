using System;
using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Rendering
{
    public class VisorManager : MonoBehaviour
    {
        public Material xrayPostProcessMaterial;
        
        [Header("References")]
        public AbstractInputManager inputManager;
        public Camera visorCamera;

        // --
        public VisorMode VisorMode { get; private set; }

        public event Action<VisorMode> OnVisorStateChange;
        

        void Update()
        {
            if (inputManager.XrayKeyDown())
            {
                if (VisorMode == VisorMode.Xray)
                {
                    visorCamera.ResetReplacementShader();
                    visorCamera.clearFlags = CameraClearFlags.Skybox;

                    VisorMode = VisorMode.Normal;
                }
                else
                {
                    visorCamera.SetReplacementShader(xrayPostProcessMaterial.shader, "");
                    visorCamera.clearFlags = CameraClearFlags.SolidColor;

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
