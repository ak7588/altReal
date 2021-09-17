using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpAnimation : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public float duration = 4;
    float currentPos = 0;
    AnimationCurve curve = AnimationCurve.EaseInOut(0,0,1,1);

    // Start is called before the first frame update
    void Start()
    {
        currentPos = 0;
        transform.position = start.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != end.position) {
            currentPos += Time.deltaTime / duration;
            currentPos = Mathf.Clamp01(currentPos);
            float t = curve.Evaluate(currentPos);
            transform.position = Vector3.Lerp(start.position, end.position, t);
            transform.rotation = Quaternion.Slerp(start.rotation, end.rotation, t);
        }
    }
}
