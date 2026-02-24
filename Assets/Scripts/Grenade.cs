using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float radius = 5f;
    public int damage = 50;
    public GameObject explosionFX;

    private void OnCollisionEnter(Collision collision)
    {
        Explode();
    }

    void Explode()
    {
        Instantiate(explosionFX, transform.position, Quaternion.identity);

        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in hits)
        {
            EnemyHealth enemy = hit.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
                enemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}
