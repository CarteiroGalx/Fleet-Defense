using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class TurretCannon : MonoBehaviour
{
    private Turret turret;
    public Transform firingPoint;

    private void Start()
    {
        turret = GetComponentInParent<Turret>();
        StartCoroutine(FiringRoutine(turret.firingInterval));
    }

    private IEnumerator FiringRoutine(float interval)
    {
        while (true)
        {
            if (turret.currentTarget != null)
            {
                Shoot(turret.projectile);

                yield return new WaitForSeconds(interval);
            }
            else
            {
                yield return null;
            }
        }
    }

    private void Shoot(GameObject gameObject)
    {
        GameObject projectile = Instantiate(gameObject, firingPoint.position, firingPoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        rb.linearVelocity = firingPoint.right * turret.firingForce;
    }
}
