using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Transform myTransform;
    private Rigidbody2D myBody;
    private Animator myAnimation;
    [SerializeField] private int speed = 1;

    float posX;
    float posY;
    
    // public float jumpForce = 10f;

    // Start is called before the first frame update
    private void Awake()
    {
        myTransform = GetComponent<Transform>();
        myBody = GetComponent<Rigidbody2D>();
        myAnimation = GetComponent<Animator>();
    }

    //Update is called once every frame
    void Update() {
       Vector3 currentPos = myTransform.position;

        // Set the players position to the other side
        currentPos.x = currentPos.x > 10 ? -10 : (currentPos.x < -10 ? 10 : currentPos.x);
        currentPos.y = currentPos.y > 7 ? -7 : (currentPos.y < -7 ? 7 : currentPos.y);

        myTransform.position = currentPos;
    } 

    // Updates animation based on movement
    private void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();

        if (movement.x !=0 || movement.y !=0) {
            myAnimation.SetFloat("x", movement.x);
            myAnimation.SetFloat("y", movement.y);
            myAnimation.SetBool("isWalking", true);
        }else{
            myAnimation.SetBool("isWalking", false);
        }

    }

    private void FixedUpdate(){
        myBody.velocity = movement * speed; //Updates the speed of the player
        
        /*if (Input.GetKeyDown(KeyCode.Space)) {  
        myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //Weak jump attempt
        }*/
    }

}
