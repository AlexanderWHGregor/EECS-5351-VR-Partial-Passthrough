using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

public class ContourMap
{
    //Creates contour map from Raw 16bpp heightmap data as Texture2D
    //Returns null on failure
    //If neither width nor height specified, then it's POT size will be guessed
    public static Texture2D FromRawHeightmap16bpp(string fileName, Gradient gradientVal, int width = 0, int height = 0)
    {
        if (!File.Exists(fileName))
        {
            Debug.Log("Heightmap not found " + fileName);
            return null;
        }

        //Debug.Log(gradientVal);

        //Debug.Log(gradientVal.Evaluate(0.25f));

        //Debug.Log(gradientVal.Evaluate(0.50f));

        //Debug.Log(gradientVal.Evaluate(0.75f));


        /*Gradient gradient;
        GradientColorKey[] colorKey;
        GradientAlphaKey[] alphaKey;

        gradient = new Gradient();

        // Populate the color keys at the relative time 0 and 1 (0 and 100%)
        colorKey = new GradientColorKey[2];
        colorKey[0].color = Color.red;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.blue;
        colorKey[1].time = 1.0f;

        // Populate the alpha  keys at relative time 0 and 1  (0 and 100%)
        alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 1.0f;

        gradient.SetKeys(colorKey, alphaKey);

        // What's the color at the relative time 0.25 (25 %) ?
        Debug.Log(gradient.Evaluate(0.25f));*/




        //dimensions
        int _width = width;
        int _height = height;

        //Color[] colorsVal;

        Color32 bandColor = new Color32(0, 0, 0, 255);
        Color32 bkgColor = new Color32(170, 244, 247, 0);

        //Output
        Texture2D topoMap;
        Texture2D topoMapOutput;

        //Read raw 16bit heightmap
        byte[] rawBytes = System.IO.File.ReadAllBytes(fileName);
        short[] rawImage = new short[rawBytes.Length / 2];

        //Create slice buffer
        bool[] slice = new bool[rawImage.Length];

        //Convert to bytes to short
        Buffer.BlockCopy(rawBytes, 0, rawImage, 0, rawBytes.Length);

        //Create Texture2D with estimated or specified width
        if (_width == 0 || _height == 0)
        {
            _width = (int)Math.Sqrt(rawImage.Length); //Estimated width/height
            _height = _width;
            topoMap = new Texture2D(_width, _height);
        }
        else
        {
            topoMap = new Texture2D(_width, _height);
        }

        topoMap.anisoLevel = 16;

        //Set background
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                topoMap.SetPixel(x, y, bkgColor);
            }
        }

        //Initial Min/Max values for signed 16bit value
        int minHeight = 32767;
        int maxHeight = -32767;
        int waterLevel = 13100; // ## A temp value
        int maxDepth = 0;
        float colourBand;

        //colours = new Color[];

        //Find lowest and highest points
        for (int i = 0; i < rawImage.Length; i++)
        {
            if (rawImage[i] < minHeight)
            {
                minHeight = rawImage[i];
            }
            if (rawImage[i] > maxHeight)
            {
                maxHeight = rawImage[i];
            }
        }

        //10 Metres for some reason
        int bandDistance = 100;

        // ## Level out the map
        //minHeight -= waterLevel;
        //maxHeight -= waterLevel;

        Debug.Log("Min: " + minHeight.ToString() + ", Max: " + maxHeight.ToString());

        

        //Create height band list
        //int bandDistance = maxHeight / 12; //Number of height bands to create, ## Based roughly on total height

        List<int> bands = new List<int>();

        //Get ranges
        int r = waterLevel;// + bandDistance;
        int flsDepth = r - 1000;
        Debug.Log("This is r:" + r);
        while (r > flsDepth)
        {
            bands.Add(r);
            r -= bandDistance;
        }

        //bands.Reverse();

        /*colorsVal = new Color[maxHeight];

        for (int i = 0, z = 0; z <= minHeight; z++)
        {
            for (int x = 0; x <= maxHeight; x++)
            {
                float heightVal = bands[i];
                colorsVal[i] = gradientVal.Evaluate(heightVal);
                i++;
            }
        }*/

        //Debug.Log(gradientVal.Evaluate(0.25f));

        //Draw bands
        for (int b = 0; b < bands.Count; b++)
        {

            //Get Slice
            for (int i = 0; i < rawImage.Length; i++)
            {
                if (rawImage[i] >= bands[b])
                {
                    slice[i] = true;
                }
                else
                {
                    slice[i] = false;
                }
            }

            

            //Detect edges on slice and write to output
            for (int y = 1; y < _height - 1; y++)
            {
                for (int x = 1; x < _width - 1; x++)
                {
                    if (slice[y * _width + x] == true)
                    {
                        if (slice[y * _width + (x - 1)] == false || slice[y * _width + (x + 1)] == false || slice[(y - 1) * _width + x] == false || slice[(y + 1) * _width + x] == false)
                        {
                            colourBand = ((float)bands[b]-flsDepth) / ((float)waterLevel-flsDepth);
                            topoMap.SetPixel(x, y, gradientVal.Evaluate(colourBand));

                            //Debug.Log("Band " + bands[b]);
                            //Debug.Log("Colour " + colourBand);

                        }
                    }
                }
            }

        }

        topoMap.Apply();

        topoMapOutput = topoMap;

        //Save To Disk as PNG
        byte[] bytes = topoMapOutput.EncodeToPNG();
        var dirPath = Application.dataPath + "/../SaveImages/";
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        File.WriteAllBytes(dirPath + "ImageNew" + ".png", bytes);

        //Return result
        return topoMap;
    }
}