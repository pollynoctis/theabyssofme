using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDisabler : ParentTriggerObject
{
   //for cutscenes
   [SerializeField] private SimpleMovement movement;
   [SerializeField] private float secondsBeforeEnable;
   [SerializeField] private Animator anim;

   private void OnTriggerEnter2D(Collider2D other)
   {
      anim.SetBool("isMoving", false);
      movement.enabled = false;
   }

   private IEnumerator EnableBack()
   {
      yield return new WaitForSeconds(secondsBeforeEnable);
      movement.enabled = true;
   }
}
