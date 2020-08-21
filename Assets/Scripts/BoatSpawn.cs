using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawn : MonoBehaviour
{
    public GameObject[] BoatObject;
    int RandomBoat = 0;
    public bool paused = false;

    Vector3 boatStartPos;
    // Y is neutral and should always stay null or 0
    float RandomX , RandomZ;

    public void StartBoatSpawn()
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
        if (!paused)
        {
            RandomX = Random.Range(-1f, 1f);
            RandomZ = Random.Range(-1f, 1f);

            //previous boat is never same as the next boat
            RandomBoat += Random.Range(1, 3);
            if (RandomBoat > 2)
            {
                RandomBoat = 0;
            }

            boatStartPos = new Vector3(RandomX, 0, RandomZ);
            transform.position = boatStartPos.normalized * 2.8f;

            Instantiate(BoatObject[RandomBoat], transform.position, this.transform.rotation);
        }
    }
}
