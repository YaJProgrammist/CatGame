﻿using UnityEngine;

class Running : PlayerMovingBehavior
{
    private Vector2 velocityVector;

    public Running(Rigidbody2D rigidbody) : base (rigidbody)
    {
        velocityVector = new Vector2(1.5f, 0);
    }

    public override void Move()
    {
        currentRigidbody.velocity = velocityVector;
    }
}