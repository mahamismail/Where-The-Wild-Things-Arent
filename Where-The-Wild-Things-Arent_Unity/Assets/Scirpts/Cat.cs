using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private PlayerController pc;
    private GameManager gm;

    public float testDistance = 0.5f;
    void Start()
    {
         pc = GameObject.Find("Player").GetComponent<PlayerController>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    public bool CanMoveToDirection(Vector2 moveDirection)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)moveDirection * testDistance, moveDirection, testDistance);

        if (!hit && !pc.isHappy)
        {
            transform.Translate(moveDirection * 2);
            return true;
        }
        return false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("End"))
        {
            gm.isGameOver = true;
            Debug.Log("You Win!");
        }
    }
}
