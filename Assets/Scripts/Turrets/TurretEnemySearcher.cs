using System.Collections;
using UnityEngine;

public class TurretEnemySearcher : MonoBehaviour
{
    public TurretPivot turret;
    public TurretCannon cannon;
    public float searchInterval = 0.2f;
    public float detectionRange = 5f;
    public float visionAngle = 160f;

    private void Start()
    {
        StartCoroutine(SearchEnemys(searchInterval));
    }

    private IEnumerator SearchEnemys(float interval)
    {
        while (true)
        {
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

            if (turret.currentEnemyPosition == null)
            {
                foreach (GameObject enemy in enemys)
                {
                    bool dist = checkDistance(enemy);
                    bool angle = checkAngle(enemy);

                    if (dist && angle)
                    {
                        Debug.Log("Inimigo " + enemy.name + " entrou em minha visão!");
                        turret.currentEnemyPosition = enemy.transform;
                        cannon.firingEnabled = true;
                        break;
                    }
                }
            }
            else
            {
                bool enemyIsInVision = checkPositionAndDistance(turret.currentEnemyPosition);
                if(!enemyIsInVision)
                {
                    Debug.Log("Um inimigo acaba de sair de minha visão. Procurar outro!");
                    turret.currentEnemyPosition = null;
                    cannon.firingEnabled = false;
                }

            }
            yield return new WaitForSeconds(interval);
        }
    } 

    private bool checkDistance(GameObject enemy)
    {
        if (Vector2.Distance(transform.position, enemy.transform.position) <= detectionRange)
            return true;
        return false;
    }

    private bool checkAngle(GameObject enemy)
    {
        Vector2 forward = transform.right;
        Vector2 enemyDirection= ((Vector2)transform.position + (Vector2)enemy.transform.position).normalized;
        float dot = Vector2.Dot(forward, enemyDirection);

        if (dot >= Mathf.Cos(visionAngle / 2 * Mathf.Deg2Rad))
            return true;
        return false;
    }

    private bool checkPositionAndDistance(Transform enemyPosition)
    {
        Vector2 forward = transform.right;
        Vector2 enemyDirection = ((Vector2)transform.position + (Vector2)enemyPosition.position).normalized;
        float dot = Vector2.Dot(forward, enemyDirection);

        if (dot >= Mathf.Cos(visionAngle / 2 * Mathf.Deg2Rad))
            if (Vector2.Distance(transform.position, enemyPosition.transform.position) <= detectionRange)
                return true;
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        float halfAngle = visionAngle / 2f;

        Vector2 forward = transform.right;

        Vector2 leftBoundary = Quaternion.Euler(0, 0, -halfAngle) * forward;
        Vector2 rightBoundary = Quaternion.Euler(0, 0, halfAngle) * forward;

        Gizmos.DrawLine(
            transform.position,
            transform.position + (Vector3)(leftBoundary * detectionRange)
        );

        Gizmos.DrawLine(
            transform.position,
            transform.position + (Vector3)(rightBoundary * detectionRange)
        );
    }
}

