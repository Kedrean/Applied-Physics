using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float impactForce = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;

        if (rb != null)
        {
            rb.AddForceAtPosition(transform.forward * impactForce, transform.position, ForceMode.Impulse);

            FixedJoint[] joints = rb.GetComponents<FixedJoint>();

            foreach (FixedJoint joint in joints)
            {
                Destroy(joint);
            }
        }

        Destroy(gameObject);
    }
}
