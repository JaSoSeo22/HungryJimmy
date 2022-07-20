using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonFire : MonoBehaviour
{

    public GameObject bonfirePrefab;
    public StatusController theStatus; 



    public void StaminaBonFire() //모닥불을 켰을 경우에
    {
        theStatus.currentStamina += 15; //스태미너 회복시켜주기
        Debug.Log("회복");

        theStatus.staminaDecreaseTime = 200; //낮과 동일하게 체력 떨어뜨리기
        Debug.Log("낮의 체력");

    }

}
