using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class TurretCannon : MonoBehaviour
{
    public GameObject projectile;
    public Transform firingPoint;
    public float firingInterval = 1f;
    public float firingForce = 10f;
    public bool firingEnabled = false;

    private void Start()
    {
        StartCoroutine(FiringRoutine(projectile, firingInterval));
    }
    private IEnumerator FiringRoutine(GameObject gameObject, float interval)
    {
        while (true)
        {
            if (firingEnabled)
                Shoot(projectile);
            yield return new WaitForSeconds(interval);
        }
    }

    private void Shoot(GameObject gameObject)
    {
        GameObject projectile = Instantiate(gameObject, firingPoint.position, firingPoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        rb.linearVelocity = firingPoint.right * firingForce;
    }
}
