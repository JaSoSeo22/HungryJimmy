using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunButton : MonoBehaviour
{
    bool runBtn; 
    public GameObject runningSt;  //달리기 상태인지 알려주는 이미지

    public void TryRun()
    {
        if (runBtn == false)
            {
                this.runBtn = true;
                runningSt.SetActive(true); //상태 표시 이미지 활성화
            }
            else
            {
                this.runBtn = false;
                runningSt.SetActive(false); //상태 표시 이미지 비활성화
            }
    }
}
