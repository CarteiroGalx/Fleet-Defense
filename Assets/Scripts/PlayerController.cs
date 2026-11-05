using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerTurret[] primaryTurrets;
    public int bulletForce;
    private Vector2 mousePosition;
    public int movingVelocity;

    private void Update()
    {
        foreach (var t in primaryTurrets)
        {
            t.LookAtMouse(mousePosition);
    }
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
