using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using QTimer;
using qList;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    private int finalScore = 0;

    private int fullCount = 0;

    private int countA = 0;
    private int countB = 0;
    private int countC = 0;
    private int countD = 0;

    private bool studyStarted = false;

    //QuestionTimer.VehicleGet  questionState = new QuestionTimer.VehicleGet();

    //questionState = QuestionTimer.VehicleGet();

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

    //QTimer.VehicleGet questionState = new VehicleGet();

    float startTime = 0.0f;
    float questionTime = 0.0f;
    float finalTime = 0.0f;
    float[] answerSpeed = new float[10];
    string[] answerScore = new string[] { "F", "F", "F", "F", "F", "F", "F", "F", "F", "F", };
    TextMeshProUGUI startTimeText;
    TextMeshProUGUI questionTimeText;

    public TextMeshProUGUI QuestionNumber;
    public GameObject WelcomeMessage;
    public GameObject ThankYouMessage;
    public GameObject StatMessage;
    public GameObject BeginButton;
    public GameObject QuestionText;
    public GameObject Answers;
    public TextMeshProUGUI Question;
    public TextMeshProUGUI AnswerA;
    public TextMeshProUGUI AnswerB;
    public TextMeshProUGUI AnswerC;
    public TextMeshProUGUI AnswerD;
    public TextMeshProUGUI ScoreMessage;

    public int tempVal;
    public int randomVal;
    public int score = 0;

    int testCount = 0;
    int QListSize = 36;
    int lastRandomVal;
    int[] usedVal;
    bool studyEnded = false;

    public string[,] JsonData;

    // Start is called before the first frame update
    void Start()
    {
        usedVal = new int[QListSize];

        JsonData = QuestionList.JsonFile();
        //QuestionTimer.VehicleGet  questionState = new QuestionTimer.VehicleGet();

        Debug.Log(JsonData);

        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        //startTime += Time.deltaTime;
        //Debug.Log(startTime);
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(JsonData[testCount % QListSize, 0]);
            Debug.Log(JsonData[testCount % QListSize, 1]);
            Debug.Log(JsonData[testCount % QListSize, 2]);
            Debug.Log(JsonData[testCount % QListSize, 3]);
            Debug.Log(JsonData[testCount % QListSize, 4]);
            Debug.Log(JsonData[testCount % QListSize, 5]);

            Debug.Log(JsonData[testCount % QListSize, 1].GetType());

            testCount++;*/

        /*randomVal = randomQ();
        Debug.Log(JsonData[randomVal, 0]);
        Debug.Log(JsonData[randomVal, 1]);
        Debug.Log(JsonData[randomVal, 2]);
        Debug.Log(JsonData[randomVal, 3]);
        Debug.Log(JsonData[randomVal, 4]);
        Debug.Log(JsonData[randomVal, 5]);

        Debug.Log(JsonData[randomVal, 1].GetType());*/

        /*Debug.Log("HERE: " + randomQ());

        //Debug.Log(finalTime);
    }*/

        if (fullCount > 10)
        {
            //Debug.Log("YO 0:" + JsonData[tempVal, 5] + " + " + VehicleGet());

            if (VehicleGet() == 1 && JsonData[tempVal, 5] == "a" && studyEnded == false)
            {
                //Debug.Log("YO 1: " + JsonData[tempVal, 5]);
                score++;
                answerScore[fullCount - 1] = "T";
                studyEnded = true;
            }
            if (VehicleGet() == 2 && JsonData[tempVal, 5] == "b" && studyEnded == false)
            {
                //Debug.Log("YO 2: " + JsonData[tempVal, 5]);
                score++;
                answerScore[fullCount - 1] = "T";
                studyEnded = true;
            }
            if (VehicleGet() == 3 && JsonData[tempVal, 5] == "c" && studyEnded == false)
            {
                //Debug.Log("YO 3: " + JsonData[tempVal, 5]);
                score++;
                answerScore[fullCount - 1] = "T";
                studyEnded = true;
            }
            if (VehicleGet() == 4 && JsonData[tempVal, 5] == "d" && studyEnded == false)
            {
                //Debug.Log("YO 4: " + JsonData[tempVal, 5]);
                score++;
                answerScore[fullCount - 1] = "T";
                studyEnded = true;
            }
            studyEnded = true;
            //finalTime = startTime;
            //Debug.Log("Final score:" + score + " / 10");
            //Debug.Log("YO 5:" + JsonData[tempVal, 5] + " + " + VehicleGet());
            QuestionNumber.text = "Thank you!";
            Answers.SetActive(false);
            QuestionText.SetActive(false);
            ThankYouMessage.SetActive(true);
            StatMessage.SetActive(true);
            ScoreMessage.text = "Correct answers: " + score + " / 10" +
                                "\nCompletion Time: " + Math.Round(finalTime, 2) + " seconds" +
                                "\nAverage Answer Time: " + Math.Round(AnswerSpeed(answerSpeed), 2) + " seconds" +
                                "\nQ1:  " + Math.Round(answerSpeed[0], 2) + "s | " + answerScore[0] +
                                "     Q2:  " + Math.Round(answerSpeed[1], 2) + "s | " + answerScore[1] +
                                "\nQ3:  " + Math.Round(answerSpeed[2], 2) + "s | " + answerScore[2] +
                                "     Q4:  " + Math.Round(answerSpeed[3], 2) + "s | " + answerScore[3] +
                                "\nQ5:  " + Math.Round(answerSpeed[4], 2) + "s | " + answerScore[4] +
                                "     Q6:  " + Math.Round(answerSpeed[5], 2) + "s | " + answerScore[5] +
                                "\nQ7:  " + Math.Round(answerSpeed[6], 2) + "s | " + answerScore[6] +
                                "     Q8:  " + Math.Round(answerSpeed[7], 2) + "s | " + answerScore[7] +
                                "\nQ9:  " + Math.Round(answerSpeed[8], 2) + "s | " + answerScore[8] +
                                "     Q10: " + Math.Round(answerSpeed[9], 2) + "s | " + answerScore[9];
            Debug.Log(ScoreMessage);
        }
        else
        {

            if (studyStarted == true)
            {
                QuestionNumber.text = "Question #" + fullCount;
                finalTime += Time.deltaTime;
                questionTime += Time.deltaTime;
            }

            if (VehicleGet() == 0)
            {
                VehicleSet(-1);
                //StartTimer();
                //QuestionTimer();
                tempVal = randomQ();
                randomVal = tempVal;
                fullCount++;
                QuestionNumber.text = "Question #" + fullCount;
                Question.text = JsonData[randomVal, 0];
                AnswerA.text = JsonData[randomVal, 1];
                AnswerB.text = JsonData[randomVal, 2];
                AnswerC.text = JsonData[randomVal, 3];
                AnswerD.text = JsonData[randomVal, 4];
                WelcomeMessage.SetActive(false);
                BeginButton.SetActive(false);
                QuestionText.SetActive(true);
                Answers.SetActive(true);
                //VehicleSet(-1);
                finalTime += Time.deltaTime;
                studyStarted = true;
            }

            else if (VehicleGet() == 1)
            {
                if (fullCount <= 10)
                {
                    VehicleSet(-1);
                }
                answerSpeed[fullCount - 1] = questionTime;
                questionTime = 0.0f;
                if (JsonData[tempVal, 5] == "a")
                {
                    score++;
                    answerScore[fullCount - 1] = "T";
                }

                fullCount++;

                if (fullCount <= 10)
                {
                    tempVal = randomQ();
                    randomVal = tempVal;

                    //QuestionNumber.text = "Question #" + fullCount;
                    Question.text = JsonData[randomVal, 0];
                    AnswerA.text = JsonData[randomVal, 1];
                    AnswerB.text = JsonData[randomVal, 2];
                    AnswerC.text = JsonData[randomVal, 3];
                    AnswerD.text = JsonData[randomVal, 4];
                    //VehicleSet(-1);

                    Debug.Log("CHECK HERE: " + answerSpeed);
                }
            }

            else if (VehicleGet() == 2)
            {
                if (fullCount <= 10)
                {
                    VehicleSet(-1);
                }
                answerSpeed[fullCount - 1] = questionTime;
                questionTime = 0.0f;
                if (JsonData[tempVal, 5] == "b")
                {
                    score++;
                    answerScore[fullCount - 1] = "T";
                }

                fullCount++;

                if (fullCount <= 10)
                {
                    tempVal = randomQ();
                    randomVal = tempVal;

                    //QuestionNumber.text = "Question #" + fullCount;
                    Question.text = JsonData[randomVal, 0];
                    AnswerA.text = JsonData[randomVal, 1];
                    AnswerB.text = JsonData[randomVal, 2];
                    AnswerC.text = JsonData[randomVal, 3];
                    AnswerD.text = JsonData[randomVal, 4];
                    /*fullCount++;
                    QuestionNumber.text = "Question #" + fullCount;
                    //Debug.Log("Question " + fullCount + " answer time:" + questionTime);
                    VehicleSet(-1);*/

                    Debug.Log("CHECK HERE: " + answerSpeed);
                }
            }

            else if (VehicleGet() == 3)
            {
                if (fullCount <= 10)
                {
                    VehicleSet(-1);
                }
                answerSpeed[fullCount - 1] = questionTime;
                questionTime = 0.0f;
                if (JsonData[tempVal, 5] == "c")
                {
                    score++;
                    answerScore[fullCount - 1] = "T";
                }

                fullCount++;

                if (fullCount <= 10)
                {
                    tempVal = randomQ();
                    randomVal = tempVal;

                    //QuestionNumber.text = "Question #" + fullCount;
                    Question.text = JsonData[randomVal, 0];
                    AnswerA.text = JsonData[randomVal, 1];
                    AnswerB.text = JsonData[randomVal, 2];
                    AnswerC.text = JsonData[randomVal, 3];
                    AnswerD.text = JsonData[randomVal, 4];

                    Debug.Log("CHECK HERE: " + answerSpeed);
                }
            }

            else if (VehicleGet() == 4)
            {
                if (fullCount <= 10)
                {
                    VehicleSet(-1);
                }
                answerSpeed[fullCount - 1] = questionTime;
                questionTime = 0.0f;
                if (JsonData[tempVal, 5] == "d")
                {
                    score++;
                    answerScore[fullCount - 1] = "T";
                }

                fullCount++;

                if (fullCount <= 10)
                {
                    tempVal = randomQ();
                    randomVal = tempVal;

                    //QuestionNumber.text = "Question #" + fullCount;
                    Question.text = JsonData[randomVal, 0];
                    AnswerA.text = JsonData[randomVal, 1];
                    AnswerB.text = JsonData[randomVal, 2];
                    AnswerC.text = JsonData[randomVal, 3];
                    AnswerD.text = JsonData[randomVal, 4];

                    Debug.Log("CHECK HERE: " + answerSpeed);
                }
            }
        }
    }

    public int randomQ()
    {
        //int[] usedVal = new int[QListSize];

        int rInt;

        while (true)
        {
            Debug.Log("0: " + usedVal[1] + usedVal[2] + usedVal[3] + usedVal[4] + usedVal[5] + usedVal[6] + usedVal[7]);
            System.Random r = new System.Random();
            rInt = r.Next(0, QListSize);
            //usedVal
            if (usedVal.Contains(rInt))
            {
                //Debug.Log("1: " + usedVal.ToString());
                Debug.Log("2: " + rInt);
                continue;
            }
            /*else if (usedVal.All(x => !x.HasValue))
            {
                Debug.Log("2: " + usedVal.ToString());
                break;
            }*/
            else
            {
                //Debug.Log("3: "+ usedVal.ToString());
                Debug.Log("4: " + rInt);
                usedVal[rInt] = rInt;
                Debug.Log("5: " + usedVal[rInt]);
                break;
            }
        }

        //Debug.Log(usedVal.ToString());

        return rInt;
    }

    private void StartTimer()
    {
        //startTimeText.text = "Time: " + Math.Round(startTime, 2) + " seconds";
        startTime += Time.deltaTime;
    }

    private void QuestionTimer()
    {
        //questionTimeText.text = "Time: " + Math.Round(questionTime, 2) + " seconds";
        questionTime += Time.deltaTime;
    }

    private float AnswerSpeed(float[] input)
    {
        float speed = 0.0f;
        for (int i = 0; i < input.Length; i++)
        {
            speed += input[i];
        }
        speed = speed / input.Length;
        return speed;
    }
}
