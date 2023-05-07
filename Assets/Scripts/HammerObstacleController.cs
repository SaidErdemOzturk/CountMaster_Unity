using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class HammerObstacleController : MonoBehaviour
{
    private bool isTouched;
    private void Start()
    {
        transform.DOLocalRotate(new Vector3(90, 0, -90), 0.5F, RotateMode.FastBeyond360).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InQuint);
    }
    private void FixedUpdate()
    {

        if (!isTouched) {

            /*
            transform.DOLocalRotate(new Vector3(90, 0, -90), 0.5F, RotateMode.FastBeyond360).OnComplete(() =>
            {
                isTouched = true;
                transform.DOLocalRotate(new Vector3(90, 0, 0), 0.5F, RotateMode.Fast).OnComplete(() =>
                {
                    isTouched = false;
                });

            });*/


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IObstacelable obstacelable = other.GetComponent<IObstacelable>();
        if(obstacelable != null)
        {
            obstacelable.Remove();
        }
    }
}
