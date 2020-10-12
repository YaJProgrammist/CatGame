using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public abstract class PlayerMovingBehavior
{
    protected Rigidbody2D currentRigidbody;

    public PlayerMovingBehavior(Rigidbody2D rigidbody)
    {
        currentRigidbody = rigidbody;
    }

    public abstract void Move();
}
