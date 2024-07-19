using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemnet : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 forceToBeApplied;
    public float forceDamping;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y).normalized;

        Vector2 moveForce = dir * moveSpeed;
        moveForce += forceToBeApplied;
        forceToBeApplied /= forceDamping;

        if(Mathf.Abs(forceToBeApplied.x) <= 0.01f && Mathf.Abs(forceToBeApplied.y) <= 0.01f)
        {
            forceToBeApplied = Vector2.zero;
        }

        rb.velocity = moveForce;
    }
}
