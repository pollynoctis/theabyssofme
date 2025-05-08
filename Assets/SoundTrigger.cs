using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : TriggerObject
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip clipToPlay;

    private void OnTriggerEnter2D(Collider2D other)
    {
        source.PlayOneShot(clipToPlay);
    }
}
