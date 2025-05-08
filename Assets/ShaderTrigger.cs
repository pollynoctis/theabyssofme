using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShaderTrigger : TriggerObject
{
    public Material glitchMateterial;
    public float noiseAmount, glitchStrength, effectTime;

    private void Awake()
    {
       glitchMateterial.SetFloat("_NoiseAmount", 0);
       glitchMateterial.SetFloat("_GlitchStrength", 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
       {
          glitchMateterial.SetFloat("_NoiseAmount", noiseAmount);
          glitchMateterial.SetFloat("_GlitchStrength", glitchStrength);
          StartCoroutine(Waiting());
       }
    }
    private IEnumerator Waiting()
    {
       yield return new WaitForSeconds(effectTime);
       glitchMateterial.SetFloat("_NoiseAmount", 0);
       glitchMateterial.SetFloat("_GlitchStrength", 0);
    }
}