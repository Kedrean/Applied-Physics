using UnityEngine;

public class RaycastShooter : MonoBehaviour
{
    public Camera fpsCamera;
    public float maxDistance = 200f;

    void Update()
    {
        if (Time.timeScale == 0f) return;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = fpsCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            if (hit.collider.CompareTag("Target"))
            {
                hit.collider.GetComponent<Target>()?.Hit();
            }
        }
    }
}
