using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public float interval;
    public bool spawnEnabled = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            if (spawnEnabled)
            {
                GameObject enemy = Instantiate(enemyToSpawn, transform.position, transform.rotation);
                EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
                if (transform.position.x < 0)
                    enemyMovement.InitiateMovement(Vector2.left);
                else
                    enemyMovement.InitiateMovement(Vector2.right);
                yield return new WaitForSeconds(interval);
            }
            yield return null;
        }
    }
}
