using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowManager : MonoBehaviour
{
    public Material glow, noglow;
    bool isGlowing = false;

    public void ToggleGlow() {
        if (isGlowing)
        {
            gameObject.GetComponent<MeshRenderer>().material = noglow;
            isGlowing = false;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = noglow;
            isGlowing = true;
        }
    }
}
