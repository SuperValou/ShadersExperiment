using UnityEngine;

namespace UnityTemplateProjects
{
    public class Visor : MonoBehaviour
    {
        public bool visorIsActive = false;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                if (visorIsActive)
                {
                    DeactivateVisor();
                }
                else
                {
                    ActivateVisor();
                }

                visorIsActive = !visorIsActive;
            }
        }

        private void ActivateVisor()
        {

        }

        private void DeactivateVisor()
        {

        }
    }
}