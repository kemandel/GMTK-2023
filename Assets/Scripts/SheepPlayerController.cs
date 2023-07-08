using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepPlayerController : MonoBehaviour
{
    public bool canMove;
    public float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }
}
