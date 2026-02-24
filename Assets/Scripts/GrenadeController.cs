using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    public GameObject grenadePrefab;
    public Transform throwPoint;
    public float throwForce = 15f;

    public float explosionRadius = 5f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ThrowGrenade();
        }
    }

    void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        grenade.GetComponent<Rigidbody>().AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
    }

    void OnDrawGizmos()
    {
        if (!throwPoint) return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(throwPoint.position + throwPoint.forward * 5f, explosionRadius);
    }
}
