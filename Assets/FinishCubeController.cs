using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCubeController : MonoBehaviour
{
    [SerializeField] Transform camera;
    private void OnTriggerEnter(Collider other)
    {
        IFinishable finishable = other.GetComponent<IFinishable>();
        if (finishable != null)
        {
            finishable.Finish();
            camera.localPosition = new Vector3(camera.localPosition.x, other.transform.position.y+2, camera.localPosition.z);
        }
    }

}
