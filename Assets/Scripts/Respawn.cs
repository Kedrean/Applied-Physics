using UnityEngine;

public class Respawn : MonoBehaviour
{
    public static Respawn instance;

    private Vector3 checkpointPosition;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkpointPosition = StartPoint.instance.startPoint.position;
    }

    public void SetCheckpoint(Vector3 pos)
    {
        checkpointPosition = pos;
    }

    public void ReSpawn(GameObject player)
    {
        player.transform.position = checkpointPosition;

        player.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
    }
}
