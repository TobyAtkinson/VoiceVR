using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAudio : MonoBehaviour
{
    public int whichSound = 10;
    public AudioSource[] startSounds;

    void Start()
    {
        if(whichSound == 10)
        {
            whichSound = Random.Range(0, 3);
        }
        StartCoroutine(PlaySound()); 
    }

    IEnumerator PlaySound()
    {
        float delayTime = Random.Range(0.2f, 2.0f);
        yield return new WaitForSeconds(delayTime);
        startSounds[whichSound].Play();
    }
}
