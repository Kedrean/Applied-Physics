using UnityEngine;
using UnityEngine.Rendering;

public class TrebuchetRangeCalculator : MonoBehaviour
{
    [Header("References")]
    public Rigidbody projectile;

    [Header("Debug")]
    public bool calculateOnKeyPress = true;
    public KeyCode calculateKey = KeyCode.Space;

    // Update is called once per frame
    void Update()
    {
        if (calculateOnKeyPress && Input.GetKeyDown(calculateKey))
        {
            float predictedRange = CalculateExpectedRange
                (
                    projectile.linearVelocity,
                    projectile.transform.position.y
                );

            Debug.Log("Predicted Range: " + predictedRange.ToString("F2") + " meters");
        }
    }

    public float CalculateExpectedRange(Vector3 launchVelocity, float launchHeight)
    {
        float g = Mathf.Abs(Physics.gravity.y);

        float vx = launchVelocity.x;
        float vz = launchVelocity.z;

        // Horizontal speed
        float horizontalSpeed = new Vector2(vx, vz).magnitude;

        float vy = launchVelocity.y;

        // Time of flight formula
        float discriminant = (vy * vy) + (2 * g * launchHeight);

        if (discriminant < 0)
            return 0f;

        float time = (vy + Mathf.Sqrt(discriminant)) / g;

        // Final range
        float range = horizontalSpeed * time;

        return range;
    }
}
