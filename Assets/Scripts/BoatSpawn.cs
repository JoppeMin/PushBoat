using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawn : MonoBehaviour
{
    public GameObject[] BoatObject;
    int RandomBoat = 0;

    Vector3 boatStartPos;
    // Y is neutral and should always stay null or 0
    float RandomX , RandomZ;

    void Awake()
    {
        StartCoroutine(SpawnDelay());
    }

    IEnumerator SpawnDelay()
    {
        InstatiateBoat();
        yield return new WaitForSeconds(1.8f);
        StartCoroutine(SpawnDelay());
    }

    void InstatiateBoat()
    {
        RandomX = Random.Range(-1f, 1f);
        RandomZ = Random.Range(-1f, 1f);

        //randomization script, previous one is never same
        RandomBoat += Random.Range(1, 3);
        if (RandomBoat > 2)
        {
            RandomBoat = 0;
        }
        

        boatStartPos = new Vector3(RandomX, 0, RandomZ);
        transform.position = boatStartPos.normalized * 3f;

        Instantiate(BoatObject[RandomBoat], transform.position, this.transform.rotation);
    }
}
