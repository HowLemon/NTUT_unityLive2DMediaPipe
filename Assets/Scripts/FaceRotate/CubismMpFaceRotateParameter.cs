using Live2D.Cubism.Core;
using UnityEngine;

namespace Live2D.Cubism.Framework.MediaPipeControll.FaceRotate
{

    public class CubismMpFaceRotateParameter : MonoBehaviour
    {
        [SerializeField]
        public float Factor;

        [SerializeField]
        public CubismMpFaceAxis Axis;

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
                Axis = CubismMpFaceAxis.Y;
            }
            else if (parameter.name.EndsWith("Z"))
            {
                Axis = CubismMpFaceAxis.Z;
            }
            else
            {
                Axis = CubismMpFaceAxis.X;
            }
            

            // Guess factor.
            Factor = parameter.MaximumValue;
        }

        #endregion

        #region Interface for Controller

        internal float TickAndEvaluate(Vector3 targetOffset)
        {
            
            var result = (Axis == CubismMpFaceAxis.X)
                ? targetOffset.x
                : targetOffset.y;


            if (Axis == CubismMpFaceAxis.Z)
            {
                result = targetOffset.z;
            }


            return result * Factor;
        }

        #endregion
    }
}
