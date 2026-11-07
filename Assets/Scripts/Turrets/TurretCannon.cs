using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class TurretCannon : MonoBehaviour
{
    private Turret turret;
    public Transform firingPoint;
    public bool firingEnabled = false;

    private void Start()
    {
        turret = GetComponentInParent<Turret>();
        StartCoroutine(FiringRoutine(turret.projectile, turret.firingInterval));
    }
    private IEnumerator FiringRoutine(GameObject gameObject, float interval)
    {
        while (true)
        {
            if (firingEnabled)
                Shoot(turret.projectile);
            yield return new WaitForSeconds(interval);
        }
    }

    private void Shoot(GameObject gameObject)
    {
        GameObject projectile = Instantiate(gameObject, firingPoint.position, firingPoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        rb.linearVelocity = firingPoint.right * turret.firingForce;
    }
}
