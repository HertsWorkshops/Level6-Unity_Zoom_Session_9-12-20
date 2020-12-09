using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeSpawner : MonoBehaviour
{
    public GameObject rock;
    public Transform spawnPoint;
    float currentTime;
    float timer;
    public float speed = 10;
    float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
    }  
    void Update()
    {
        currentTime = Time.time;
        if (currentTime > timer)
        {
            GameObject projectile = Instantiate(rock);
            Physics.IgnoreCollision(projectile.GetComponent<Collider>(), spawnPoint.parent.GetComponent<Collider>());
            projectile.transform.SetParent(null);
            projectile.transform.position = spawnPoint.position;
            projectile.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * speed, ForceMode.Impulse);

            Destroy(projectile, 3f);
            waitTime = Random.Range(2, 6);
            timer = currentTime + waitTime;
        }
    }
}
