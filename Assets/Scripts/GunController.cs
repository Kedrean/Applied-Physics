using UnityEngine;

public class GunController : MonoBehaviour
{
    public Camera cam;
    public float range = 100f;
    public int damage = 1;

    public LayerMask enemyLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("CLICK");
            Shoot();
        }
    }

    void Shoot()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log("HIT: " + hit.collider.name);

            EnemyHealth enemy = hit.collider.GetComponentInParent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        else
        {
            Debug.Log("MISS");
        }
    }

    void OnDrawGizmos()
    {
        if (!cam) return;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward * range);
    }
}