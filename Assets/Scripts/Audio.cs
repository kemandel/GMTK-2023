using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private DayNightCycle dayNightCycle;
    public AudioSource soundEffects;
    //0 index in array is buy item; 1 index in array is shear hair
    public AudioSource backgroundSound;

    public List<AudioClip> audioClips = new List<AudioClip>();
    public List<AudioClip> cricketSounds = new List<AudioClip>();

    public AudioClip daySong;
    public AudioClip nightSong;
    public Animator dayFade;

    //see if in process of fading music
    bool fading = false;

    // Start is called before the first frame update
    void Start()
    {
        dayNightCycle = FindObjectOfType<DayNightCycle>();
        backgroundSound.clip = daySong;
        backgroundSound.Play();
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
    public void FreeHuman()
    {
        soundEffects.clip = audioClips[2];
        soundEffects.Play();
    }


    public IEnumerator NightAudio()
    {
       // StartCoroutine(FadeDayMusic());
        /*
        while (fading)
        {
            yield return null;
        }
        Debug.Log("time of day is day: " + dayNightCycle.day);
        
        while (!dayNightCycle.day)
        {
            int time = Random.Range(1, 4);
            int bonusSound = Random.Range(1, 10);
            int soundIndex = Random.Range(0, 3);
            backgroundSound.clip = cricketSounds[soundIndex];
            Debug.Log("background sound object clip: " + backgroundSound.clip);
            Debug.Log("background sound clip length" + backgroundSound.clip.length);
            yield return new WaitForSeconds(time);
            backgroundSound.Play();
            if (bonusSound <= 3)
            {
                Debug.Log("background sound object clip in loop: " + backgroundSound.clip);
                Debug.Log("background sound clip length in loop" + backgroundSound.clip.length);
                yield return new WaitForSeconds(backgroundSound.clip.length);
                soundIndex = Random.Range(0, 3);
                backgroundSound.clip = cricketSounds[soundIndex];
                backgroundSound.Play();
            }
        
        }
        */
        yield return null;
    }

    public void DayAudio()
    {
        //StopCoroutine(NightAudio());
        Debug.Log("day audio called");
        StartCoroutine(FadeNightMusic());
       // backgroundSound.clip = daySong;
        backgroundSound.Play();
    }

    public  IEnumerator FadeDayMusic()
    {
        fading = true;
        Debug.Log("animation called for fade day music ");
        Debug.Log("currently playing: " + backgroundSound.clip.name);
        dayFade.Play("dayFadeOutMusic");
        yield return new WaitForSeconds(2);
        backgroundSound.clip = nightSong;
        fading = false;
        dayFade.Play("dayFadeInMusic");
        backgroundSound.Play();
    }

    private IEnumerator FadeNightMusic()
    {
        Debug.Log("animation called for fade night music");
        Debug.Log("currently playing: " + backgroundSound.clip.name);
        dayFade.Play("dayFadeOutMusic");
        yield return new WaitForSeconds(2);
        backgroundSound.clip = daySong;
        dayFade.Play("dayFadeInMusic");
        yield return new WaitForSeconds(2);
    }
}
