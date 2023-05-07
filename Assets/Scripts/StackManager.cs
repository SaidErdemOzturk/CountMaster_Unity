using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackManager : MonoBehaviour
{
    [SerializeField] private GameObject stickManPrefab;
    [SerializeField] private GameObject stack;
    [SerializeField] private float radius, distanceFactor;
    private GameObject tempObj;
    private int childCount;

    /*
    private void FormatStickMan()
    {
        for (int i = 0; i < stack.transform.childCount; i++)
        {
            var x = distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * radius);
            var z = distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * radius);
            var newPos = new Vector3(x, 0, z);
            stack.transform.GetChild(i).DOLocalMove(newPos, 1);
        }
    }

    public void DecraseStickMan(GameObject decraseObject)
    {
        Destroy(decraseObject);
        /*
        for (int i = 0; i < stack.transform.childCount; i++)
        {
            stack.transform.GetChild(i).DOLocalMove(new Vector3(0,0,0),0.5F);
        }

    }

    public void AddStickMan(GateManager gate)
    {
        switch (gate.gateType)
        {
            case GateType.Plus:
                PlusStickMan(gate.randomNumber);
                break;
            case GateType.Multiply:
                MultiplyStickMan(gate.randomNumber);
                break;
            default:
                break;
        }
        FormatStickMan();

    }

    public void MultiplyStickMan(int gatePoint)
    {
        int childCount = stack.transform.childCount;

        for (int i = 0; i < (childCount * gatePoint) - childCount; i++)
        {
            tempObj = Instantiate(stickManPrefab, stack.transform);
            tempObj.transform.localPosition = new Vector3(0, 0, 0);
        }

    }

    public void PlusStickMan(int gatePoint)
    {
        for (int i = 0; i < gatePoint; i++)
        {
            tempObj = Instantiate(stickManPrefab, stack.transform);
            tempObj.transform.localPosition = new Vector3(0, 0, 0);
        }
    }*/
}
