using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterController : MonoBehaviour
{

    private EnemyManager enemyManager;
    private void Start()
    {
        enemyManager = transform.parent.parent.GetComponent<EnemyManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        IObstacelable obstacelable = other.GetComponent<IObstacelable>();
        if(obstacelable != null)
        {
            transform.GetComponent<CapsuleCollider>().enabled = false;
            enemyManager.RemoveCharacter(gameObject);
            obstacelable.Remove();
        }
    }

}
