using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public float rotationSpeed = 120f;
    public GameObject projectile;
    public Transform firingPosition;
    public void LookAtMouse(Vector2 pos)
    {
        Vector2 direction = pos - (Vector2)transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            Time.deltaTime * rotationSpeed
        );
    }

    public void Fire(Vector2 direction, float force)
    {
        Instantiate(projectile, firingPosition.position, firingPosition.rotation);
        Rigidbody2D rg = projectile.GetComponent<Rigidbody2D>();
    }
}
