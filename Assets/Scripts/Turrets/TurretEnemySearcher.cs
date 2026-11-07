using System.Collections;
using UnityEngine;

public class TurretEnemySearcher : MonoBehaviour
{
    private Turret turret;
    public float searchInterval = 0.2f;

    private void Start()
    {
        turret = GetComponentInParent<Turret>();
        StartCoroutine(SearchEnemys(searchInterval));
    }

    private IEnumerator SearchEnemys(float interval)
    {
        while (true)
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

            if (turret.currentTarget == null)
            {
                foreach (GameObject enemy in enemys)
                {
                    bool dist = checkDistance(enemy);
                    bool angle = checkAngle(enemy);

                    if (dist && angle)
                    {
                        turret.currentTarget = enemy.transform;
                        break;
                    }
                }
            }
            else
            {
                bool enemyIsInVision = checkPositionAndDistance(turret.currentTarget);
                if(!enemyIsInVision)
                {
                    turret.currentTarget = null;
                }
            }
            yield return new WaitForSeconds(interval);
        }
    } 

    private bool checkDistance(GameObject enemy)
    {
        if (Vector2.Distance(transform.position, enemy.transform.position) <= turret.detectionRange)
            return true;
        return false;
    }

    private bool checkAngle(GameObject enemy)
    {
        Vector2 forward = transform.right;
        Vector2 enemyDirection = ((Vector2)enemy.transform.position - (Vector2)transform.position).normalized;
        float dot = Vector2.Dot(forward, enemyDirection);

        if (dot >= Mathf.Cos(turret.visionAngle / 2 * Mathf.Deg2Rad))
            return true;
        return false;
    }

    private bool checkPositionAndDistance(Transform enemyPosition)
    {
        Vector2 forward = transform.right;
        Vector2 enemyDirection = ((Vector2)enemyPosition.position - (Vector2)transform.position).normalized;
        float dot = Vector2.Dot(forward, enemyDirection);

        if (dot >= Mathf.Cos(turret.visionAngle / 2 * Mathf.Deg2Rad))
            if (Vector2.Distance(transform.position, enemyPosition.transform.position) <= turret.detectionRange)
                return true;
        return false;
    }
}

