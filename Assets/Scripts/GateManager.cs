using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GateType
{
    Plus,
    Multiply,
}

public class GateManager : MonoBehaviour
{
    public GateType gateType;
    public TMPro.TextMeshProUGUI gateNo;
    public int randomNumber;
    public GameObject stack;

    // Start is called before the first frame update
    private void Start()
    {
        stack = FindObjectOfType<PlayerManager>().transform.Find("Stack").gameObject;
    }

    public void InitGateType(GateType gateType,int rand)
    {
        this.gateType = gateType;
        randomNumber = rand;
        switch (gateType)
        {
            case GateType.Plus:
                InitPlusGate();
                break;
            case GateType.Multiply:
                InitMultiplyGate();
                break;
            default:
                break;
        }
    }

    private void InitPlusGate()
    {
        gateNo.text = randomNumber.ToString();
    }

    private void InitMultiplyGate()
    {
        gateNo.text = "x" + randomNumber;
    }

    private void OnTriggerEnter(Collider other)
    {
        IAddedable touchedObject = other.GetComponent<IAddedable>();
        if(touchedObject != null)
        {
            touchedObject.Add(this);
            gameObject.transform.parent.GetChild(0).GetComponent<MeshCollider>().enabled = false;
            gameObject.transform.parent.GetChild(1).GetComponent<MeshCollider>().enabled = false;
        }
    }
}
