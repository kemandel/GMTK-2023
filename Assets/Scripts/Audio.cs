using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource soundEffects;
    //0 index in array is buy item; 1 index in array is shear hair
    public List<AudioClip> audioClips = new List<AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyItem()
    {
        soundEffects.clip = audioClips[0];
        soundEffects.Play();
    }

    public void HarvestHair()
    {
        soundEffects.clip = audioClips[1];
        soundEffects.Play();
    }
}
