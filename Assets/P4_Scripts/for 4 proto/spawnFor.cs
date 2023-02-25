using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnFor : MonoBehaviour
{
    public float spawnRandom;
    public GameObject enemyPref;
    private int enemCounter;
    public int waveCounter = 1;
    

    // Start is called before the first frame update
    void Start()
    {
        enemyPref = Resources.Load<GameObject>("Prefabs/EnemyPref");
        Spawn(3);

    }

    // Update is called once per frame
    void Update()
    {
        enemCounter = FindObjectsOfType<enemyGo>().Length;
        //���� �� �������
        Debug.Log(enemCounter + " enemies");
        if (enemCounter<1)
        {
            Spawn(waveCounter);
            waveCounter++;
        }
    }

    private Vector3 spawnPos()
    //������ ��� ������ � ������� ��� Void -������, � ���� ����� ����� ���������� Vector3, ������� ������ void ������ Vector3
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
}
