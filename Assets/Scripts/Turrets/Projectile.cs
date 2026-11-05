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
}
