using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseGeneration : MonoBehaviour
{
    public static float[,] NoiseGenerationMap(int width, int height, float scale, float lacunarity, float persistence, int octaves, int seed, int seedOffset)
    {
        float[,] t = new float[width, height]; //2D array equal to the width and height values
        float maxHeight = float.MinValue;
        float minHeight = float.MaxValue;
        float seedVal = GenerateSeedValue(seed, seedOffset);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float val = 0;
                float frequency = 1;
                float amplitude = 1;
                float maxValue = 0;

                for (int i = 0; i < octaves; i++)
                {
                    float xValue = (x / scale) + seedVal;
                    float yValue = (y / scale) + seedVal;

                    float perlinValue = Mathf.PerlinNoise(xValue * frequency, yValue * frequency) * amplitude;
                    val += perlinValue;

                    maxValue = maxValue + amplitude;
                    amplitude = amplitude * persistence;
                    frequency = frequency * lacunarity;

                    if (val > maxHeight)
                    {
                        maxHeight = val;
                    }

                    else if (val < minHeight)
                    {
                        minHeight = val;
                    }
                }

                t[x, y] = val;
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                t[x, y] = Mathf.InverseLerp(minHeight, maxHeight, t[x, y]);
            }
        }
        return t;
    }

    static float GenerateSeedValue(int seed, int seedOffset)
    {
        System.Random rnd = new System.Random(seed);
        return rnd.Next(-1000, 1000) + seedOffset;
    }
}
