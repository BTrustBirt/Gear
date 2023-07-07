using UnityEngine;
using UnityEngine.UI;

public class EnginePhysic : MonoBehaviour
{
    [SerializeField]
    private Slider slider;  // Reference to a Slider component in the Unity Inspector

    private Rigidbody rb; // Reference to the Rigidbody component

    [SerializeField]
    private float rotationForceIncrement = 10f; // Rotation force increment value

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component from the object
    }

    private void FixedUpdate()
    {
        float rotationInput = slider.value * 10;

        // Determine the rotation direction based on the slider value
        float rotationDirection = (rotationInput < 0f) ? -1f : 1f;

        // Calculate the absolute value of the rotation force based on the slider value and the rotation force increment
        float rotationForceMagnitude = Mathf.Abs(rotationInput) * rotationForceIncrement;

        // Calculate the rotation force vector based on the direction and the rotation force value
        Vector3 rotationForceVector = Vector3.up * rotationForceMagnitude * rotationDirection;

        // Add the rotation force to the Rigidbody
        rb.AddTorque(rotationForceVector);
    }

    public void ResetSpeed()
    {
        rb.ResetInertiaTensor(); // Reset the Rigidbody rotation
        rb.angularVelocity = Vector3.zero; // Reset the Rigidbody angular velocity
    }
}

