using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class HighLightController : MonoBehaviour
{
    MeshRenderer mesh;
    public Color highlightColor;
    Color baseColor;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        SetBaseColor(mesh.material.color);
    }

    public void SetBaseColor(Color c) {
        baseColor = c;
        mesh.material.color = baseColor;
    }

    public void Highlight() {
        mesh.material.color = highlightColor;
    }

    public void ClearHighlight() {
        mesh.material.color = baseColor;
    }

    public Color GetBaseColor() {
        return baseColor;
    }

}
