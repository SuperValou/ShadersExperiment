using UnityEngine;

namespace Assets.Scripts.Rendering
{
//    [ExecuteInEditMode]
    public class PostProcessor : MonoBehaviour
    {
        public Material postProcessMaterial;

        void Start()
        {
            
        }

        private bool xrayEnabled = false;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (xrayEnabled)
                {
                    Camera.main.ResetReplacementShader();
                    Camera.main.clearFlags = CameraClearFlags.Skybox;
                }
                else
                {
                    Camera.main.SetReplacementShader(postProcessMaterial.shader, "");
                    Camera.main.clearFlags = CameraClearFlags.SolidColor;
                }

                xrayEnabled = !xrayEnabled;
            }
        }

        //void OnRenderImage(RenderTexture src, RenderTexture dest)
        //{
        //    Graphics.Blit(src, dest, postProcessMaterial);
        //}
    }
}
