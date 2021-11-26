using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DippingManager : MonoBehaviour
{
    public Material passMaterial;
    public GameObject cube;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            other.tag = "Pass";
            other.GetComponent<MeshRenderer>().material = passMaterial;
        }
    }
}
