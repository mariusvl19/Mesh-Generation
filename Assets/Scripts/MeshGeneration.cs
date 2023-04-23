using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneration : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] float heightAmplifier;
    [SerializeField] float heightMap;
    [SerializeField] MeshFilter meshFilter;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Mesh MeshGen(int width, int height, float heightAmplifier, float[,] heightMap)
    {
        Mesh meshData = new Mesh();
        Vector3[] verts = new Vector3[height * width];
        Vector2[] uvs = new Vector2[height * width];
        int[] tris = new int[(width - 1) * (height - 1) * 6];

        int countVerts = 0;
        int countTris = 0;
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                verts[countVerts] = new Vector3(x, heightMap[x, y] * heightAmplifier, y);
                uvs[countVerts] = new Vector2((float)x / width, (float)y / height);

                

                if (x < width - 1 && y < height - 1)
                {
                    tris[countTris] = countVerts;
                    tris[countTris + 1] = countVerts + width + 1;
                    tris[countTris + 2] = countVerts + 1;
                    tris[countTris + 3] = countVerts;
                    tris[countTris + 4] = countVerts + width;
                    tris[countTris + 5] = countVerts + width + 1;
                   
                   
                    
                    
                  

                    
                    countTris += 6;
                }
                countVerts++;
            }
        }



        meshData.vertices = verts;
        meshData.triangles = tris;
        meshData.uv = uvs;
       
        return meshData;

    }

}

