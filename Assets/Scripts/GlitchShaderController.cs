using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchShaderController : MonoBehaviour
{
   public Material glitchMateterial;
   public float noiseAmount, glitchStrength;
   
   private void OnEnable()
   {
      glitchMateterial.SetFloat("_NoiseAmount", noiseAmount);
      glitchMateterial.SetFloat("_GlitchStrength", glitchStrength);
   }
   
   private void OnDisable()
   {
      glitchMateterial.SetFloat("_NoiseAmount", 0);
      glitchMateterial.SetFloat("_GlitchStrength", 0);
   }
}
