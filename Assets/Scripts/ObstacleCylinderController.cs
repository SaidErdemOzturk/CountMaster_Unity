using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObstacleCylinderController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        IObstacelable obstacelable = other.GetComponent<IObstacelable>();
        if (obstacelable != null)
        {
            obstacelable.Remove();
        }
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 200, 0) * Time.deltaTime);
    }
}
