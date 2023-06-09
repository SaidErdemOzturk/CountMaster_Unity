using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        IObstacelable touchedObj = other.GetComponent<IObstacelable>();
        if(touchedObj != null)
        {
            touchedObj.Remove();
        }
    }
}
