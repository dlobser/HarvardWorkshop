using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Create a system that will generate objects which can be interacted with
 * The system should spawn new objects every 'n' seconds
 * The generated objects should destroy themselves when they get old
 * 
 * Examples: Dance Dance Revolution, Beat Saber, Asteroids, Space Invaders
 * 
 * Optional: 
 *      The objects create explosion effects when they're destroyed
 *      The objects scale up from zero when they're born and scale down when they die
 *      Different kinds of objects with different behaviors can be created
 *      When the objects are destroyed they spawn new, smaller objects
 */

public class ThingManager : MonoBehaviour
{

    /* Define a public variable for your instantiatable 'Thing' (public GameObject or public Thing)
     * Define an amount variable to limit the number of things which will be created
     * Define variables to define the initial placement of the things
     * Define a timer variable to set when a new object will spawn
     * Define a frequency variable to set how high the timer will climb
     * Define an amountOfThings variable to keep track of how many there are (optional)
     * Define a 'List' variable to keep track of the objects (optional)
     */

    public Thing thing;
    public int amount;
    public float howBigIsTheCircle;
    private float counter;
    public float timeToInstantiateNewThing = .2f;

    void Start()
    {
        // Create your new list here (optional)
    }

    void Update()
    {
        counter += Time.deltaTime;
        if(counter > timeToInstantiateNewThing){
            counter = 0;
            Vector2 circle = Random.insideUnitCircle;
            circle = circle.normalized*howBigIsTheCircle;
            Vector3 position = new Vector3(circle.x, circle.y, 0);
            Instantiate(thing,position,Quaternion.identity);
        }
        /* use your timer variable to count up until it is larger than your frequency variable (Time.deltaTime)
         * set your timer to 0
         * if amountOfThings is less amount, instantiate a new thing
         * add 1 to amountOfThings (optional)
         * add that thing to your list (optional)
         * parent that thing to a container, such as this.transform (optional)
         */
    }
}
