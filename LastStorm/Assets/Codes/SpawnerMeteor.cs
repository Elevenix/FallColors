using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMeteor : MonoBehaviour
{
    [SerializeField]
    private GameObject[] meteor;

    [SerializeField]
    private float sizeSpawn = 20;

    [SerializeField]
    private float minDelaySpawn, maxDelaySpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelaySpawn, maxDelaySpawn));
            GameObject randMeteor = meteor[Random.Range(0, meteor.Length)];
            Vector3 randPos = new Vector3(Random.Range(-sizeSpawn, sizeSpawn), transform.position.y, 0);
            Instantiate(randMeteor, randPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
