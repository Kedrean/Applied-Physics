using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public static StartPoint instance;

    public Transform startPoint;
    public GameObject playerPrefab;

    private GameObject currentPlayer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        currentPlayer = Instantiate(playerPrefab, startPoint.position, Quaternion.identity);
    }

    public GameObject GetPlayer()
    {
        return currentPlayer;
    }
}
