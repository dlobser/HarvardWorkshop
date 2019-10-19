using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectManager : MonoBehaviour
{
    public Move lerpingObject;
    public int amount;
    public bool trigger;
    public Move[] lerpingObjects;

    void Start()
    {
        lerpingObjects = new Move[amount];

        for (int i = 0; i < amount; i++)
        {
            Move move = Instantiate(lerpingObject);
            lerpingObjects[i] = move;
        }
    }

    void Update()
    {
        if (trigger)
        {
            for (int i = 0; i < amount; i++)
            {
                lerpingObjects[i].trigger = true;
            }

            trigger = false;
        }
    }
}
