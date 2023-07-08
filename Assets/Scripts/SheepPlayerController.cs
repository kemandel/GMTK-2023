using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepPlayerController : MonoBehaviour
{
    public bool canMove;
    public float speed = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (canMove)
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 1.5f, Vector2.down);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.CompareTag("Plot"))
                    hits[i].collider.GetComponent<Plot>().FreeHuman();
            }
        }
    }
}
