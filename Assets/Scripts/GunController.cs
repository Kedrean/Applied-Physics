using UnityEngine;

public class GunController : MonoBehaviour
{
    public Camera cam;
    public float range = 100f;
    public int damage = 1;

    public LayerMask enemyLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, range, enemyLayer))
        {
            EnemyHealth enemy = hit.collider.GetComponentInParent<EnemyHealth>();

            if (enemy != null)
                enemy.TakeDamage(damage);
        }
    }
}
