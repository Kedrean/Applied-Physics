using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float distance;
    [Range(0f, 360f)] public float phaseOffset = 0f;

    private Vector3 startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float offsetRad = phaseOffset * Mathf.Deg2Rad;

        float move = Mathf.Sin(Time.time * speed + offsetRad) * distance;

        transform.position = startPos + new Vector3(move, 0, 0);
    }
}
