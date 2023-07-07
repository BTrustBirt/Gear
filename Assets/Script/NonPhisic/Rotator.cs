using UnityEngine;

public abstract class Rotator : MonoBehaviour
{
    public float EngineSpeed = 0f;  // Public variable for the engine speed

    public virtual void FixedUpdate()
    {
        if (EngineSpeed == 0f)
        {
            return;
        }
        // If the engine speed is not zero, continue with the remaining code
        // override in inherits
    }
}
