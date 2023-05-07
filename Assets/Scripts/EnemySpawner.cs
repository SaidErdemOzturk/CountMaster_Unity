using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyObj;
    [SerializeField] private float radius, distanceFactor;
    private GameObject tempEnemy;

    public void CreateEnemy(Vector3 position)
    {
        tempEnemy = Instantiate(enemyObj);
        tempEnemy.transform.position = position;
    }
}
