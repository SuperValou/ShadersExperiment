using UnityEngine;

namespace Assets.Scripts.Rendering
{
    [ExecuteInEditMode]
    public class PostProcessor : MonoBehaviour
    {
        public Material postProcessMaterial;

        void Start()
        {
            Camera.main.SetReplacementShader(postProcessMaterial.shader, "");
        }

        //void OnRenderImage(RenderTexture src, RenderTexture dest)
        //{
        //    Graphics.Blit(src, dest, postProcessMaterial);
        //}
    }
}
