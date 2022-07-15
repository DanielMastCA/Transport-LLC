using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public void OnMove(InputValue v)
    {
        EventHandler.Move(v.Get<Vector2>());
    }
}
