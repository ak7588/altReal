using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckingContainerManager : MonoBehaviour
{
    public Material right, wrong, defaultMaterial;
    public GameObject container;
    private GameObject[] fakesArray;
    private int numTotal = 4;

    private void Awake()
    {
        fakesArray = new GameObject[numTotal];
        for (int i = 0; i < numTotal; i++)
        {
            GameObject obj = GameObject.Find("FakePedestal" + i);
            obj.SetActive(false);
            fakesArray[i] = obj;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RealGem"))
        {
            gameObject.GetComponent<MeshRenderer>().material = right;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = wrong;
            StartCoroutine("LoadNext");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        container.GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    IEnumerator LoadNext() {
        GameObject lastElement = fakesArray[fakesArray.Length - 1];
        lastElement.SetActive(true);
        fakesArray = fakesArray.Take(fakesArray.Length - 1).ToArray();
        yield return null;
    }
}
