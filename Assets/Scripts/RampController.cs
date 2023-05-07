using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IJumpable jumpable = other.GetComponent<IJumpable>();
        if (jumpable != null)
        {
            jumpable.Jump();
        }
    }
}
