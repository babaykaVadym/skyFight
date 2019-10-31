using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject sfx;
    public AudioClip[] audioClips;

 public void PlaySound(int soundNum)
    {
        GameObject s = Instantiate(sfx, Vector2.zero, Quaternion.identity) as GameObject;
        AudioSource audioS = s.GetComponent<AudioSource>();

        audioS.clip = audioClips[soundNum];
        audioS.Play();
        Destroy(s, audioClips[soundNum].length);
    }
    
}
