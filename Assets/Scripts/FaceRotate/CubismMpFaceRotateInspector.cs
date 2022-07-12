using Live2D.Cubism.Framework.MediaPipeControll.FaceRotate;
using UnityEditor;

using Object = UnityEngine.Object;


namespace Live2D.Cubism.Editor.Inspectors
{
#if UNITY_EDITOR
    [CustomEditor(typeof(CubismMpFaceRotateController))]
    internal sealed class CubismMpFaceRotateControllerInspector : UnityEditor.Editor
    {
        #region Editor

        public override void OnInspectorGUI()
        {
            var controller = target as CubismMpFaceRotateController;


            // Fail silently.
            if (controller == null)
            {
                return;
            }


            EditorGUI.BeginChangeCheck();


            // Draw default inspector.
            base.OnInspectorGUI();


            // Draw target.
            controller.Target = EditorGUILayout.ObjectField("Target", controller.Target, typeof(Object), true);


            // Apply changes.
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(controller);
            }
        }

        #endregion
    }
#endif
}
