using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The target object the camera should follow (usually the player).
    public Transform target;

    // The offset of the camera relative to the target.
    public Vector3 offset;

    // Smoothness of the camera movement.
    [Range(0, 1)]
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("CameraFollow: Target is not assigned!");
            return;
        }

        // Desired position of the camera.
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between current position and desired position.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the camera's position.
        transform.position = smoothedPosition;
    }
}

