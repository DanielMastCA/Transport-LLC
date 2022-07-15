using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    public static event Action<Vector2> move;

    public static void Move(Vector2 v)
    {
        move?.Invoke(v);
    }
}
