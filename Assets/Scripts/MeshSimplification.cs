using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeshSimplification : MonoBehaviour
{
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] float heightAmplifier;
    [SerializeField] float noiseMap;
    [SerializeField] int maxMapSize;
    MeshCollider meshCollider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //MeshSimp((float)maxMapSize,heightAmplifier,noiseMap);
    }

    public static Mesh MeshSimp(int maxMapSize, float heightAmplifier, float[,] noiseMap)
    {
        Mesh mesh = new Mesh();
        Vector3[] verts = new Vector3[maxMapSize];
        int[] tris = new int[maxMapSize];
        int countVerts = 0;
        int countTris = 0;

        int factor = 4;
        int vertsPerLine = ((maxMapSize - 1) / factor) + 1;

        for(int x = 0; x < maxMapSize; x+= factor)
        {
            for(int y = 0; y < maxMapSize; y+= factor)
            {
                verts[countVerts] = new Vector3(x, noiseMap[x, y] * heightAmplifier, y);

                if(x < maxMapSize - 1 && y < maxMapSize - 1)
                {
                    tris[countTris] = countVerts;
                    tris[countTris + 1] = countVerts + vertsPerLine + 1;
                    tris[countTris + 2] = countVerts + 1;
                    tris[countTris + 3] = countVerts;
                    tris[countTris + 4] = countVerts + vertsPerLine;
                    tris[countTris + 5] = countVerts + vertsPerLine + 1;

                    countTris += 6;
                }
                countVerts++;
            }
        }

        //MeshCollider.sharedMesh = MeshSimp();

        mesh.vertices = verts;
        mesh.triangles = tris;

        return mesh;
    }
}
