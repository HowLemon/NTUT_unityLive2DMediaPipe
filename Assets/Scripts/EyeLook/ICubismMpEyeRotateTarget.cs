using UnityEngine;


namespace Live2D.Cubism.Framework.MediaPipeControll.EyeRotate
{
    /// <summary>
    /// Target to look at.
    /// </summary>
    public interface ICubismMpEyeRotateTarget
    {
        /// <summary>
        /// Gets the position of the target.
        /// </summary>
        /// <returns>The position of the target in world space.</returns>
        Vector3 GetPosition();


        /// <summary>
        /// Gets whether the target is active.
        /// </summary>
        /// <returns><see langword="true"/> if the target is active; <see langword="false"/> otherwise.</returns>
        bool IsActive();
    }
}
