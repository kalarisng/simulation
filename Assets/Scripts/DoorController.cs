using UnityEngine;

public class DoorController : MonoBehaviour
{
    public KeyCode rotateKey = KeyCode.Space;
    public float rotationSpeed = 90f; // Degrees per second

    private HingeJoint hingeJoint;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(rotateKey))
        {
            RotateDoor();
        }
    }

    private void RotateDoor()
    {
        JointMotor motor = hingeJoint.motor;
        motor.targetVelocity = rotationSpeed;
        hingeJoint.motor = motor;

        // Enable the motor to make the door rotate
        hingeJoint.useMotor = true;
    }
}
