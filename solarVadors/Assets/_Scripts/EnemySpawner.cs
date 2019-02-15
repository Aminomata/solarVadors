using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject spawnSpaceShip;
    public float fireRate;
    public Transform spaceSpawn;

    private float nextSpawn = 0f;
    private float timeChange = 5f;
    private Vector3 size;
    private Vector3 minBound;
    private Vector3 maxBound;

    void Start()
    {
        size = GetComponent<Renderer>().bounds.size;
        minBound = new Vector3(transform.position.x - size.x / 2, transform.position.y - size.y / 3.5F, transform.position.z - size.z / 2);
        maxBound = new Vector3(transform.position.x + size.x / 2, transform.position.y + size.y / 2F, transform.position.z + size.z / 2);
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + fireRate;
            Vector3 newPos = new Vector3(Random.Range(minBound.x, maxBound.x), Random.Range(minBound.y, maxBound.y), Random.Range(minBound.z, maxBound.z));
            StartCoroutine(SpawnShip(newPos));

            if (Time.time > timeChange)
            {
                fireRate -= fireRate - 0.1f > 0f ? 0.1f : 0f;
            }
        }
    }

    IEnumerator SpawnShip(Vector3 pos)
    {
        GameObject obj = Instantiate(spawnSpaceShip, pos, new Quaternion());
        yield return new WaitForSeconds(2);
        Destroy(obj);
        Instantiate(spaceShip, pos, new Quaternion());
    }
}
