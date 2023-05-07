using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshPro counterText;
    [SerializeField] private GameObject enemyCharacter;
    [SerializeField] private ObjectPool objectPool;
    private GameObject stack;
    private float distanceFactor = 0.1F;
    private float radius = 1;
    private List<GameObject> stickMans;
    private GameObject tempCharacter;

    private void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
        stickMans = new List<GameObject>();
        stack = transform.Find("Stack").gameObject;
        for (int i = 0; i < 10; i++)
        {
            tempCharacter = objectPool.GetPooledObject(1);
            tempCharacter.transform.SetParent(stack.transform);
            stickMans.Add(tempCharacter);
        }
        UpdateStickList();
        PositionChange();
    }

    private void PositionChange()
    {
        for (int i = 0; i < stickMans.Count; i++)
        {
            var x = distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
            var z = distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * radius);
            var newPos = new Vector3(x, 0, z);
            stickMans[i].transform.DOLocalMove(newPos, 1).SetEase(Ease.OutBack);
        }
    }

    public void RemoveCharacter(GameObject gameObject)
    {
        stickMans.Remove(gameObject);
        //bu neden performansý çok fazla etkiliyor.
        gameObject.transform.SetParent(null);
        objectPool.HidePooledObject(gameObject);
        Debug.Log(stack.transform.childCount);
        UpdateStickList();
    }

    private void UpdateStickList()
    {
        counterText.text = stack.transform.childCount.ToString();
    }
}