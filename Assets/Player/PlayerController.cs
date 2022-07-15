using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using System;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(NetworkObject))]
public class PlayerController : NetworkBehaviour
{
    float horizontal;
    float vertical;
    Vector2 offset;

    [SerializeField] float moveSpeed = 5f;
    CharacterController characterController;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        horizontal = 0f;
        vertical = 0f;
        offset = Vector2.zero;

        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    [Client(RequireOwnership = true)]
    void UserInput(Vector2 v)
    {
        vertical = v.y;
        horizontal = v.x;
    }

    [Client(RequireOwnership = true)]
    private void Move()
    {
        offset = new Vector2(horizontal, vertical) * (moveSpeed * Time.deltaTime);

        characterController.Move(offset);
    }

    private void OnEnable()
    {
        EventHandler.move += UserInput;
    }

    private void OnDisable()
    {
        
    }
}
