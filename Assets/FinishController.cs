using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class FinishController : MonoBehaviour
{
    [SerializeField] private Camera finishCamera;
    private GameObject stack;
    private Transform transfromP;


    private void OnTriggerEnter(Collider other)
    {
        IObstacelable obstacelable = other.GetComponent<IObstacelable>();
        if(obstacelable!= null)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            finishCamera.transform.DOLocalMove(new Vector3(2.5F, 2.5F, -2.5F),1);
            finishCamera.transform.DORotate(new Vector3(15,-45,0),1,RotateMode.Fast);
            TowerController.TowerInstance.CreateTower(other.transform.parent.childCount);
        }
    }
}
