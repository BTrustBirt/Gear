using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform target; // Object around which the camera will rotate
    public float rotationSpeed = 3f; // Camera rotation speed
    public float maxRotationY = 90f; // Maximum rotation value in the Y-axis
    public float groundLevel = 0f; // Ground level (Y-axis height)
    public float zoomSpeed = 2f; // Camera zoom speed
    public float minZoomDistance = 2f; // Minimum zoom distance
    public float maxZoomDistance = 10f; // Maximum zoom distance

    private bool isRotating = false; // Is the mouse button being held down
    private float rotationX = 0f; // Current rotation value in the X-axis
    private float rotationY = 0f; // Current rotation value in the Y-axis
    private float zoomDistance = 5f; // Current camera distance from the target object

    private void Update()
    {
        // Check if the right mouse button is being held down
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        // Zoom in and out with the mouse scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoomDistance -= scroll * zoomSpeed;
        zoomDistance = Mathf.Clamp(zoomDistance, minZoomDistance, maxZoomDistance);
    }

    private void LateUpdate()
    {
        // If the mouse button is being held down, rotate the camera
        if (isRotating)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Calculate the rotation angle based on mouse movement and camera rotation speed
            float rotationAngleX = mouseX * rotationSpeed;
            float rotationAngleY = mouseY * rotationSpeed;

            // Add rotation to the current rotation value in the X-axis
            rotationX -= rotationAngleY;
            rotationX = Mathf.Clamp(rotationX, -maxRotationY, maxRotationY);

            // Add rotation to the current rotation value in the Y-axis
            rotationY += rotationAngleX;

            // Limit rotation in the X-axis to values above the ground level
            if (rotationX < 0f)
            {
                rotationX = 0f;
            }
        }

        // Rotate the camera around the target object
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0f);
        Vector3 position = rotation * new Vector3(0f, 0f, -zoomDistance) + target.position;

        transform.rotation = rotation;
        transform.position = position;
    }
}


