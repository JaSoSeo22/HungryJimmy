using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool canPlayerMove = true;        // 플레이어의 움직임 제어

    public static bool isOpenInventory = false;     // 인벤토리 활성화

    public static bool isPause = false;     // 메뉴가 호출되면 True

    // Update is called once per frame
    void Update()
    {
        if (isOpenInventory || isPause)     //##### 선언한 변수들 조건으로 넣어주면 됨
        {
            Cursor.lockState = CursorLockMode.None;       // 커서 잠금 해제
            Cursor.visible = true; ;     // 인벤토리 열리면 커서 보익에
            canPlayerMove = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;       // 커서 잠금
            Cursor.visible = false;
            canPlayerMove = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;       // 커서 잠금
        Cursor.visible = false;     // 커서 안보이게
    }


}
