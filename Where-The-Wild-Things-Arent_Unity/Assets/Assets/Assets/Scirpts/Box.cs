using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float testDistance = 0.5f;
    public bool CanMoveToDirection(Vector2 moveDirection)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)moveDirection *testDistance , moveDirection, testDistance);

       if (!hit)
        {
            transform.Translate(moveDirection);
            return true;
        }
        return false;
    }
}
