using System.Collections;
using UnityEngine;

public class TurretPivot : MonoBehaviour
{
    private Turret turret;
    public float rotationVelocity = 90f;
    public string State = "idle";
    private float initialAngle;

    private void Start()
    {
        initialAngle = transform.eulerAngles.z;
        turret = GetComponentInParent<Turret>();
        StartCoroutine(WaitingForEnemyRoutine());
    }

    void Update()
    {
        if (turret.currentTarget != null)
        {
            Vector2 direction = turret.currentTarget.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, 
                targetRotation,
                rotationVelocity * Time.deltaTime);
        }
    }

    public IEnumerator WaitingForEnemyRoutine()
    {
        while (true)
        {
            if (State != "idle")
            {
                yield return null;
                continue;
            }

            float visionAngle = turret.visionAngle;

            float randomAngle = initialAngle + Random.Range(
                -visionAngle / 2f,
                visionAngle / 2f
            );

            Quaternion targetRotation = Quaternion.Euler(0, 0, randomAngle);

            while (State == "idle" &&
                   Quaternion.Angle(transform.rotation, targetRotation) > 0.1f)
            {
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    targetRotation,
                    rotationVelocity / 4 * Time.deltaTime
                );

                yield return null;
            }

            yield return new WaitForSeconds(2f);
        }
    }
}
