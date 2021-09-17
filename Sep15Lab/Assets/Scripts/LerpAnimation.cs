using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAnimation : MonoBehaviour
{
    public Vector3 start = Vector3.zero;
    public Vector3 end = Vector3.zero;
    public float duration = 4;
    float currentPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != end) {
            currentPos += Time.deltaTime / duration;
            currentPos = Mathf.Clamp(currentPos);
            transform.position = Vector3.Lerp(start, end, currentPos);
        }
    }
}
