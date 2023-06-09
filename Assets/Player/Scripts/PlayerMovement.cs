using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D moveController;
    [SerializeField] private bool facingRight;

    public void InitializeController()
    {
        moveController = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    public void ZeroStopVelocity()
    {
        moveController.velocity = Vector3.zero;
    }

    public void MoveCharacterHorizontally(float direction, float speed)
    {
        Vector2 newVelocity = new Vector2(direction * speed, moveController.velocity.y);
        moveController.velocity = newVelocity;
        CheckMoveDirection(direction);
    }

    private void CheckMoveDirection(float direction)
    {
        if (direction > 0 && !facingRight) Flip();
        else if (direction < 0 && facingRight) Flip();
    }

    private void Flip()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }

    public void JumpCharacter(float force)
    {
        moveController.AddForce(new Vector2(moveController.velocity.x, force), ForceMode2D.Impulse);
        // moveController.AddForce(new Vector2(moveController.velocity.x, force));
    }
}
