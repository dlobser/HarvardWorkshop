using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emptyScript : MonoBehaviour
{

    public string hi = "Hello World";

    void Start()
    {
        print(hi);
        hi = "Goodbye World";
    }

    void Update()
    {
        print(hi);
    }
}
