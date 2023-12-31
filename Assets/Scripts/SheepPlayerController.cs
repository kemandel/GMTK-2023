using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepPlayerController : MonoBehaviour
{
    public bool canMove;
    public float speed = 5f;
    public float UIAlpha = .6f;

    private Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (canMove)
        {
            Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        GetComponentInChildren<Animator>().SetBool("canMove", canMove);
        GetComponentInChildren<Animator>().SetFloat("X", GetComponent<Rigidbody2D>().velocity.x);
        GetComponentInChildren<Animator>().SetFloat("Y", GetComponent<Rigidbody2D>().velocity.y);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position + Vector3.down * .5f, .7f);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].CompareTag("Plot"))
                {
                    hits[i].GetComponent<Plot>().FreeHuman();
                    break;
                }
            }
        }
    }

    public IEnumerator DayCoroutine()
    {
        canMove = false;

        float transitionTime = FindObjectOfType<TransitionUI>().transitionTime;
        // Fade out body
        StartCoroutine(LevelManager.FadeSpriteCoroutine(GetComponentsInChildren<SpriteRenderer>()[0], 0, transitionTime/2));
        // Fade out UI
        StartCoroutine(LevelManager.FadeSpriteCoroutine(GetComponentsInChildren<SpriteRenderer>()[1], 0, transitionTime/2));
        yield return new WaitForSeconds(transitionTime/2);
        // Reset position and animation
        transform.position = startingPos;
        GetComponentInChildren<Animator>().SetTrigger("Reset");
        // Fade in body
        StartCoroutine(LevelManager.FadeSpriteCoroutine(GetComponentsInChildren<SpriteRenderer>()[0], 1, transitionTime/2));
        // Fade in wig
        StartCoroutine(LevelManager.FadeSpriteCoroutine(GetComponentsInChildren<SpriteRenderer>()[2], 1, transitionTime/2));

    }

    /// <summary>
    /// Fades in the control prompt and enables control at night
    /// </summary>
    /// <returns></returns>
    public IEnumerator NightCoroutine()
    {
        float transitionTime = FindObjectOfType<TransitionUI>().transitionTime;
        yield return new WaitForSeconds(transitionTime);
        GetComponentInChildren<Animator>().SetTrigger("Reveal");
        StartCoroutine(LevelManager.FadeSpriteCoroutine(GetComponentsInChildren<SpriteRenderer>()[2], 0, .75f));
        yield return new WaitForSeconds(transitionTime/4);
        StartCoroutine(LevelManager.FadeSpriteCoroutine(GetComponentsInChildren<SpriteRenderer>()[1], 1 * UIAlpha, transitionTime));
        yield return new WaitForSeconds(transitionTime/4);
        canMove = true;
    }
}
