using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    [SerializeField]private Collider2D objectBody;

    [SerializeField] private float rayDistance = 0.015f;
    [SerializeField] private Vector2 rayHorizontalModifier;
    [SerializeField] private LayerMask groundLayers;

    [SerializeField] public bool _IsGrounded()
    {
        Vector2 rayStart = objectBody.bounds.center;
        Color rayColor = Color.red;
        RaycastHit2D middleRay = Physics2D.Raycast(rayStart, Vector2.down, objectBody.bounds.extents.y + rayDistance, groundLayers);
        Debug.DrawRay(rayStart, Vector2.down * (objectBody.bounds.extents.y + rayDistance), rayColor, 0.02f);
        RaycastHit2D leftRay = Physics2D.Raycast(rayStart - rayHorizontalModifier, Vector2.down, objectBody.bounds.extents.y + rayDistance, groundLayers);
        Debug.DrawRay(rayStart - rayHorizontalModifier, Vector2.down * (objectBody.bounds.extents.y + rayDistance), rayColor, 0.02f);
        RaycastHit2D rightRay = Physics2D.Raycast(rayStart + rayHorizontalModifier, Vector2.down, objectBody.bounds.extents.y + rayDistance, groundLayers);
        Debug.DrawRay(rayStart + rayHorizontalModifier, Vector2.down * (objectBody.bounds.extents.y + rayDistance), rayColor, 0.02f);

        if (middleRay.collider != null || leftRay.collider != null || rightRay.collider != null)
        {
            rayColor = Color.green;
            return true;
        }
        else
        {
            rayColor = Color.red;
            return false;
        }
    }

    private void Awake()
    {
        objectBody = transform.Find("Body").GetComponent<Collider2D>();
        groundLayers = LayerMask.GetMask("Walkable");
        rayHorizontalModifier.x = objectBody.bounds.extents.x;
    }
    
    // end
}
