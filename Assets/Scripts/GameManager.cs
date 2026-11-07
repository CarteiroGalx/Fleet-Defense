using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance = null;
    [SerializeField]
    private Transform leftEnemyArea;
    [SerializeField]
    private Transform rightEnemyArea;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
    }

    public Transform getLeftArea() { return leftEnemyArea; }

    public Transform getRightArea() { return rightEnemyArea;}
}
