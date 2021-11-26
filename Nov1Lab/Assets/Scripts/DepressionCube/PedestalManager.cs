using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalManager : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 350f;

    private Vector3 startPoint, endPoint;
    private float lerp = 0, duration = 2;

    public Material passMaterial;
    public GameObject cube;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Pass"))
        {
            StartCoroutine(ShootTheCube(other.gameObject));
            // ShootTheCube(other);
        }
        else
        {
            GetComponent<MeshRenderer>().material = passMaterial;
        }
    }

    IEnumerator ShootTheCube(GameObject other)
    {
        other.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
        //startPoint = GameObject.Find("Gem").transform.position;
        //endPoint = GameObject.Find("SpawnLocation").transform.position;
        //lerp += Time.deltaTime / duration;
        //other.transform.position = Vector3.Lerp(startPoint, endPoint, lerp);
        yield return null;
    }
}
