using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using System;

public class LatitudeLongitude : MonoBehaviour
{
    [Header("Vessels")]
    public Rigidbody target1;
    public Rigidbody target2;
    public Rigidbody target3;
    public Rigidbody target4;

    [Header("UI")]
    public TextMeshProUGUI latLabel1; // The label that displays the latitude;
    public TextMeshProUGUI latLabel2;
    public TextMeshProUGUI latLabel3;
    public TextMeshProUGUI latLabel4;

    public TextMeshProUGUI longLabel1; // The label that displays the longitude;
    public TextMeshProUGUI longLabel2;
    public TextMeshProUGUI longLabel3;
    public TextMeshProUGUI longLabel4;

    private double lat1 = 0.0f;
    private double lat2 = 0.0f;
    private double lat3 = 0.0f;
    private double lat4 = 0.0f;

    private double long1 = 0.0f;
    private double long2 = 0.0f;
    private double long3 = 0.0f;
    private double long4 = 0.0f;

    double[] coor1;
    double[] coor2;
    double[] coor3;
    double[] coor4;

    void Update()
    {

        //Latitude from meters to degrees, in the Davis Strait (www.usna.edu/Users/oceano/pguth/md_help/html/approx_equivalents.htm)
        lat1 = (target1.transform.position.z * 0.00054054054f) + 70f;
        coor1 = standardizedCoordinates(lat1);
        lat2 = (target2.transform.position.z * 0.00054054054f) + 70f;
        coor2 = standardizedCoordinates(lat2);
        lat3 = (target3.transform.position.z * 0.00054054054f) + 70f;
        coor3 = standardizedCoordinates(lat3);
        lat4 = (target4.transform.position.z * 0.00054054054f) + 70f;
        coor4 = standardizedCoordinates(lat4);

        if (latLabel1 != null)
            latLabel1.text = coor1[0] + "° " + coor1[1] + "' " + coor1[2] + "'' N";

        if (latLabel2 != null)
            latLabel2.text = coor2[0] + "° " + coor2[1] + "' " + coor2[2] + "'' N";

        if (latLabel3 != null)
            latLabel3.text = coor3[0] + "° " + coor3[1] + "' " + coor3[2] + "'' N";

        if (latLabel4 != null)
            latLabel4.text = coor4[0] + "° " + coor4[1] + "' " + coor4[2] + "'' N";

        //Longitude from meters to degrees, in the Davis Strait (www.nhc.noaa.gov/gccalc.shtml)
        long1 = (target1.transform.position.x * 0.00002631578f) + 70f;
        coor1 = standardizedCoordinates(long1);
        long2 = (target2.transform.position.x * 0.00002631578f) + 70f;
        coor2 = standardizedCoordinates(long2);
        long3 = (target3.transform.position.x * 0.00002631578f) + 70f;
        coor3 = standardizedCoordinates(long3);
        long4 = (target4.transform.position.x * 0.00002631578f) + 70f;
        coor4 = standardizedCoordinates(long4);

        if (longLabel1 != null)
            longLabel1.text = coor1[0] + "° " + coor1[1] + "' " + coor1[2] + "'' W";

        if (longLabel2 != null)
            longLabel2.text = coor2[0] + "° " + coor2[1] + "' " + coor2[2] + "'' W";

        if (longLabel3 != null)
            longLabel3.text = coor3[0] + "° " + coor3[1] + "' " + coor3[2] + "'' W";

        if (longLabel4 != null)
            longLabel4.text = coor4[0] + "° " + coor4[1] + "' " + coor4[2] + "'' W";
    }

    private double[] standardizedCoordinates(double val)
    {
        double[] coordinates = new double[3];
        double deg;
        double min;
        double sec;
        double temp;

        deg = Math.Truncate(val);
        min = (val - deg) * 60;
        temp = Math.Truncate(min);
        sec = Math.Round((min - temp) * 60, 1);
        min = Math.Truncate(min);

        //Debug.Log(deg);
        //Debug.Log(min);
        //Debug.Log(sec);

        coordinates[0] = deg;
        coordinates[1] = min;
        coordinates[2] = sec;

        return coordinates;
    }
}
