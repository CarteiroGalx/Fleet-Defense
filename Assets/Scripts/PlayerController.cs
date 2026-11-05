using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerTurret turret;
    public GameObject baseMovement;
    public int bulletForce;
    public Vector2 mousePosition;
    public int movingVelocity;

    private void Update()
    {
        turret.LookAtMouse(mousePosition);
        
    }
    void OnPoint(InputValue value)
    {
        mousePosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        transform.Translate(direction.normalized * movingVelocity);
    }

    void OnAttack(InputValue value)
    {
        
    }
}
