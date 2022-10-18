using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask detectLayer;
    public GameObject happyFace;
    public GameObject angryFace;
    public bool isHappy;
    private Vector2 moveDirection;
    public float checkDistance = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveDirection = Vector2.right;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            moveDirection = Vector2.left;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveDirection = Vector2.up;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            moveDirection = Vector2.down;
        }

        if (moveDirection != Vector2.zero)
        {
            if (CanMoveToDirection(moveDirection))
            {
                Move(moveDirection);
            }
        }

        moveDirection = Vector2.zero;

        ChangeToHappyFace();
        ChangeToAngryFace();

    }

    private void Move(Vector2 moveDirection)
    {
        transform.Translate(moveDirection);
    }

    public bool CanMoveToDirection(Vector2 moveDirection)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, checkDistance, detectLayer);

        if (!hit)
        {
            return true;
        }else
        {
            if (hit.collider.GetComponent<Box>() != null)
            {
                return hit.collider.GetComponent<Box>().CanMoveToDirection(moveDirection);
            }

            if (hit.collider.GetComponent<Cat>() != null)
            {
                return hit.collider.GetComponent<Cat>().CanMoveToDirection(moveDirection);
            }
        }

        return false;

    }


    public void ChangeToHappyFace()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            happyFace.SetActive(true);
            angryFace.SetActive(false);
            isHappy = true;
        }

    }

    public void ChangeToAngryFace()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            happyFace.SetActive(false);
            angryFace.SetActive(true);
            isHappy = false;
        }
    }

    private void ChangeFace()
    {
        if (Input.GetKeyDown(KeyCode.F) && isHappy)
        {
            happyFace.SetActive(false);
            angryFace.SetActive(true);
            isHappy = false;
        }

        if (Input.GetKeyDown(KeyCode.F) && !isHappy)
        {
            happyFace.SetActive(true);
            angryFace.SetActive(false);
            isHappy = true;
        }

    }

}
