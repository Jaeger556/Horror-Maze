using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Camera sCam;
    public GameObject keyPrefab;
    public GameObject exitPrefab;
    private Ray ray;
    private RaycastHit hit;
    private Vector3 rSpawn;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        rSpawn = new Vector3(Random.Range(0, sCam.pixelHeight - 1), Random.Range(sCam.pixelWidth - 1, 1), 0.1f);
    }

    void Update()
    {
        //Debug.DrawLine(ray.origin, hit.point);
    }

    void Spawn()
    {
        //Vector3 randomSpawn = new Vector3(Random.Range(0, sCam.pixelHeight - 1), Random.Range(sCam.pixelWidth - 1, 1), 0.1f);
        Vector3 randomSpawn = RandPointInPlayArea();
        ray = sCam.ScreenPointToRay(randomSpawn);

        //Debug.DrawLine(randomSpawn, hit.point);

        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
                //Spawn key on random raycast point
                Debug.Log("Instantiating key");
                Instantiate(keyPrefab, new Vector3(hit.point.x, 0.8f, hit.point.z), Quaternion.identity);

                //Spawn exit on random raycast point
            }
    
        }
        else Debug.Log("ray miss");
    }

    private Vector3 RandPointInPlayArea()
    {
        Vector3 bottomLeft = sCam.ViewportToWorldPoint(new Vector3(0, 0, 0.1f));
        Vector3 topRight = sCam.ViewportToWorldPoint(new Vector3(1, 1, 0.1f));
        return new Vector3(Random.Range(bottomLeft.x, topRight.x), 0f, Random.Range(bottomLeft.z, topRight.z));
    }
}
