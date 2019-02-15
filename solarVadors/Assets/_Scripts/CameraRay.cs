using System.Collections;
using UnityEngine;

public class CameraRay : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject spawnSpaceShip;
    public GameObject destroySpaceShip;
    public GameObject planeSpawn;
    public float fireRate;

    private float nextSpawn = 0f;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
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
            }

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (hit.transform.gameObject.CompareTag("Shootable"))
                {
                    StartCoroutine(DeleteShip(hit));
                }
            }
        }
    }
        
    IEnumerator DeleteShip(RaycastHit hit)
    {
        Destroy(hit.transform.parent.gameObject);
        GameObject obj = Instantiate(destroySpaceShip, hit.point, new Quaternion());
        yield return new WaitForSeconds(2);
        Destroy(obj);
    }

    IEnumerator SpawnShip(RaycastHit hit)
    {
        GameObject obj = Instantiate(spawnSpaceShip, hit.point, new Quaternion());
        yield return new WaitForSeconds(2);
        Destroy(obj);
        Instantiate(spaceShip, hit.point, new Quaternion());
    }
}
