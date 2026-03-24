using UnityEngine;

public class Hammer : MonoBehaviour
{
    private HingeJoint hinge;
    private JointMotor motor;

    public float speed;
    public float force;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        motor = hinge.motor;

        motor.force = force;
        motor.targetVelocity = speed;

        hinge.motor = motor;
        hinge.useMotor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hinge.angle >= hinge.limits.max - 1f)
        {
            motor.targetVelocity -= speed;
            hinge.motor = motor;
        }

        if (hinge.angle <= hinge.limits.min + 1f)
        {
            motor.targetVelocity += speed;
            hinge.motor = motor;
        }
    }
}
