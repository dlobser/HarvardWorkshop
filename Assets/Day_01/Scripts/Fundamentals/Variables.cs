using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public int integerValue;
    public float floatValue;
    public float secondFloatValue;
    public bool isItTrue;

    public string stringValue;
    public Vector3 vectorValue;

    //I didn't mention double or char because they are less common

    //Double is similar to float but with more precision (15 or 16 decimal points vs 6 or 7)

    //char stores a single character

    //This is the start function, everything inside it gets called on start
    void Start()
    {
        
    }

    //This function is called automatically every frame
    //It says "void" because it doesn't return anything
    void Update()
    {
        Debug.Log("Integers are whole numbers, such as: " + integerValue + "\n");
        Debug.Log("Floating point numbers contain decimal points, such as: " + floatValue + "\n");
        Debug.Log("Booleans are true or false: " + isItTrue + "\n");
        Debug.Log("Strings are letters, words and sentences: " + stringValue + "\n");
        Debug.Log("Vectors are special objects which contain 2, 3, or 4 floats: " + vectorValue + "\n");
        Debug.Log("Functions can do things like add numbers together: " + Add(floatValue,secondFloatValue) + "\n");

    }

    //instead of 'void' we use 'float' because it returns a float
    float Add(float A, float B){
        return A + B;
    }
}
