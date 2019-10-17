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

    void Start()
    {
        /* When the object is created, consider randomly setting some of your variables
         * this will help create variety
         */
    }

    void Update()
    {
        /* transform your object, move it in some direction 
         * (randomly, toward the camera, out from the center)
         * animate other variables as it travels (optional)
         * add Time.deltaTime to your age variable
         * if age is greater than lifespan, destroy this object
         * GameObject.Destroy(this.gameObject);
         */
    }
}
