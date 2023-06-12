using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordMovement : MonoBehaviour
{
    private Sword sword;
    [field:SerializeField]public Rigidbody2D _Controller { get; private set; }

    public void InitializeSword(Sword sw)
    {
        _Controller = GetComponent<Rigidbody2D>();
        sword = sw;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float callSpeedModifier = 2.0f;
    public void PullToTransform(Transform placeToPull)
    {
        Vector3 target = placeToPull.transform.position;
        Vector3 direction = target - transform.position;
        // Vector3 newVelocity = new Vector3(direction.x * callSpeedModifier, direction.y , 0.00f);
        // Vector3 newVelocity = new Vector3(direction.x * callSpeedModifier, direction.y + (Vector3.Slerp(target, transform.position, sword._DistanceToPlayer).magnitude), 0.00f);
        Vector3 newVelocity = Vector3.Slerp(target, direction, sword._DistanceToPlayer * callSpeedModifier * Time.deltaTime);
        // controller.MovePosition(direction.normalized * callSpeedModifier * Time.deltaTime);
        _Controller.velocity = newVelocity;
    }

    public void SteadyDecreaseVelocity()
    {
        Vector2 slowVector = Vector2.Lerp(_Controller.velocity, Vector2.zero, 0.5f);
        _Controller.velocity = slowVector;
    }
}
