using System.Collections;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject spawnSpaceShip;
    public GameObject planeSpawn;
    public float fireRate;

    private float nextSpawn = 0f;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update(){
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.Equals(planeSpawn))
            {
                if (Input.GetKeyDown(KeyCode.Alpha1) && Time.time > nextSpawn)
                {
                    nextSpawn = Time.time + fireRate;
                    StartCoroutine(SpawnShip(hit));

                }
                print("I'm looking at " + hit.point.x);
            }
        }

        else
        {
            print("I'm looking at nothing!");

        }
    }

    
    IEnumerator SpawnShip(RaycastHit hit)
    {
        GameObject obj = Instantiate(spawnSpaceShip, hit.point, new Quaternion());
        yield return new WaitForSeconds(2);
        Destroy(obj);
        Instantiate(spaceShip, hit.point, new Quaternion());
    }
}
