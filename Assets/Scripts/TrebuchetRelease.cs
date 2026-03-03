using UnityEngine;

public class TrebuchetRelease : MonoBehaviour
{
    public Rigidbody projectile;
    public float releaseAngle = 45f;
    public float currentAngle;

    private SpringJoint projectileJoint;
    private HingeJoint hinge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        projectileJoint = projectile.GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle = hinge.angle;

        if (projectileJoint != null && currentAngle >= releaseAngle)
        {
            Destroy(projectileJoint);
        }
    }
}
