using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFor : MonoBehaviour
{
    private float spawnRandom;
    private GameObject enemyPref, bonusPref;
    private int enemCounter;
    private int waveCounter = 2;
    
    void Start()
    {
        InvokeRepeating("BonusSpawn", 5f, 6f);
        enemyPref = Resources.Load<GameObject>("Prefabs/EnemyPref");
        bonusPref= Resources.Load<GameObject>("Prefabs/Bonus");
        Spawn(1);
    }

    void FixedUpdate()
    {
        enemCounter = FindObjectsOfType<enemyGo>().Length;
        //ищет по скрипту
        if (enemCounter<1)
        {
            Spawn(waveCounter);
            waveCounter++;
        }
    }

    private Vector3 spawnPos()
    //раньше тип данных в методах был Void -ничего, а этот метод будет возвращать Vector3, поэтому вместо void указан Vector3
    {
        float spawnPosX = Random.Range(-spawnRandom, spawnRandom);
        float spawnPosZ = Random.Range(-spawnRandom, spawnRandom);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    void Spawn(int ememysToSp)
    {
        for (int i=0; i< ememysToSp; i++)
        {
            Instantiate(enemyPref, spawnPos(), enemyPref.transform.rotation);
        }
    }

    void BonusSpawn() 
    {
        Instantiate(bonusPref, spawnPos(), bonusPref.transform.rotation);
    }
}
