using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject gates;
    [Range(10,100)][SerializeField] private int randomRange;
    private GameObject tempGates;
    private int rand;

    public void CreateGate(Vector3 position)
    {
        tempGates = Instantiate(gates);
        ChangeGateType(tempGates);
        tempGates.transform.position = position;
    }
    private void ChangeGateType(GameObject gate)
    {
        for (int i = 0; i < 2; i++)
        {
            switch (Random.Range(0, 2))
            {
                case 0:
                    rand = Random.Range(1,randomRange);
                    gate.transform.GetChild(i).GetComponent<GateManager>().InitGateType(GateType.Plus,rand);
                    break;
                case 1:
                    rand = Random.Range(1, 3);
                    gate.transform.GetChild(i).GetComponent<GateManager>().InitGateType(GateType.Multiply,rand);
                    break;
                default:
                    break;
            }
        }
    }
}
