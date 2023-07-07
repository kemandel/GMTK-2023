using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public bool usable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!usable){
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
        }
    }
}
