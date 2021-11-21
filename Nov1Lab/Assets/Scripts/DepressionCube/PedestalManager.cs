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

    // create a singleton for the gem, which also tracks the isDipped boolean
    // get isDipped info from the singleton and store it in private bool isDipped
    private bool isDipped = false;

    private void Start()
    {
        startTime = Time.time;
        flightDistance = Vector3.Distance(startPoint.position, endPoint.position);
    }

    void Update()
    {
        // add listener to isDipped or check if isDipped changed state
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem")) {
            if (!isDipped) {
                ShootTheCube();
            }
            else
            {
                // Complete the task
            }
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
