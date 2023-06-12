using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    private Sword sword;
    private Rigidbody2D controller;

    public void InitializeSword(Sword sw)
    {
        controller = GetComponent<Rigidbody2D>();
        sword = sw;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PullToTransform(Transform placeToPull)
    {
        Vector2 lerpedPos = Vector2.Lerp(transform.position, placeToPull.position, Vector2.Distance(sword.transform.position, placeToPull.position) * Time.deltaTime);
        print(lerpedPos);
        if (sword._Player.transform.position.x < transform.position.x) controller.velocity = lerpedPos;
        else controller.velocity = new Vector2(-lerpedPos.x, lerpedPos.y);
        // controller.MovePosition(placeToPull.position);
    }
}
