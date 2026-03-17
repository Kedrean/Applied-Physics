using System.Net.NetworkInformation;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Camera cam;
    public float bulletForce = 20f;

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
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }

        else
        {
            targetPoint = ray.GetPoint(100f);
        }

        Vector3 direction = targetPoint - cam.transform.position;

        GameObject bullet = Instantiate(bulletPrefab, cam.transform.position, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(direction.normalized * bulletForce, ForceMode.Impulse);
    }
}
