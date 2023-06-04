using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D moveController;

    public void InitializeController()
    {
        moveController = GetComponent<Rigidbody2D>();
    }

    public void ZeroStopVelocity()
    {
        moveController.velocity = Vector3.zero;
    }

    public void MoveCharacterHorizontally(float direction, float speed)
    {
        Vector2 newVelocity = new Vector2(direction * speed, moveController.velocity.y);
        moveController.velocity = newVelocity;
    }
}
