using System.Collections;
using UnityEngine;

public class TurretPivot : MonoBehaviour
{
    public Transform currentEnemyPosition;
    public float rotationVelocity = 90f;
    public string State = "idle";

    private void Start()
    {
        StartCoroutine(WaitingForEnemyRoutine(Vector2.right));
    }

    void Update()
    {
        if (currentEnemyPosition != null)
        {
            Vector2 direction = currentEnemyPosition.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation, 
                targetRotation,
                rotationVelocity * Time.deltaTime);
        }
    }

    public void SwitchState(string state, GameObject enemyToAttack)
    {
        State = state;
        switch (state)
        {
            case "idle":
                break;
            case "attack":
                currentEnemyPosition.position = enemyToAttack.transform.position;
                break;
        }
    }

    public IEnumerator WaitingForEnemyRoutine(Vector2 orientation)
    {
        while (true) 
        {
            Vector2 forward = orientation;
            Quaternion randomDirection = Quaternion.Euler(0, 0, Random.Range(-30, 30));
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                randomDirection, 
                rotationVelocity / 2 * Time.deltaTime);
            yield return new WaitForSeconds(10f);
         }
    }
}
