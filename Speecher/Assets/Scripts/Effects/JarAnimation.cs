using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JarAnimation : MonoBehaviour, ElementController
{ 

   private Animator animator; 
   private bool isOpen = false; 

   private void Awake() 
   {
   	animator = GetComponent<Animator>();
   } 

   public void ActivateElement()
   { 
   	isOpen = true;
   	animator.SetBool("JarActivate", true); 
   } 

   public void DeactivateElement()
   {
   	isOpen = false;
   	animator.SetBool("JarActivate", false);
     
   }

   public void ToggleElement()
   {
      isOpen = !isOpen; 
      if(isOpen) 
      {
         ActivateElement();
      } 
      else 
      {
         DeactivateElement();
      }
   }

}