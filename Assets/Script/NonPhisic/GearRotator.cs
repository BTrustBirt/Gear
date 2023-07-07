using UnityEngine;

public class GearRotator : Rotator
{
    [SerializeField]
    private Rotator gearRotator;    // Reference to another Rotator object

    [SerializeField]
    private int teethRunCount;     // Number of teeth on the running gear

    [SerializeField]
    private int teethOwnCount;  // Number of teeth on the own gear

    private float rotationSpeed; // Speed of rotation for the driven gear

    // Calculates the rotation speed based on the gear ratio
    private float CalculateRotationSpeed()
    {
        EngineSpeed = -gearRotator.EngineSpeed;

        // Check if the own gear has fewer teeth than the running gear
        if (teethOwnCount < teethRunCount)
        {
            return 1f;
        }

        // Calculate and return the rotation speed based on the gear ratio
        return teethOwnCount / teethRunCount;
    }

    // Overrides the FixedUpdate method from the base class
    public override void FixedUpdate()
    {
        base.FixedUpdate();
         
        float ratio = CalculateRotationSpeed();

        // Calculate the rotation speed based on the engine speed and gear ratio
        rotationSpeed = (EngineSpeed / ratio) * Time.fixedDeltaTime;

        // Rotate the object around the up axis by the rotation speed
        transform.Rotate(Vector3.up, rotationSpeed);
        return;
    }
}
