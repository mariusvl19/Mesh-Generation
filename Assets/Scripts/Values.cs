using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Values : MonoBehaviour
{
    public static Values instance;
    [SerializeField] public int width;
    [SerializeField] public int height;
    [SerializeField] public float scale;
    [SerializeField] public float lacunarity;
    [SerializeField] public float persistence;
    [SerializeField] public int seed;
    [SerializeField] public int seedOffset;
    [SerializeField] public int octaves;
    [SerializeField] public float heightAmplifier;
    [SerializeField] public float noiseMap;
    [SerializeField] public Renderer textureRenderer;
    [SerializeField] public MeshFilter filter;
    [SerializeField] public Color[] colours;

    
    void Awake()
    {
        instance = this;
    }

}
