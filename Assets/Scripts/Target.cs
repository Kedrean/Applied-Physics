using UnityEngine;

public class Target : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveRange = 3f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = startPos + new Vector3(offset, 0f, 0f);
    }

    public void Hit()
    {
        int points = CalculatePoints();
        ScoreManager.Instance.AddScore(points);

        // Optional: disable target after hit
        gameObject.SetActive(false);
    }

    int CalculatePoints()
    {
        float z = startPos.z;

        if (z <= 0) return 10;
        if (z <= 5) return 25;
        if (z <= 10) return 50;
        if (z <= 15) return 75;
        if (z <= 20) return 100;
        return 150;
    }
}
