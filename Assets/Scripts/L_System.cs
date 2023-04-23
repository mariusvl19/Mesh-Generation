using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class L_System : MonoBehaviour
{
    [SerializeField] GameObject Turtle;
    //GameObject TurtleChild;
    //[SerializeField] GameObject Point;
    [SerializeField]float Length = 0.4f;
    [SerializeField]int NumberOfIterations = 6;
    [SerializeField]int Angle = 25;
    string Axiom = "X";
    //Create a dictionary
    Dictionary<char, string> recursionRules = new Dictionary<char, string>();
    // Start is called before the first frame update
    void Start()
    {
        
        //Add the key pairs in recursionRules variable
        recursionRules.Add('X', "F+[[X]-X]-F[-FX]+X");
        recursionRules.Add('F', "FF");
        GenerateString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    struct TransformData
    {
        public Vector3 position;
        public Quaternion rotation;
    }


    Stack<TransformData> _transformData = new Stack<TransformData>();

    void GenerateString()
    {
        string tempString = Axiom;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < NumberOfIterations; i++)
        {
            foreach (char character in tempString)
            {
                
                
                //Checking if the dictionary holds a key
                if (recursionRules.ContainsKey(character))
                {
                    sb.Append(recursionRules[character]);
                }
                else
                {
                    //Add the char only to the temporary string
                    sb.Append(character);
                }
            }
            //Set tempString to the newly constructed StringBuilder variable
            tempString = sb.ToString();
            sb = new StringBuilder();
        }
        ApplyRules(tempString);
    }

    void ApplyRules(string recursContructedTempString)
    {
        bool firstIteration = true;
        GameObject parent = new GameObject();
        foreach (char character in recursContructedTempString)
        {
            
            if (firstIteration)
            {
                parent = new GameObject();
                Turtle.transform.parent = parent.transform;
                firstIteration = false;
            }
            switch (character)
            {
                case 'X':

                    break;

                case 'F':
                    Vector3 turtlePos = Turtle.transform.position;
                    Turtle.transform.Translate(Vector3.up * 1);
                    GameObject tempTurtle = Instantiate(Turtle, turtlePos, Quaternion.identity);
                    tempTurtle.transform.parent = parent.transform;
                    
                    LineRenderer LR = tempTurtle.GetComponent<LineRenderer>();
                    
                    //LR.SetPosition(0, turtlePos);
                   // LR.SetPosition(1, tempTurtle.transform.position);
                    break;

                case '+':
                    Turtle.transform.Rotate(Angle, 0, 0);
                    break;

                case '-':
                    Turtle.transform.Rotate(-Angle, 0, 0);
                    break;

                case '[':
                    TransformData TD = new TransformData
                    {
                        position = Turtle.transform.position,
                        rotation = Turtle.transform.rotation
                    };
                   
                  
                    _transformData.Push(TD);
                    

                    break;

                case ']':
                    TransformData tData = _transformData.Pop();
                   Turtle.transform.position = tData.position;
                   Turtle.transform.rotation = tData.rotation;
                    break;
            }
        }
    }
}
