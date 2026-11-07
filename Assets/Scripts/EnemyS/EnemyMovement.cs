using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool isOnLeft;
    public int healthPoints = 10;
    public float movementVelocity = 5f;
    public float positionXToStay;
    public float positionYToStay;

    private void Start()
    {
        Transform areaToStay;

        if (isOnLeft)
            areaToStay = GameManager.instance.getLeftArea();
        else
            areaToStay = GameManager.instance.getRightArea();

        float maximumPositionX = areaToStay.position.x + areaToStay.localScale.x / 2;
        float minimumPositionX = areaToStay.position.x - areaToStay.localScale.x / 2;
        positionXToStay = Random.Range(minimumPositionX, maximumPositionX);
        float maximumPositionY = areaToStay.position.y + areaToStay.localScale.y / 2;
        float minimumPositionY = areaToStay.position.y - areaToStay.localScale.y / 2;
        positionYToStay = Random.Range(minimumPositionY, maximumPositionY);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(positionXToStay, positionYToStay, 0),
            movementVelocity * Time.deltaTime
        );
    }

    public void InitiateMovement(Vector2 direction)
    {
        if (direction == Vector2.left)
            isOnLeft = true;
        else
            isOnLeft = false;
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints < 0) Destroy(gameObject);
    }
}
