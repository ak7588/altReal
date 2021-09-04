using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereBehavior : MonoBehaviour
{
    public float speed = 20.0f;
    // rigidbody complies to physics laws
    Rigidbody body;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ranDir = Random.onUnitSphere;
        body.AddForce(new Vector3(ranDir.x, 0, ranDir.y) * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // adding tags and comparing for a specific game object
        if (collision.gameObject.CompareTag("obstacle")) {

            ObstacleData data = collision.gameObject.GetComponent<ObstacleData>();
            if (data != null) {
                meshRenderer.material.color = data.color;
            }
            Debug.Log("Collision start: " + collision.gameObject.name);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision stay: " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision exit: " + collision.gameObject.name);
    }
}
