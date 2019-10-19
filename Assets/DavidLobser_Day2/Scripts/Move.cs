using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Simple_Interactable
{
    public Vector3 positionA;
    public Vector3 positionB;

    public float lerpValue;

    public float counter;
    public bool trigger;

	private void Start()
	{
        positionB = Random.insideUnitSphere;
	}

	public override void OnRaycastHit()
	{
        trigger = true;
	}

	void Update()
    {
        if(trigger){
            counter += Time.deltaTime;
            if(counter>1){
                trigger = false;
                counter = 0;
                positionA = positionB;
                positionB = positionB + Random.insideUnitSphere;
            }
        }
        else{
            counter = 0;
        }

        lerpValue = counter;
        lerpValue = Mathf.SmoothStep(0,1,lerpValue);

        this.transform.position = 
            Vector3.LerpUnclamped(positionA, positionB, lerpValue);
       
    }
}
