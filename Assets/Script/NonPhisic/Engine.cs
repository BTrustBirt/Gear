using UnityEngine;
using UnityEngine.UI;

// This is a class called "Engine" that inherits from the "Rotator" class
public class Engine : Rotator
{
    [SerializeField]
    private Slider slider;  // Reference to a Slider component in the Unity Inspector

    private void Start()
    {
        EngineSpeed = slider.value;
    }

    // Overrides the FixedUpdate method from the base class
    public override void FixedUpdate()
    {
        base.FixedUpdate();

        // Calculate the rotation speed based on the engine speed and time
        float speed = EngineSpeed * Time.deltaTime;

        // Rotate the object around the up axis by the rotation speed
        transform.Rotate(Vector3.up, speed);

    }

    // Update the EngineSpeed based on the value of the slider *UI
    public void ChangeSpeedEngine()
    {
        EngineSpeed  = slider.value;
    }
}
