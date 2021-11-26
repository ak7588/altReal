using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckingContainerManager : MonoBehaviour
{
    public Material right, wrong, defaultMaterial;
    public GameObject container;
    private GameObject[] fakesArray;
    private int numTotal = 8;
    private int visible = 4;
    private int oneToShow = 8;

    private void Awake()
    {
        fakesArray = new GameObject[numTotal];
        for (int i = 0; i < numTotal; i++)
        {
            GameObject obj = GameObject.Find("FakePedestal" + i);
            if (i > 3)
            {
                obj.SetActive(false);
            }
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
            StartCoroutine(InvokeCoroutine(other.gameObject));
            StartCoroutine("LoadNext");
        }
    }

    IEnumerator InvokeCoroutine(GameObject other)
    {
        yield return new WaitForSeconds(1);
        other.SetActive(false);
        container.GetComponent<MeshRenderer>().material = defaultMaterial;
        yield return null;

    }

    private void OnTriggerExit(Collider other)
    {
        StopCoroutine("LoadNext");
        container.GetComponent<MeshRenderer>().material = defaultMaterial;
    }

    IEnumerator LoadNext() {
        //GameObject lastElement = fakesArray[fakesArray.Length - 1];
        //lastElement.SetActive(true);
        fakesArray[visible].SetActive(true);
        //oneToShow--;
        visible++;
        //fakesArray = fakesArray.Take(fakesArray.Length - 1).ToArray();
        int random;
        do
        {
            random = Random.Range(0, visible);
        } while (!fakesArray[random].activeSelf);
        
        for (int i = 0; i < visible; i++)
        {
            if (i == random)
            {
                fakesArray[i].transform.GetChild(1).tag = "RealGem";
                //fakesArray[i].transform.GetChild(1).GetComponent<MeshRenderer>().material = right;

            }
            else
            {
                fakesArray[i].transform.GetChild(1).tag = "Untagged";
               // fakesArray[i].transform.GetChild(1).GetComponent<MeshRenderer>().material = defaultMaterial;
            }

        }
        
        
        yield return null;
    }
}
