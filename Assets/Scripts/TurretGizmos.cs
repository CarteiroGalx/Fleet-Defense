using UnityEngine;

public class TurretGizmos : MonoBehaviour
{
    public TurretEnemySearcher selfTurret;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        float halfAngle = selfTurret.visionAngle / 2f;

        Vector2 forward = transform.right;

        Vector2 leftBoundary = Quaternion.Euler(0, 0, -halfAngle) * forward;
        Vector2 rightBoundary = Quaternion.Euler(0, 0, halfAngle) * forward;

        Gizmos.DrawLine(
            transform.position,
            transform.position + (Vector3)(leftBoundary * selfTurret.detectionRange)
        );

        Gizmos.DrawLine(
            transform.position,
            transform.position + (Vector3)(rightBoundary * selfTurret.detectionRange)
        );

        // Desenha o alcance central
        Gizmos.DrawWireSphere(transform.position, selfTurret.detectionRange);
    }

}
