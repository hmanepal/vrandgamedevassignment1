using UnityEngine;
using TMPro; // If you need to manipulate TextMeshPro objects

public class TargetManager : MonoBehaviour
{
    public Transform targetPlane; // Reference to the Plane object
    public Transform canvas; // Reference to the Canvas or UI that needs to be aligned
    public float distanceFromCamera = 10f; // Distance from the camera for the target
    public float canvasDistanceFromCamera = 2f; // Distance from the camera for the UI canvas (optional)

    void Start()
    {
        AlignTargetWithCamera();
        AlignCanvasWithCamera();
    }

    private void AlignTargetWithCamera()
    {
        if (targetPlane != null)
        {
            // Set the plane's position directly in front of the camera
            targetPlane.position = Camera.main.transform.position + Camera.main.transform.forward * distanceFromCamera;

            // Rotate the plane to be vertical and face the camera
            targetPlane.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

            // Apply an additional rotation of 90 degrees around the X-axis to make the plane vertical
            targetPlane.Rotate(90f, 0f, 0f);
        }
    }

    private void AlignCanvasWithCamera()
    {
        if (canvas != null)
        {
            // Position the canvas directly in front of the camera but closer than the plane
            canvas.position = Camera.main.transform.position + Camera.main.transform.forward * canvasDistanceFromCamera;

            // Rotate the canvas to face the camera
            canvas.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

            // Optionally, you can further adjust the rotation to ensure the canvas is upright
            // canvas.Rotate(0f, 0f, 0f); // Uncomment and adjust if necessary for fine-tuning
        }
    }
}
