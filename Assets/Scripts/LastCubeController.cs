using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCubeController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        IFinishable finishable = other.GetComponent<IFinishable>();
        if(finishable != null)
        {
            gameManager.FinishGame();
        }
    }
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
