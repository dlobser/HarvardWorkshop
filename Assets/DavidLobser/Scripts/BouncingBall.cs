using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    public float Speed;
    public float Multiplier;
    public float radius;
    public float circleSpeed;
    Vector3 bouncy;

	private void Update()
	{
        float movement = Time.time * Speed;
        float sineMovement = Mathf.Sin(movement);
        float absoluteSine = Mathf.Abs(sineMovement) * Multiplier;

        bouncy.Set(Mathf.Sin(Time.time*circleSpeed)*radius,
                   absoluteSine, 
                   Mathf.Cos(Time.time*circleSpeed)*radius);

        this.transform.localPosition = bouncy;
	}

}

