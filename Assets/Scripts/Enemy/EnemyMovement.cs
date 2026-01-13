using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float roamDist = 15f;

    private Vector3 startPos;
    private int dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * dir * speed * Time.deltaTime);
        float dist = Vector3.Distance(startPos, transform.position);
        if (dist >= roamDist)
        {
            dir *= -1;
            transform.Rotate(0, 180, 0);
        }
    }
}
