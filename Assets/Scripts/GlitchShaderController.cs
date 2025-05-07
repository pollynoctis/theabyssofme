using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class GlitchShaderController : MonoBehaviour
{
   public Material glitchMateterial;
   public float noiseAmount, glitchStrength;
   
   private void Update()
   {
      glitchMateterial.SetFloat("_NoiseAmount", noiseAmount);
      
      glitchMateterial.SetFloat("_GlitchStrength", glitchStrength);
   }
   /*private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         glitchMateterial.SetFloat("NoiseAmount", noiseAmount);
         glitchMateterial.SetFloat("GlitchStrength", glitchStrength);
         StartCoroutine(Waiting());
      }
   }
   private IEnumerator Waiting()
   {
      yield return new WaitForSeconds(effectTime);
      glitchMateterial.SetFloat("NoiseAmount", 0);
      glitchMateterial.SetFloat("GlitchStrength", 0);
   }*/
}
