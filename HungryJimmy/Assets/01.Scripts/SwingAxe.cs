// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SwingAxe : MonoBehaviour
// {
//     public Animator playerAnim; //player animator
//     bool swingPossible; //swing controller 
//     int swingStep;

//     //function of swing button
//     public void Swing()
//     {
//         if(swingStep == 0)
//         {
//             playerAnim.Play("isAxeSwing"); //swing animation
//             swingStep = 1; 
//             return;
//         } 
//         //press the Button while attacking
//         if(swingStep != 0)
//         {
//             if(swingPossible)
//             {
//                 swingPossible = false;
//                 swingStep += 1;
//             }
//         }
//     }

//     //a switch that detects a Button being entered during a swing
//     public void SwingPossible()
//     {
//         swingPossible = true;
//     }

//     //Swing Axe
//     public void Swing()
//     {   //second swing animation
//         if(swingStep == 2)
//             playerAnim.Play("SecondName");
//     }
// }
