using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepPlayerController : MonoBehaviour
{
    public bool canMove;
    public float speed = 5f;
    public float UIAlpha = .6f;

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

    public IEnumerator DayCoroutine()
    {
        canMove = false;
        float transitionTime = FindObjectOfType<TransitionUI>().transitionTime;
        yield return new WaitForSeconds(transitionTime/2);

        float timeStart = Time.time;
        float timePast = 0f;
        Color oldColor = gameObject.GetComponentsInChildren<SpriteRenderer>()[1].color;

        while (timePast < transitionTime/2)
        {
            yield return null;
            timePast = Time.time - timeStart;
            float ratio = timePast / (transitionTime / 2);
            float a = Mathf.Lerp(1 * UIAlpha, 0, Mathf.Clamp01(ratio));
            gameObject.GetComponentsInChildren<SpriteRenderer>()[1].color = new Color(oldColor.r, oldColor.g, oldColor.b, a);
        }
    }

    /// <summary>
    /// Fades in the control prompt and enables control at night
    /// </summary>
    /// <returns></returns>
    public IEnumerator NightCoroutine()
    {
        canMove = true;
        float transitionTime = FindObjectOfType<TransitionUI>().transitionTime;
        yield return new WaitForSeconds(transitionTime/2);

        float timeStart = Time.time;
        float timePast = 0f;
        Color oldColor = gameObject.GetComponentsInChildren<SpriteRenderer>()[1].color;

        while (timePast < transitionTime/2)
        {
            yield return null;
            timePast = Time.time - timeStart;
            float ratio = timePast / (transitionTime / 2);
            float a = Mathf.Lerp(0, 1 * UIAlpha, Mathf.Clamp01(ratio));
            gameObject.GetComponentsInChildren<SpriteRenderer>()[1].color = new Color(oldColor.r, oldColor.g, oldColor.b, a);
        }
    }
}
