using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTerrain : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) //when the spacebar is pressed, call Generate
        {
            Generate();
        }
    }

   
    void Generate()
    {
        float[,] noiseMap = NoiseGeneration.NoiseGenerationMap(Values.instance.width,
                                                                Values.instance.height,
                                                                Values.instance.scale,
                                                                Values.instance.lacunarity,
                                                                Values.instance.persistence,
                                                                Values.instance.octaves,
                                                                Values.instance.seed,
                                                                Values.instance.seedOffset);
        Texture2D tex = DrawNoise.DrawNoiseMap(noiseMap);

        Mesh mesh = MeshGeneration.MeshGen(Values.instance.width, Values.instance.height,
                                           Values.instance.heightAmplifier, noiseMap);
        Values.instance.filter.mesh = mesh;

        Values.instance.textureRenderer.sharedMaterial.mainTexture = tex;
    }

   
    
}

