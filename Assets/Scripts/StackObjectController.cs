using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackObjectController : MonoBehaviour,IObstacelable, IAddedable,IJumpable,IFinishable
{
    private PlayerManager playerManager;
    private void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.DealDamage(1);
        }
    }

    public void Add(GateManager gateManager)
    {
        ActionsManager.OnAddStick(gateManager);
    }

    public void Finish()
    {
        transform.SetParent(null);
    }

    public void Jump()
    {
        transform.DOJump(transform.position+new Vector3(0, 0, 4.75F), 1, 1, 1F).SetEase(Ease.Flash).OnComplete(() =>
        {
            playerManager.PositionChange();
        });
    }

    public void Remove()
    {
        ActionsManager.OnRemoveStick(gameObject);
    }
}
