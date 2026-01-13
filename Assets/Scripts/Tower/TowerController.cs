using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour
{
    [Header("Detection")]
    public float detectRad = 4f;
    public float checkInterval = 2.5f;
    public LayerMask enemyLayer;

    [Header("Barrel")]
    public Transform barrel;
    public float rotSpeed = 5f;

    private Transform currentTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(CheckForEnemies());
    }
    
    IEnumerator CheckForEnemies()
    {
        while (true)
        {
            FindNearestEnemy();
            yield return new WaitForSeconds(checkInterval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTarget == null) return;

        float dist = Vector3.Distance(transform.position, currentTarget.position);

        if (dist > detectRad)
        {
            currentTarget = null;
            FindNearestEnemy();
            return;
        }

        RotateBarrel();
    }

    void FindNearestEnemy()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectRad, enemyLayer);

        float nearestDist = Mathf.Infinity;
        Transform nearestEnemy = null;

        foreach (Collider hit in hits)
        {
            float dist = Vector3.Distance(transform.position, hit.transform.position);
            if (dist < nearestDist)
            {
                nearestDist = dist;
                nearestEnemy = hit.transform;
            }
        }

        currentTarget = nearestEnemy;
    }

    void RotateBarrel()
    {
        Vector3 dir = currentTarget.position - barrel.position;
        dir.y = 0f;

        Quaternion lookRotation = Quaternion.LookRotation(dir);
        barrel.rotation = Quaternion.Slerp(barrel.rotation, lookRotation, Time.deltaTime * rotSpeed);
    }

    public Transform GetCurrentTarget()
    {
        return currentTarget;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        
        Gizmos.DrawWireSphere(transform.position, detectRad);

        if (barrel != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(barrel.position, barrel.position + barrel.forward * detectRad);
        }

        if (currentTarget != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(barrel.position, currentTarget.position);
        }
    }
}
