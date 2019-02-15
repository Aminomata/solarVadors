using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public Vector3 speed;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed.x * Time.deltaTime, transform.position.y + speed.y * Time.deltaTime, transform.position.z + speed.z * Time.deltaTime);
    }
}
