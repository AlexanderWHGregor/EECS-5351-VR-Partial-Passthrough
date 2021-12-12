using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    [Header("Vessels")]
    public Rigidbody target;
    public Rigidbody target2;
    public Rigidbody target3;
    public Rigidbody target4;

    [Header("Max Speed")]
    public float maxSpeed = 0.0f; // The maximum speed of the target ** IN KM/H **

    //public float minSpeedArrowAngle;
    //public float maxSpeedArrowAngle;

    [Header("UI")]
    public TextMeshProUGUI speedLabel; // The label that displays the speed;
    public TextMeshProUGUI speedLabel2;
    public TextMeshProUGUI speedLabel3;
    public TextMeshProUGUI speedLabel4;
    //public RectTransform arrow; // The arrow in the speedometer

    private float speed = 0.0f;
    private float speed2 = 0.0f;
    private float speed3 = 0.0f;
    private float speed4 = 0.0f;
    private void Update()
    {
        // 3.6f to convert in kilometers and then divide to nautical miles
        // ** The speed must be clamped by the car controller **
        speed = target.velocity.magnitude * 3.6f / 1.852f;
        speed2 = target2.velocity.magnitude * 3.6f / 1.852f;
        speed3 = target3.velocity.magnitude * 3.6f / 1.852f;
        speed4 = target4.velocity.magnitude * 3.6f / 1.852f;

        if (speedLabel != null)
            speedLabel.text = ((int)speed) + " kn/h";

        if (speedLabel2 != null)
            speedLabel2.text = ((int)speed2) + " kn/h";

        if (speedLabel3 != null)
            speedLabel3.text = ((int)speed3) + " kn/h";

        if (speedLabel4 != null)
            speedLabel4.text = ((int)speed4) + " kn/h";

        /*if (arrow != null)
            arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));*/
    }
}