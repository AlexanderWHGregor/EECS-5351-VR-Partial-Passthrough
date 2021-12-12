using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VesselLoc : MonoBehaviour
{
    //public RectTransform icon;
    private Vector3 playerTemp;
    private Vector2 mapTemp;

    public Transform vessel;

    private Vector3 vesselPos;

    private float vesselPosx;
    private float vesselPosy;
    private float vesselPosz;

    public RectTransform icon;

    private float anchor;

    public Terrain mapTerrain;

    private float startX;
    private float startY;

    public RectTransform map;

    private float mapRatio;

    // Start is called before the first frame update
    void Start()
    {
        // Both are squares so only one side is required
        mapRatio = map.GetComponent<RectTransform>().rect.width / mapTerrain.terrainData.size.x;

        anchor = map.GetComponent<RectTransform>().rect.width / 2;

        startX = -mapTerrain.transform.position.x;
        startY = -mapTerrain.transform.position.z;

        //Debug.Log("x val: " + startX);
        //Debug.Log("z val: " + startY);

        vesselPosx = ((vessel.transform.position.x+startX) * mapRatio);
        vesselPosy = ((vessel.transform.position.z+startY) * mapRatio);

        //Debug.Log("x val: " + vessel.transform.position.x * mapRatio);
        //Debug.Log("z val: " + vessel.transform.position.z * mapRatio);

        //vesselPos.x = 200;
        //vesselPos.y = 0;
        //vesselPos.z = 0;

        //this.transform.position = new Vector3(0, 0, 0);

        //icon.transform.localPosition = new Vector3(0, 0, 0);

        //icon.anchoredPosition = new Vector3(0, -200, 0);

        //Debug.Log("anchor: " + icon.anchoredPosition);

        icon.transform.localPosition = new Vector3(vesselPosx, vesselPosy, 0);

        //Debug.Log("anchor: " + icon.transform.localPosition);
    }

    // Update is called once per frame
    void Update()
    {
        //vesselPos.x = vessel.transform.position.x * (float)mapRatio;
        //vesselPos.y = vessel.transform.position.z * (float)mapRatio;

        /*vesselPosx = (vessel.transform.position.x * mapRatio);
        vesselPosy = (vessel.transform.position.z * mapRatio);

        Debug.Log("x val: " + vessel.transform.position.x * mapRatio);
        Debug.Log("z val: " + vessel.transform.position.z * mapRatio);

        icon.anchoredPosition = new Vector3(vesselPosx, vesselPosy, 0);*/

        //this.transform.position = new Vector3(200, 0, 0);

        //Debug.Log("Standard: " + vessel.transform.position.x);
        //Debug.Log("Ratio: " + vesselPos.x);

        //icon.transform.position = vesselPos;

        //Debug.Log(icon.transform.position);

        vesselPosx = (((vessel.transform.position.x + startX) * mapRatio) - anchor);
        vesselPosy = (((vessel.transform.position.z + startY) * mapRatio) - anchor);

        //Debug.Log("x val: " + vessel.transform.position.x * mapRatio);
        //Debug.Log("z val: " + vessel.transform.position.z * mapRatio);

        icon.transform.localPosition = new Vector3(vesselPosx, vesselPosy, 0);

        //Debug.Log("anchor: " + icon.transform.localPosition);
    }
}
