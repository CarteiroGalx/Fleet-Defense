using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime;
    void Start()
    {
        Invoke("AutoDestroy", lifeTime);
    }

    private void AutoDestroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyMovement>().TakeDamage(1);
        }
    }
}
