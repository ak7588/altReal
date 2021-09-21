using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainAnimated : MonoBehaviour
{
    public Vector3 start = Vector3.zero;
    public Vector3 end = Vector3.zero;
    public float timeInSeconds = 5;
    float currentT = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentT = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != end) {
            currentT += Time.deltaTime / timeInSeconds;
            currentT = Mathf.Clamp01(currentT);
            transform.position = Vector3.Lerp(start, end, currentT);
        }
    }
}
