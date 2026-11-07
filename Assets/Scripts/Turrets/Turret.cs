using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Configurações")]
    public GameObject projectile;
    public float firingInterval = 1f;
    public float firingForce = 10f;
    public float detectionRange = 15f;
    public float visionAngle = 160f;
    public float rotationSpeed = 90f;
    public float damage = 10f;
    public Transform currentTarget;

    private void OnDrawGizmosSelected()
    {
        float halfAngle = visionAngle / 2f;

        Vector2 forward = transform.right;

        Vector2 leftBoundary = Quaternion.Euler(0, 0, -halfAngle) * forward;
        Vector2 rightBoundary = Quaternion.Euler(0, 0, halfAngle) * forward;

        Gizmos.color = Color.red;

        Gizmos.DrawLine(
            transform.position,
            transform.position + (Vector3)(leftBoundary * detectionRange)
        );

        Gizmos.DrawLine(
            transform.position,
            transform.position + (Vector3)(rightBoundary * detectionRange)
        );

        Gizmos.color = Color.yellow;

        // Desenha o alcance central
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}

