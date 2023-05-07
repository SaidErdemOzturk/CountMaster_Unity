using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour,IDamageable
{
    [SerializeField] private int health;
    private Animator anim;


    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void DealDamage(int hitPoints)
    {
        if(health <= 0)
        {
            Destroy(gameObject,5);
        }
        health -= hitPoints;
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
