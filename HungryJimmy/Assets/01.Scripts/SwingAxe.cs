// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SwingAxe : MonoBehaviour
// {
//     public Animator playerAnim; //player animator
//     bool swingPossible; //swing controller 
//     int swingStep;

//     //(swing)attack function of swing button
//     public void Attack()
//     {
//         if(swingStep == 0)
//         {
//             playerAnim.Play("SwingAxe"); //도끼 휘두르는 애니메이션
//             swingStep = 1; 
//             return;

//             if(CheckObject())
//             {
//                 if(hitInfo.transform.tag = "Tree")
//                 {
//                     StartCoroutine(AttackCoroutine("Chop"));
//                     return;
//                 }
//             }
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

//     //abstract -> 미완성으로 남겨 자식 클래스가 완성시키도록 하는 추상코루틴
//     protected abstract IEnumerator HitCoroutine();  
 

//     protected bool CheckObject()
//     {
//         if(Physics.Raycast(transform.position, transform.forward, out hitInfo, currentCloseWeapon.range))
//         {
//             return true; //충돌한 게 있음
//         }
//         return false; //충돌한 게 없음
//     }

//     //a switch that detects a Button being entered during a swing
//     public void SwingPossible()
//     {
//         swingPossible = true;
//     }

//     //Swing Axe
//     public void Swing()
//     {   //second swing animation
//         if(swingStep == 2) //더블클릭 할 경우 2번째 액션 플레이
//             playerAnim.Play("SecondName"); 
//     }

//     //Reset the swing/attack function
//     public void SwingReset()
//     {
//         swingPossible = false;
//         swingStep = 0; 

//     }

//     protected override IEnumerator HitCoroutine()
//     {
//         while (isSwing)
//         {
//             if (CheckObject())
//             {
//                 if(hitInfo.transform.tag == "Rock") //바위와 부딪혔을 경우
//                 {//Rock 클래스 안의 Mining을 호출
//                     hitInfo.transform.GetComponent<Rock>().Mining();
//                 }
//                 else if(hitInfo.transform.tag == "Twig") //나뭇가지와 부딪혔을 경우
//                 {//Twig 클래스 안의 Damage 호출 / 플레이어 transform도 함께 가져오기 / FineObjectOfType을 통해 얻어와도 된다
//                     hitInfo.transform.GetComponent<Twig>().Damage(this.transform); //도끼의 위치임
//                 }
//                 else if(hitInfo.transform.tag == "NPC") //나뭇가지와 부딪혔을 경우
//                 {//Twig 클래스 안의 Damage 호출 / 플레이어 transform도 함께 가져오기 / FineObjectOfType을 통해 얻어와도 된다
//                     SoundManager.instance.PlaySE("Animal_Hit");
//                     hitInfo.transform.GetComponent<Pig>().Damage(1 ,this.transform.position); //도끼의 위치임
//                 }
//                 isSwing = false;
//                 Debug.Log(hitInfo.transform.name);
//             }
//             yield return null;
//         }
//     }
// }
