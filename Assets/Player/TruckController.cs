using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TruckController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float acceleration;

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

    private void Move(Vector2 i)
    {
        rb.AddForce(i * acceleration * Time.deltaTime);
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
