using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AttackAreaManager : MonoBehaviour
{
    [SerializeField] private GameObject stack;
    private float tempSpeed;
    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        IObstacelable obj = other.GetComponent<IObstacelable>();
        if(obj != null)
        {
            for (int i = 0; i < stack.transform.childCount; i++)
            {
                stack.transform.GetChild(i).DOLookAt(other.transform.position,1);
                stack.transform.GetChild(i).DOMove(other.transform.position,5F);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IObstacelable obj = other.GetComponent<IObstacelable>();
        if (obj != null)
        {
            /*tempSpeed = other.transform.parent.parent.GetComponent<PlayerManager>().speed;
            other.transform.parent.parent.GetComponent<PlayerManager>().speed = 5;*/
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //other.transform.parent.parent.GetComponent<PlayerManager>().speed = tempSpeed;
    }

}
