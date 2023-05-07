using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TowerController : MonoBehaviour
{
    [SerializeField] private int maxPlayerPerRow;
    [SerializeField] private float xGap;
    [SerializeField] private float yGap;

    private int playerAmount;
    private GameObject stack;
    private int lastPlayerRowCount=0;

    public static TowerController TowerInstance;

    void Start()
    {
        TowerInstance = this;

        stack = transform.Find("Stack").gameObject;
    }

    public void CreateTower(int stickManCount)
    {

        while (playerAmount< stickManCount)
        {
            for (int j = 0; j < maxPlayerPerRow; j++)
            {
                if (playerAmount < stickManCount)
                {
                    Transform childTransform = stack.transform.GetChild(playerAmount).transform;
                    childTransform.DOLocalMove(new Vector3((j * xGap) - (maxPlayerPerRow * xGap / 2), lastPlayerRowCount * yGap, 0), 0.5F).SetEase(Ease.OutQuad);
                    playerAmount++;
                }
            }
            lastPlayerRowCount++;
        }
    }

    /*
    public void CreateTower(int stickManCount)
    {
        playerAmount = stickManCount;
        FillTowerList();
        StartCoroutine(BuildTowerCoroutine());

    }

    private void FillTowerList()
    {
        for (int i = 1; i <= maxPlayerPerRow; i++)
        {
            if (playerAmount <i)
            {
                break;

            }
            playerAmount -= i;
            towerCountList.Add(i);
        }
        for (int i = maxPlayerPerRow; i >0 ; i--)
        {
            if (playerAmount >= i)
            {
                playerAmount -= i;
                towerCountList.Add(i);
                i++;
            }
        }
    }
    

    IEnumerator BuildTowerCoroutine()
    {
        var towerId = 0;
        transform.DOMoveX(0f, 0.5F).SetEase(Ease.Flash);
        yield return new WaitForSeconds(0.55F);

        foreach (var towerHumanCount in towerCountList)
        {
            foreach (var child in towerList)
            {
                child.transform.DOLocalMove(child.transform.localPosition + new Vector3(0, yGap, 0), 0.2F).SetEase(Ease.OutQuad);
            }
            var tower = new GameObject("Tower" + towerId);
            tower.transform.parent = transform;
            tower.transform.localPosition = new Vector3(0, 0, 0);
            towerList.Add(tower);
            var towerNewPos = Vector3.zero;
            float tempTowerHumanCount = 0;
            for (int i = 1; i <= transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                child.transform.parent = tower.transform;
                child.transform.localPosition = new Vector3(tempTowerHumanCount * xGap, 0, 0);
                towerNewPos += child.transform.position;
                tempTowerHumanCount++;
                i--;
                if (tempTowerHumanCount >= towerHumanCount)
                {
                    break;
                }
            }

            tower.transform.position = new Vector3(-towerNewPos.x / towerHumanCount, tower.transform.position.y - offsetY, tower.transform.position.z);
            towerId++;
            yield return new WaitForSeconds(0.2F);
        }

    }*/


    // Update is called once per frame
    void Update()
    {
        
    }
}
