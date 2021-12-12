using UnityEngine;
using System.Collections;

public class TopoLines : MonoBehaviour
{
    public string heightmapPath = "";

    public Texture2D topoMap;

    public Material outputMaterial;

    public Gradient gradient;

    public Color[] colours;

    void Start()
    {
        topoMap = ContourMap.FromRawHeightmap16bpp(heightmapPath, gradient);

        if (topoMap == null)
        {
            Debug.Log("Creation of topomap failed.");
        }
        else
        {
            Debug.Log("Creation of topomap was successful.");
        }

        if (outputMaterial != null)
        {
            outputMaterial.mainTexture = topoMap;
        }
    }
}