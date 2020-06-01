using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public Transform aimTarget;
    public Transform ball;
    float speed=4f;
    float force=13;
    bool hitting;
    Animator animator;
    Vector3 aimTargetInitialPosition;
    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>(); 
       aimTargetInitialPosition = aimTarget.position;	
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
	float v = Input.GetAxisRaw("Vertical");
	
	if(Input.GetKeyDown(KeyCode.F))
	{
		hitting=true;
	}
	else if(Input.GetKeyUp(KeyCode.F))
	{
		hitting=false;
	}
	if(hitting)
	{
		aimTarget.Translate(new Vector3(0,0,h)*speed*Time.deltaTime);
	}
    	
	if( (h!=0 || v!=0) && !hitting )
	{
		transform.Translate( new Vector3(-v,0,h)*speed*Time.deltaTime);
	}
    }

    private void OnTriggerEnter(Collider other)
    {
	if(other.CompareTag("Ball"))
	{
		Vector3 dir= aimTarget.position - transform.position;
		other.GetComponent<Rigidbody>().velocity=dir.normalized*force+new Vector3(0,6,0);
		Vector3 ballDir = ball.position - transform.position;
		if(ballDir.x >+ 0)
		{ 
			animator.Play("forehand");
			
     		}
		else
		{
			animator.Play("backhand");
			
		}
		aimTarget.position = aimTargetInitialPosition;
	}		
    }
}
