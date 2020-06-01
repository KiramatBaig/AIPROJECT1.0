using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot : MonoBehaviour
{

    float speed = 4f; // moveSpeed
    Animator animator;
    public Transform ball;
    public Transform aimTarget; // aiming gameObject
    float force = 13;

    
    Vector3 targetPosition; // position to where the bot will want to move



    void Start()
    {
        targetPosition = transform.position; 
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move(); // calling the move method
    }

    void Move()
    {
        targetPosition.z = ball.position.z; // update the target position to the ball's x position so the bot only moves on the x axis
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // lerp it's position
    }
    private void OnTriggerEnter(Collider other)
    {
	if(other.CompareTag("Ball"))
	{
		Vector3 dir= aimTarget.position - transform.position;
		other.GetComponent<Rigidbody>().velocity=dir.normalized*force+new Vector3(0,6,0);
		Vector3 ballDir = ball.position - transform.position;
		if(ballDir.z >+ 0)
		{ 
			animator.Play("forehand");
			
     		}
		else
		{
			animator.Play("backhand");
			
		}
	}

    }
    

    
    
}