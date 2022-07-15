using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TruckController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float torque = 5000f;
    [SerializeField] float breakForce = 10000f;
    [SerializeField] float reverseForce = 1000f;
    [SerializeField] float wheelTurnAccelerator = 1f;
    [SerializeField] float modifier = 100000f;

    // Initialize speed variables
    float verticalAcceleration = 0f;
    float turnAcceleration = 0f;
    Vector2 acceleration = Vector2.zero;
    float xVelocity;
    float force;
    

    Vector2 userInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        userInput = Vector2.zero;
    }

    private void Update()
    {
        Move(userInput);
    }

    void PlayerInput(Vector2 i)
    {
        userInput = i;
    }

    private void Move(Vector2 input)
    {
        // Check for user input
        if (input == Vector2.zero) return;


        // Find what type of acceleration to do based on input
        if (input.y != 0){       

            // is truck direction the same as user direction?
            xVelocity = transform.InverseTransformDirection(rb.velocity).y; // Code taken from https://answers.unity.com/questions/32551/how-do-i-obtain-the-local-velocity-of-a-rigid-body.html
            

            // breaking using break force
            if (xVelocity > 0 && input.y < 0 || xVelocity < 0 && input.y > 0) {
                Debug.Log("Breaking");
                force = breakForce;}

            //accelerating using torque
            else if (input.y > 0){
                Debug.Log("Accelerating");
                force = torque;}
                
            // reversing using reverse force
            else {
                Debug.Log("Reversing");
                force = reverseForce;}
            
            // Apply acceleration
            verticalAcceleration = (input.y * force);
            acceleration.y = verticalAcceleration;
        }

        // Apply torque to vehicle
        rb.AddRelativeForce(acceleration * modifier * Time.deltaTime);
        
    }

    private void OnEnable()
    {
        EventHandler.move += PlayerInput;
    }
    private void OnDisable()
    {
        EventHandler.move -= PlayerInput;
    }
}
