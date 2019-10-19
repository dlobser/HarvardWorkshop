using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    /* Create variables to determine the behavior of this thing
     * such as a vector for moving
     * a vector for eulerangles (rotating)
     * an age
     * a lifespan
     */

    public Vector3 move = Vector3.forward;
    public float maxLife = 10;
    private float counter;

    void Start()
    {
        /* When the object is created, consider randomly setting some of your variables
         * this will help create variety
         */
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        this.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        this.transform.Translate(move * Time.deltaTime);
        counter = counter + Time.deltaTime;
        if(counter>maxLife){
            Destroy(this.gameObject);
        }

        float scale = (Mathf.Cos((counter/maxLife)*Mathf.PI*2)-1)*-.5f;
        this.transform.localScale = new Vector3(scale, scale, scale);
        /* transform your object, move it in some direction 
         * (randomly, toward the camera, out from the center)
         * animate other variables as it travels (optional)
         * add Time.deltaTime to your age variable
         * if age is greater than lifespan, destroy this object
         * GameObject.Destroy(this.gameObject);
         */
    }
}
