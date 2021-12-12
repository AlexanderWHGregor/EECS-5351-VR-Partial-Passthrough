using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace qList
{
    public class QuestionList : MonoBehaviour
    {
        public string[,] JsonData;

        void Awake()
        {
            //JsonData = JsonFile();
        }

        // Update is called once per frame
        void Update()
        {
            /*if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log(JsonData[0, 0]);
                Debug.Log(JsonData[0, 1]);
                Debug.Log(JsonData[0, 2]);
                Debug.Log(JsonData[0, 3]);
                Debug.Log(JsonData[0, 4]);
                Debug.Log(JsonData[0, 5]);
            }*/
        }

        public static string[,] JsonFile()
        {
            int count = 0;

            int QuestionListSize = 38;

            bool[] status = new bool[QuestionListSize];
            string[] question = new string[QuestionListSize];
            string[,] answers = new string[QuestionListSize, 4];
            string[] ansA = new string[QuestionListSize];
            string[] ansB = new string[QuestionListSize];
            string[] ansC = new string[QuestionListSize];
            string[] ansD = new string[QuestionListSize];
            string[] actualAns = new string[QuestionListSize];

            string[,] output = new string[QuestionListSize, 6];

            string file = @"[{
                                'questionUsed': false,
                                'question': 'What is 7 + 4?',
                                'a': '11',
                                'b': '74',
                                'c': '10',
                                'd': '12',
                                'actualAnswer': 'a'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 9 + 4?',
                                'a': '10',
                                'b': '13',
                                'c': '12',
                                'd': '11',
                                'actualAnswer': 'b'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 5 + 4?',
                                'a': '10',
                                'b': '11',
                                'c': '9',
                                'd': '54',
                                'actualAnswer': 'c'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 5 + 6?',
                                'a': '12',
                                'b': '2',
                                'c': '15',
                                'd': '11',
                                'actualAnswer': 'd'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 7 + 6?',
                                'a': '13',
                                'b': '1',
                                'c': '10',
                                'd': '12',
                                'actualAnswer': 'a'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 9 + 6?',
                                'a': '11',
                                'b': '15',
                                'c': '14',
                                'd': '12',
                                'actualAnswer': 'b'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 5 + 8?',
                                'a': '12',
                                'b': '3',
                                'c': '13',
                                'd': '11',
                                'actualAnswer': 'c'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 7 + 8?',
                                'a': '11',
                                'b': '14',
                                'c': '16',
                                'd': '15',
                                'actualAnswer': 'd'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 9 + 8?',
                                'a': '17',
                                'b': '1',
                                'c': '19',
                                'd': '15',
                                'actualAnswer': 'a'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 4 - 5?',
                                'a': '0',
                                'b': '-1',
                                'c': '-2',
                                'd': '9',
                                'actualAnswer': 'b'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 4 - 7?',
                                'a': '11',
                                'b': '3',
                                'c': '-3',
                                'd': '-4',
                                'actualAnswer': 'c'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 4 - 9?',
                                'a': '-4',
                                'b': '-3',
                                'c': '13',
                                'd': '-5',
                                'actualAnswer': 'd'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 6 - 5?',
                                'a': '1',
                                'b': '0',
                                'c': '-1',
                                'd': '-2',
                                'actualAnswer': 'a'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 6 - 7?',
                                'a': '2',
                                'b': '-1',
                                'c': '1',
                                'd': '-3',
                                'actualAnswer': 'b'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 6 - 9?',
                                'a': '15',
                                'b': '3',
                                'c': '-3',
                                'd': '-6',
                                'actualAnswer': 'c'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 8 - 5?',
                                'a': '13',
                                'b': '-3',
                                'c': '2',
                                'd': '3',
                                'actualAnswer': 'd'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 8 - 7?',
                                'a': '1',
                                'b': '3',
                                'c': '-1',
                                'd': '15',
                                'actualAnswer': 'a'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 8 - 9?',
                                'a': '1',
                                'b': '-1',
                                'c': '-17',
                                'd': '0',
                                'actualAnswer': 'b'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 4 + 5?',
                                'a': '11',
                                'b': '45',
                                'c': '9',
                                'd': '10',
                                'actualAnswer': 'c'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 4 + 7?',
                                'a': '9',
                                'b': '12',
                                'c': '13',
                                'd': '11',
                                'actualAnswer': 'd'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 4 + 9?',
                                'a': '13',
                                'b': '12',
                                'c': '10',
                                'd': '-5',
                                'actualAnswer': 'a'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 6 + 5?',
                                'a': '1',
                                'b': '11',
                                'c': '12',
                                'd': '10',
                                'actualAnswer': 'b'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 6 + 7?',
                                'a': '10',
                                'b': '-1',
                                'c': '13',
                                'd': '11',
                                'actualAnswer': 'c'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 6 + 9?',
                                'a': '69',
                                'b': '-3',
                                'c': '14',
                                'd': '15',
                                'actualAnswer': 'd'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 8 + 5?',
                                'a': '13',
                                'b': '15',
                                'c': '3',
                                'd': '11',
                                'actualAnswer': 'a'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 8 + 7?',
                                'a': '1',
                                'b': '15',
                                'c': '17',
                                'd': '14',
                                'actualAnswer': 'b'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 8 + 9?',
                                'a': '19',
                                'b': '-1',
                                'c': '17',
                                'd': '18',
                                'actualAnswer': 'c'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 5 - 4?',
                                'a': '-9',
                                'b': '-1',
                                'c': '0',
                                'd': '1',
                                'actualAnswer': 'd'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 7 - 4?',
                                'a': '3',
                                'b': '2',
                                'c': '-3',
                                'd': '0',
                                'actualAnswer': 'a'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 9 - 4?',
                                'a': '-13',
                                'b': '5',
                                'c': '4',
                                'd': '-5',
                                'actualAnswer': 'b'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 5 - 6?',
                                'a': '0',
                                'b': '2',
                                'c': '-1',
                                'd': '-2',
                                'actualAnswer': 'c'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 7 - 6?',
                                'a': '-13',
                                'b': '0',
                                'c': '2',
                                'd': '1',
                                'actualAnswer': 'd'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 9 - 6?',
                                'a': '3',
                                'b': '2',
                                'c': '-13',
                                'd': '-3',
                                'actualAnswer': 'a'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 5 - 8?',
                                'a': '2',
                                'b': '-3',
                                'c': '-1',
                                'd': '3',
                                'actualAnswer': 'b'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 7 - 8?',
                                'a': '1',
                                'b': '2',
                                'c': '-1',
                                'd': '3',
                                'actualAnswer': 'c'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 9 - 8?',
                                'a': '-1',
                                'b': '0',
                                'c': '2',
                                'd': '1',
                                'actualAnswer': 'd'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 12 + 7?',
                                'a': '27',
                                'b': '21',
                                'c': '19',
                                'd': '17',
                                'actualAnswer': 'c'
                              },
                              {
                                'questionUsed': false,
                                'question': 'What is 7 x 3?',
                                'a': '19',
                                'b': '28',
                                'c': '14',
                                'd': '21',
                                'actualAnswer': 'd'
                              }
                            ]";

            string filepath = "Assets/StreamingAssets/QuestionList.json";
            string readResult = string.Empty;

            //using (StreamReader r = new StreamReader(filepath))
            //{
                //var json = r.ReadToEnd();

                //Debug.Log(json.ToString());

                JArray jarr = JArray.Parse(file);

                Debug.Log("HERE: " + jarr[1]);
                readResult = jarr.ToString();

                Debug.Log("Count: " + jarr.Count);

                foreach (JObject item in jarr)
                {
                    status[count] = (bool)item.GetValue("questionUsed");
                    question[count] = (string)item.GetValue("question");

                    answers[count, 0] = (string)item.GetValue("a");
                    answers[count, 1] = (string)item.GetValue("b");
                    answers[count, 2] = (string)item.GetValue("c");
                    answers[count, 3] = (string)item.GetValue("d");

                    ansA[count] = (string)item.GetValue("a");
                    ansB[count] = (string)item.GetValue("b");
                    ansC[count] = (string)item.GetValue("c");
                    ansD[count] = (string)item.GetValue("d");

                    actualAns[count] = (string)item.GetValue("actualAnswer");
                    Debug.Log("YOlo" + item.GetValue("answers"));
                    Debug.Log(item.GetValue("question"));

                    output[count, 0] = question[count];
                    output[count, 1] = ansA[count];
                    output[count, 2] = ansB[count];
                    output[count, 3] = ansC[count];
                    output[count, 4] = ansD[count];
                    output[count, 5] = actualAns[count];

                    count++;
                }
            //}

            Debug.Log("HEY1 " + status[2].ToString());
            Debug.Log("HEY2 " + question[2].ToString());
            Debug.Log("HEY3 " + answers[1, 1].ToString());
            Debug.Log("HEY4 " + actualAns[2].ToString());

            //qList[] testArr = new qList[readResult.Length+1];

            var obj = JsonConvert.DeserializeObject<JArray>(readResult).ToObject<List<JObject>>().GetRange(0, 3);

            Debug.Log("This is that new thing: " + obj[1].GetValue("QuestionUsed"));



            return output;
        }
    }
}
/*
public partial class qList
{
    [JsonProperty("questionUsed")]
    public bool QuestionUsed { get; set; }

    [JsonProperty("question")]
    public string Question { get; set; }

    [JsonProperty("answers")]
    public Answers Answers { get; set; }

    [JsonProperty("actualAnswer")]
    public string ActualAnswer { get; set; }
}

public partial class Answers
{
    [JsonProperty("a")]
    public String A { get; set; }

    [JsonProperty("b")]
    public String B { get; set; }

    [JsonProperty("c")]
    public String C { get; set; }

    [JsonProperty("d")]
    public String D { get; set; }
}
*/