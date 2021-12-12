using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

using System;

public class Heading : MonoBehaviour
{
    [Header("Vessels")]
    public Rigidbody target1;
    public Rigidbody target2;
    public Rigidbody target3;
    public Rigidbody target4;

    [Header("UI")]
    public TextMeshProUGUI headingLabel1; // The label that displays the heading;
    public TextMeshProUGUI headingLabel2;
    public TextMeshProUGUI headingLabel3;
    public TextMeshProUGUI headingLabel4;

    private double heading1 = 0.0f;
    private double heading2 = 0.0f;
    private double heading3 = 0.0f;
    private double heading4 = 0.0f;

    public Transform heading1map;
    public Transform heading2map;
    public Transform heading3map;
    public Transform heading4map;

    private double heading1temp = 0.0f;
    private double heading2temp = 0.0f;
    private double heading3temp = 0.0f;
    private double heading4temp = 0.0f;

    //private bool first = false;

    private void Start()
    {
        //first = true;

        heading1map.Rotate(0, 0, -(float)heading1);
        heading2map.Rotate(0, 0, -(float)heading2);
        heading3map.Rotate(0, 0, -(float)heading3);
        heading4map.Rotate(0, 0, -(float)heading4);

        //Debug.Log("One: " + -(float)heading1);

        heading1temp = heading1;
        heading2temp = heading2;
        heading3temp = heading3;
        heading4temp = heading4;
    }

    void Update()
    {
        heading1 = headingDegree(target1.transform.right.x, target1.transform.right.z, heading1, target1);
        heading2 = headingDegree(target2.transform.right.x, target2.transform.right.z, heading2, target2);
        heading3 = headingDegree(target3.transform.right.x, target3.transform.right.z, heading3, target3);
        heading4 = headingDegree(target4.transform.right.x, target4.transform.right.z, heading4, target4);

        if (headingLabel1 != null)
            headingLabel1.text = (double)Math.Round((double)heading1, 2) + " °";

        if (headingLabel2 != null)
            headingLabel2.text = (double)Math.Round((double)heading2, 2) + " °";

        if (headingLabel3 != null)
            headingLabel3.text = (double)Math.Round((double)heading3, 2) + " °";

        if (headingLabel4 != null)
            headingLabel4.text = (double)Math.Round((double)heading4, 2) + " °";

        heading1map.Rotate(0, 0, -(float)heading1 + (float)heading1temp);
        heading2map.Rotate(0, 0, -(float)heading2 + (float)heading2temp);
        heading3map.Rotate(0, 0, -(float)heading3 + (float)heading3temp);
        heading4map.Rotate(0, 0, -(float)heading4 + (float)heading4temp);

        //Debug.Log("Two: " + -(float)heading1 + (float)heading1temp);

        heading1temp = heading1;
        heading2temp = heading2;
        heading3temp = heading3;
        heading4temp = heading4;

    }

    private double headingDegree(double xVal, double zVal, double heading, Rigidbody target)
    {
        double val;

        val = Math.Atan2(xVal, zVal) * Mathf.Rad2Deg;

        if (val > 0)
        {
            if (val > 90)
            {
                val = val - 90;
            }
            else
            {
                val = val + 270;
            }
        }
        else
        {
            if (val < -90)
            {
                val = val + 270;
            }
            else
            {
                val = val + 270;
            }
        }

        return val;
    }
}
