using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    MeshRenderer meshRenderer = null;

    public float updateInterval = 5f;
    private float _curTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(_curTime > updateInterval)
        //{
        //    SetColor();
        //    _curTime = 0;
        //}
        //_curTime += Time.deltaTime;
    }

    void SetColor()
    {
        if(meshRenderer != null)
            meshRenderer.material.color = Random.ColorHSV();
    }
}
