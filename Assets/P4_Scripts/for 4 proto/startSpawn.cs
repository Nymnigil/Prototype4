using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSpawn : MonoBehaviour
{
    public float spawnRandom;
    public GameObject enemyPref;
    // Start is called before the first frame update
    void Start()
    {
        enemyPref = Resources.Load<GameObject>("Prefabs/EnemyPref");
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 spawnPos()
    //������ ��� ������ � ������� ��� Void -������, � ���� ����� ����� ���������� Vector3, ������� ������ void ������ Vector3
    {
        float spawnPosX = Random.Range(-spawnRandom, spawnRandom);
        float spawnPosZ = Random.Range(-spawnRandom, spawnRandom);
        return new Vector3(spawnPosX,0, spawnPosZ);
    }
        
    private void Spawn()
    {
        Instantiate(enemyPref, spawnPos(), enemyPref.transform.rotation);
    }
}
