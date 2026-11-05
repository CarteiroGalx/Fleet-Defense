using TMPro;
using UnityEngine;

public class Utils2D : MonoBehaviour
{
    /// <summary>
    /// Faz o transform olhar para um alvo 2D (considera eixo Z como rotação).
    /// </summary>
    public static Quaternion LookAt2D(Transform self, Vector2 targetPosition)
    {
        Vector2 direction = targetPosition - (Vector2)self.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return self.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
