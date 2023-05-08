using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] AudioClip bgMusic;

    private void Start()
    {
        AudioSource audioSource = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        if (audioSource.clip != bgMusic) {
            audioSource.clip = bgMusic;
            audioSource.Play();
        }
    }
}
