using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float moveDist = 15f;

    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        transform.Translate(Vector3.forward * step);

        float traveled = Vector3.Distance(startPos, transform.position);

        if (traveled >= moveDist)
        {
            transform.Rotate(0, 180, 0);
            startPos = transform.position;
        }
    }
}
