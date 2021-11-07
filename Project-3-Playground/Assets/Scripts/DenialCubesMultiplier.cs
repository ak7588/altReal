using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DenialCubesMultiplier : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float launchForce = 100.0f;
    public Transform launchSpawn;
    int count = 0;

    private void Update()
    {
        while (count < 20)
        {
            GameObject projectile = GameObject.Instantiate(projectilePrefab, launchSpawn.position, launchSpawn.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(projectile.transform.forward * launchForce);
            count += 1;
        } 
    }

    //public void Launch()
    //{
    //    GameObject projectile = GameObject.Instantiate(projectilePrefab, launchSpawn.position, launchSpawn.rotation);
    //    Rigidbody rb = projectile.GetComponent<Rigidbody>();
    //    rb.AddForce(projectile.transform.forward * launchForce);
    //    HighLightController hc = projectile.GetComponent<HighLightController>();
    //    hc.SetBaseColor(Random.ColorHSV());
    //}
}
