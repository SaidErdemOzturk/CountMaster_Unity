using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    private EnemySpawner enemySpawner;
    private GateSpawnerManager gateSpawner;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner= FindObjectOfType<EnemySpawner>();
        gateSpawner = FindObjectOfType<GateSpawnerManager>();
        for (int i = -80; i < 80; i+=20)
        {
            gateSpawner.CreateGate(new Vector3(0,0.7501F,i));
        }
        for (int i = 70; i > -70; i-=20)
        {
            enemySpawner.CreateEnemy(new Vector3(0,0.501F,i));
        }
    }
}
