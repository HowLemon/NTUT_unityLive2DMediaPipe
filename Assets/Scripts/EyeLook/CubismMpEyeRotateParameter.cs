using Live2D.Cubism.Core;
using UnityEngine;

namespace Live2D.Cubism.Framework.MediaPipeControll.EyeRotate
{

    public class CubismMpEyeRotateParameter : MonoBehaviour
    {
        [SerializeField]
        public float Factor;

        [SerializeField]
        public CubismMpEyeAxis Axis;

        #region Unity Event Handling

        private void Reset()
        {
            var parameter = GetComponent<CubismParameter>();

            
            // Fail silently.
            if (parameter == null)
            {
                return;
            }


            // Guess axis.
            if (parameter.name.EndsWith("Y"))
            {
                Axis = CubismMpEyeAxis.Y;
            }
            else
            {
                Axis = CubismMpEyeAxis.X;
            }
            

            // Guess factor.
            Factor = parameter.MaximumValue;
        }

        #endregion

        #region Interface for Controller

        internal float TickAndEvaluate(Vector3 targetOffset)
        {
            
            var result = (Axis == CubismMpEyeAxis.X)
                ? targetOffset.x
                : targetOffset.y;




            return result * Factor;
        }

        #endregion
    }
}
