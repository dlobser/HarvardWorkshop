using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBallsManager : MonoBehaviour
{

    public int amountOfBalls;
    public GameObject ball;
    public float spread;

    void Start()
    {
        for (int i = 0; i < amountOfBalls; i++)
        {
            GameObject thisBall = Instantiate(ball);
            thisBall.transform.position = 
                new Vector3(
                    Random.Range(-spread,spread),
                    0,
                    Random.Range(-spread,spread));
            
            //BouncingBall thisBouncingBall = 
                //thisBall.transform.GetChild(0).GetComponent<BouncingBall>();

            BouncingBall thisBouncingBall = 
                thisBall.GetComponentInChildren<BouncingBall>();
            
            thisBouncingBall.Speed = Random.Range(0, 10);
            thisBouncingBall.radius = Random.Range(0, 10);
            thisBouncingBall.Multiplier = Random.Range(0, 3);
            thisBouncingBall.circleSpeed = Random.Range(0, 3);

            thisBouncingBall.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();


        }
    }

    void Update()
    {
        
    }
}
