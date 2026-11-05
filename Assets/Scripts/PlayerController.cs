using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public PlayerTurret[] primaryTurrets;
    public int bulletForce;
    private Vector2 mousePosition;

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
}
