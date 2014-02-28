using UnityEngine;
using System.Collections;

public class FluttershyControllerScript : MonoBehaviour 
{
	public float maxSpeed = 10f;
	bool facingRight = false;
	Animator anim;
	bool Grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700;
	

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	void FixedUpdate ()
	{
		Grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		anim.SetBool ("Grounded", Grounded);

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		float move = Input.GetAxis("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rigidbody2D.velocity = new Vector2 (move*maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight) 
		{
			Flip ();
		} 
		else if (move < 0 && facingRight) 
		{
			Flip ();
		}
	}

	void Update()
	{
		if (Grounded && Input.GetAxis ("Jump") > 0) 
		{
			anim.SetBool("Grounded", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
		
		if (Input.GetButtonDown ("Fire1")) 
			anim.SetTrigger("Attack");
		
		if(Input.GetButtonDown("Dance"))
			anim.SetTrigger("Dance");
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
