using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public int damage = 1;
    public float fireRate = 1f;

    private TowerController tower;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tower = GetComponent<TowerController>();    
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Transform target = tower.GetCurrentTarget();

        if (target != null) return;

        if (timer >= fireRate)
        {
            EnemyHealth enemy = target.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            timer = 0f;
        }
    }
}
