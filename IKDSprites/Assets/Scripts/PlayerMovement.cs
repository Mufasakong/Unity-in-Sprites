using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Rigidbody2D myBody;
    private Animator myAnimator;

    public BoxCollider2D myRope;

    public int speed = 5;

    // Start is called before the first frame update
    void Start()
    {
       myBody = GetComponent<Rigidbody2D>(); 
       myAnimator = GetComponent<Animator>();
       myRope = GetComponent<BoxCollider2D>();
    }

    void OnMovement(InputValue value) {
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0) {
            myAnimator.SetFloat("x", movement.x);
            //myAnimator.SetFloat("y", movement.y);

            myAnimator.SetBool("isWalking", true);
        } else {
            myAnimator.SetBool("isWalking", false);
        }
    }
	void Update()
	{
        if (myBody.rotation < -88 || myBody.rotation > 89) {
            myRope.isTrigger = true;
        } else
		{
            myRope.isTrigger = false;
        }

        if (myBody.position.y <= -10)
		{
            SceneManager.LoadScene("SampleScene");
        }
	}
	// Update is called once per frame
	void FixedUpdate()
    {
        myBody.velocity = movement * speed;
    }
}
