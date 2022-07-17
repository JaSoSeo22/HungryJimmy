using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingAxe : MonoBehaviour
{
    public Animator playerAnim; //player animator
    bool swingPossible; //swing controller 스윙(어택) 제어
    //int swingStep; //버튼 클릭 횟수
    protected RaycastHit hitInfo;  //Raycast에 닿은 정보를 hitInfo에 저장
    public GameObject pickAxe; //도끼
    

    //(swing)attack function of swing button
    //공격(스윙)버튼을 눌렀을 때의 공격(스윙) 기능
    public void Attack()
    {
       // if(swingStep == 0)
        //{
            playerAnim.Play("SwingAxe"); //(첫번째) 도끼 휘두르는 애니메이션
            //swingStep = 1; 
            TryAttack(); //
            //return;
        //} 
        //press the Button while attacking 공격 중일때 버튼 누르기
        //if(swingStep != 0) 
        //{
            // if(swingPossible)
            // {
            //     swingPossible = false;
            //     //swingStep += 1;
            // }
       // }
    }

    //Raycast에 충돌한 것이 있는지 체크?
    protected bool CheckObject() 
    {
        if(Physics.Raycast(transform.position, transform.forward, out hitInfo))
        {
            return true; //충돌한 게 있음
        }
        return false; //충돌한 게 없음
    }

    //a switch that detects a Button being entered during a swing
    //공격 중일때 버튼을 감지를 시작할 스위치
    public void SwingPossible()
    {
        swingPossible = true;
    }

    //Swing Axe (스윙)공격
     public void Swing() 
     {   //second swing animation
    //     //if(swingStep == 2) //더블클릭 할 경우 2번째 액션 플레이
    //         //playerAnim.Play("SecondName"); //두버째 공격 애니메이션의 이름
     }

    //Reset the swing/attack function
    //공격(스윙)의 리셋 기능
    public void SwingReset()
    {
        swingPossible = false;
        //swingStep = 0; 

    }

    protected void TryAttack()
    {
        if (CheckObject())
        {
            if(hitInfo.transform.tag == "Rock" && pickAxe.activeInHierarchy) //pickAxe른 든 상태로 바위와 부딪혔을 경우
            {//Rock 클래스 안의 Mining을 호출
                hitInfo.transform.GetComponent<Rock>().Mining();
            } 
                // else if(hitInfo.transform.tag == "Twig") //나뭇가지와 부딪혔을 경우
                // {//Twig 클래스 안의 Damage 호출 / 플레이어 transform도 함께 가져오기 / FineObjectOfType을 통해 얻어와도 된다
                //     hitInfo.transform.GetComponent<Twig>().Damage(this.transform); //도끼의 위치임
                // }
                //isSwing = false;
            Debug.Log(hitInfo.transform.name);
        }

    }
}
