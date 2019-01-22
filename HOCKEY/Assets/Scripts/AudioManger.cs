using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour {
    public static AudioManger ins; 

    public AudioClip PuckCollision;
    public AudioClip Goal;

    private AudioSource audioSource;
    private void Awake()
    {
        ins = this; 
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPuckCollision()
    {
        audioSource.PlayOneShot(PuckCollision);
    }

    public void PlayGoal()
    {
        audioSource.PlayOneShot(Goal);
    }
}
