using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Rendering;
using UnityEngine;

namespace Assets.Visors
{
    public class VisorInvisibilityManager : MonoBehaviour
    {
        // -- Editor
        public VisorMode visorOnlyVisibleTo;

        public MeshRenderer[] visibleMeshRenderers;
        public MeshRenderer[] highlightedMeshRenderers;

        public Material highlitingMaterial;

        [Header("References")]
        public VisorManager VisorManager;

        // -- Class
        private readonly Dictionary<MeshRenderer, Material> _highlightedMeshes = new Dictionary<MeshRenderer, Material>();

        void Start()
        {
            foreach (var highlightedMeshRenderer in highlightedMeshRenderers)
            {
                _highlightedMeshes.Add(highlightedMeshRenderer, highlightedMeshRenderer.material);
            }

            UpdateVisibility(VisorManager.VisorMode);
            VisorManager.OnVisorStateChange += UpdateVisibility;
        }

        protected virtual void UpdateVisibility(VisorMode visorMode)
        {
            foreach (var meshRenderer in visibleMeshRenderers)
            {
                meshRenderer.enabled = visorMode == visorOnlyVisibleTo;
            }

            foreach (var meshRenderer in _highlightedMeshes)
            {
                if (visorMode == visorOnlyVisibleTo)
                {
                    meshRenderer.Key.material = highlitingMaterial;
                }
                else
                {
                    meshRenderer.Key.material = meshRenderer.Value;
                }
            }
        }

        void OnDestroy()
        {
            VisorManager.OnVisorStateChange -= UpdateVisibility;
        }
    }
}