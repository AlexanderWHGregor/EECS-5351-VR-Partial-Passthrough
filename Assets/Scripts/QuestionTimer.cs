using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace QTimer {

  public class QuestionTimer : MonoBehaviour
  {
      /*[Header("Buttons")]
      public Rigidbody target;
      public Rigidbody target2;
      public Rigidbody target3;
      public Rigidbody target4;*/

      private int fullCount = 0;

      private int countA = 0;
      private int countB = 0;
      private int countC = 0;
      private int countD = 0;

      private bool studyFinished = false;

      float time = 0.0f;
      float questionTime = 0.0f;
      float finalTime = 0.0f;
      public TextMeshProUGUI text;
      public TextMeshProUGUI scoretext;
      public TextMeshProUGUI finalscore;
      //public AudioSource ping;

      //public GameObject ovrr = null;

      //public Transform[] v = new Transform[10];

      private int varr;

      public void VehicleSet(int v)
      {
          varr = v;
      }

      public int VehicleGet()
      {
          return varr;
      }

      private void Awake()
      {
          varr = -1;
      }

      void Start()
      {
          //ping = GetComponent<AudioSource>();
      }

      void Update()
      {
        if (fullCount >= 10 && studyFinished == false) {
            finalTime = time;
            Debug.Log("Final time:" + finalTime);
            studyFinished = true;
        }
        else {
            if (VehicleGet() == 0)
            {
                StartTimer();
                questionTimer();
                VehicleSet(-1);
            }

            if (VehicleGet() == 1)
            {
                fullCount++;
                Debug.Log("Question " + fullCount + " answer time:" + questionTime);
                questionTime = 0;
                questionTimer();
                VehicleSet(-1);
            }

            else if (VehicleGet() == 2)
            {
                fullCount++;
                Debug.Log("Question " + fullCount + " answer time:" + questionTime);
                questionTime = 0;
                questionTimer();
                VehicleSet(-1);
            }

            else if (VehicleGet() == 3)
            {
                fullCount++;
                Debug.Log("Question " + fullCount + " answer time:" + questionTime);
                questionTime = 0;
                questionTimer();
                VehicleSet(-1);
            }

            else if (VehicleGet() == 4)
            {
                fullCount++;
                Debug.Log("Question " + fullCount + " answer time:" + questionTime);
                questionTime = 0;
                questionTimer();
                VehicleSet(-1);
            }
          }
      }

      private void StartTimer()
      {
          text.text = "Time: " + Math.Round(time, 2) + " seconds";
          time += Time.deltaTime;
      }

      private void questionTimer()
      {
          scoretext.text = "Time: " + Math.Round(questionTime, 2) + " seconds";
          questionTime += Time.deltaTime;
      }

  }

}
