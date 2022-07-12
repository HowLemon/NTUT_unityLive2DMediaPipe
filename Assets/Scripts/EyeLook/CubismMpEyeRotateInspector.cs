using Live2D.Cubism.Framework.MediaPipeControll.EyeRotate;
using UnityEditor;

using Object = UnityEngine.Object;


namespace Live2D.Cubism.Editor.Inspectors
{
#if UNITY_EDITOR
    [CustomEditor(typeof(CubismMpEyeRotateController))]
    internal sealed class CubismMpEyeRotateControllerInspector : UnityEditor.Editor
    {
        #region Editor

        public override void OnInspectorGUI()
        {
            var controller = target as CubismMpEyeRotateController;


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
