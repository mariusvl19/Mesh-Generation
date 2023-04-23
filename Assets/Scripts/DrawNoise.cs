using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawNoise : MonoBehaviour
{
    public static Texture2D DrawNoiseMap(float[,] noiseMap)
    {
        int mapWidth, mapHeight;
        mapWidth = noiseMap.GetLength(0);
        mapHeight = noiseMap.GetLength(1);
        Texture2D tex = new Texture2D(mapWidth, mapHeight);

        Color[] colourMap = new Color[mapWidth * mapHeight];
        float[] colourMapValues = new float[mapWidth * mapHeight];

        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                float t = noiseMap[x, y];
                for(int i = 0; i < Values.instance.colours.Length; i++)
                {
                    //colourMap[y * mapWidth + x] = Color.Lerp(Color.white, Color.black, noiseMap[x, y]);
                    colourMapValues[y * mapWidth + x] = noiseMap[x, y];
                    //Debug.Log(colourMap[y * mapWidth + x]);
                }


            }
        }
        ColourMap(ref colourMap, colourMapValues);
        tex.SetPixels(colourMap);
        tex.Apply();
        tex.wrapMode = TextureWrapMode.Repeat;
        tex.filterMode = FilterMode.Trilinear;
        
        return tex;
    }


    static void ColourMap(ref Color[] colourArray, float[] colourMapValues)
    {
        for (int i = 0; i < colourMapValues.Length; i++)
        {
            switch (colourMapValues[i])
            {
                case float n when (n >= 0.9):
                    colourArray[i] = Values.instance.colours[0];
                    break;

                case float n when (n >= 0.7):
                    colourArray[i] = Values.instance.colours[1];
                    break;

                case float n when (n >= 0.5):
                    colourArray[i] = Values.instance.colours[2];
                    break;

                case float n when (n >= 0.3):
                    colourArray[i] = Values.instance.colours[3];
                    break;

            }
        }


    }

}
