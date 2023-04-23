using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TerrainGeneration : EditorWindow
{
    [SerializeField] int _width;
    [SerializeField] int _height;
    [SerializeField] int _octaves;
    [SerializeField] int _seed;
    [SerializeField] int _seedOffset;
    [SerializeField] float _scale;
    [SerializeField] float _lacunarity;
    [SerializeField] float _persistence;
    [SerializeField] float _scalar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [MenuItem("Tools/Procedural Generation")]
    public static void ShowWindow()
    {
        GetWindow(typeof(TerrainGeneration));
    }

    private void OnGUI()
    {
        EditorGUILayout.Space();
        GUILayout.Label(text: "Configure Terrain", EditorStyles.largeLabel);
        EditorGUILayout.Space();
        _width = EditorGUILayout.IntField("Terrain Width", _width);
        _height = EditorGUILayout.IntField("Terrain Height", _height);
        _octaves = EditorGUILayout.IntField("Octaves", _octaves);
        _seed = EditorGUILayout.IntField("Seed", _seed);

        _scale = EditorGUILayout.FloatField("NoiseScale", _scale);
        _lacunarity = EditorGUILayout.FloatField("Lacunarity", _lacunarity);
        _persistence = EditorGUILayout.FloatField("Persistence", _persistence);
        _scalar = EditorGUILayout.FloatField("Scalar", _scalar);

        //to do: add colour variables: mountain tops as an example

        if (GUILayout.Button("Create Terrain"))
        {
            GameObject obj = CreateMeshTemplate();
            //add the methods used to create the mesh
            //DrawNoise method to create the texture
        }
    }

    private GameObject CreateMeshTemplate()
    {
        GameObject obj = new GameObject();
        obj.AddComponent<MeshFilter>();
        obj.AddComponent<MeshRenderer>();

        //add material

        return obj;
    }


}

