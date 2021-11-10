using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerInstantiate : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float launchForce = 100.0f;
    public Transform launchSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("CloneCube");
        }
    }

    public void Launch()
    {
        GameObject projectile = GameObject.Instantiate(projectilePrefab, launchSpawn.position, launchSpawn.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(projectile.transform.forward * launchForce);
        HighLightController hc = projectile.GetComponent<HighLightController>();
        hc.SetBaseColor(Random.ColorHSV());
    }

    IEnumerator CloneCube()
    {
        int count = 0;
        while (count < 20)
        {
            GameObject projectile = GameObject.Instantiate(projectilePrefab, launchSpawn.position, launchSpawn.rotation);
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.AddForce(projectile.transform.forward * launchForce);
            HighLightController hc = projectile.GetComponent<HighLightController>();
            hc.SetBaseColor(Random.ColorHSV());
            count += 1;
        }
        yield return null;
    }
}
