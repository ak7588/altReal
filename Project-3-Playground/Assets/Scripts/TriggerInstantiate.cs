using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
using Random = System.Random;

public class TriggerInstantiate : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float launchForce = 100.0f;
    public Transform launchSpawn;
    private double maxNumber = 7.22;
    private double minNumber = -6.52;

    private void Awake()
    {
        for(int i = 0; i < 20; i++)
        {
            Launch();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Debug.Log("Here");
    //        //StartCoroutine("CloneCube");
    //        Launch();
    //    }
    //}

    public void Launch()
    {
        Vector3 spawn = new Vector3(new Random().NextDouble() * (maxNumber - minNumber) + minNumber, 0, new Random().NextDouble() * (maxNumber - minNumber) + minNumber);
        GameObject projectile = GameObject.Instantiate(projectilePrefab, spawn, launchSpawn.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(projectile.transform.forward * launchForce);
        HighLightController hc = projectile.GetComponent<HighLightController>();
        hc.SetBaseColor(Random.ColorHSV());
    }

    //IEnumerator CloneCube()
    //{
    //    int count = 0;
    //    while (count < 20)
    //    {
    //        GameObject projectile = GameObject.Instantiate(projectilePrefab, launchSpawn.position, launchSpawn.rotation);
    //        Rigidbody rb = projectile.GetComponent<Rigidbody>();
    //        rb.AddForce(projectile.transform.forward * launchForce);
    //        HighLightController hc = projectile.GetComponent<HighLightController>();
    //        hc.SetBaseColor(Random.ColorHSV());
    //        count += 1;
    //    }
    //    yield return null;
    //}
}
