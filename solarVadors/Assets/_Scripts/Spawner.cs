using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spaceShip;
    public float fireRate;
    public Transform spaceSpawn;

    private float nextSpawn = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + fireRate;
            Instantiate(spaceShip, spaceSpawn.position, spaceSpawn.rotation);
        }
    }
}
