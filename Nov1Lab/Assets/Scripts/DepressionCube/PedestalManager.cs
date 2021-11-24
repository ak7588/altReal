using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalManager : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 5.0f;
    private float startTime;
    private float flightDistance;

    public Material passMaterial;
    public GameObject cube;

    private void Start()
    {
        startTime = Time.time;
        flightDistance = Vector3.Distance(startPoint.position, endPoint.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            ShootTheCube();
        }
        else if (other.CompareTag("Pass"))
        {
            cube.GetComponent<MeshRenderer>().material = passMaterial;
        }
    }

    IEnumerator ShootTheCube()
    {
        float distanceFlied = (Time.time - startTime) * speed;
        float flightFraction = distanceFlied / flightDistance;
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, flightFraction);
        yield return null;
    }
}
