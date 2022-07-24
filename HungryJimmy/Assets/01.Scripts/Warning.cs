using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warning : MonoBehaviour
{
    //경고 패널
    [SerializeField] private GameObject hungry_yellow_Panel;
    [SerializeField] private GameObject hungry_red_Panel;
    [SerializeField] private GameObject thirsty_yellow_Panel;
    [SerializeField] private GameObject thirsty_red_Panel;

    //필요한 사운드 이름
    [SerializeField] 
    private string weakWarning_Sound; //1번째 경고음
    [SerializeField] 
    private string halfEmergencyWarning_Sound; //2번째 경고음

    //지미의 현재 상태를 알려주는 이미지 오브젝트
    public GameObject healthyJim;
    public GameObject sickJim;
    public GameObject soSickJim;
    public GameObject deadJim;



    bool h_yellowUI = false;      //아이템으로 회복할때마다 이거 처리 해줘야 계속 경고창 나타남
    bool h_redUI = false;
    bool t_yellowUI = false;
    bool t_redUI = false;


    public StatusController theStatus;
    public GameObject rgstButton; //리듬게임(기우제) 버튼

    void Start()
    {

    }

    void Update()
    {
        if (theStatus.currentHungry < 50)
        {
            if (theStatus.currentHungry > 30 && !h_yellowUI)
            {
                healthyJim.SetActive(false);
                sickJim.SetActive(true); //지미의 상태 이미지를 아픈 상태로 변경

                h_yellowUI = true;
                StartCoroutine(ShowHYellowPanel());
            }
            if (theStatus.currentHungry < 15)
            {
                if (!h_redUI)
                {
                    sickJim.SetActive(false);
                    soSickJim.SetActive(true);//지미의 상태 이미지를 매우 아픈 상태로 변경

                    h_redUI = true;
                    
                    StartCoroutine(ShowHRedPanel());

                }

            }
            else
            {
                h_redUI = false;
            }
        }
        else
        {
            h_yellowUI = false;
        }

        if (theStatus.currentThirsty < 50)
        {
            if (theStatus.currentThirsty > 30 && !t_yellowUI)
            {
                if(!rgstButton.activeInHierarchy)
                {
                    rgstButton.SetActive(true); //리듬게임 버튼 활성화
                    t_yellowUI = true;
                    StartCoroutine(ShowTYellowPanel());
                }
            }

            if (theStatus.currentThirsty < 15) //목마름 지수가 15보다 낮을 때
            {
                if (!t_redUI)
                {
                    t_redUI = true;
                    StartCoroutine(ShowTRedPanel());
                }
            }
            t_redUI = false;
        }
        else
        {
            t_yellowUI = false;
        }
    }

    IEnumerator ShowHYellowPanel()
    {
        hungry_yellow_Panel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        hungry_yellow_Panel.SetActive(false);

        SoundManager.instance.PlaySE(weakWarning_Sound); //warning sound play
    }

    IEnumerator ShowHRedPanel()
    {
        hungry_red_Panel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        hungry_red_Panel.SetActive(false);

        SoundManager.instance.PlaySE(halfEmergencyWarning_Sound); //warning sound play
    }

    IEnumerator ShowTYellowPanel()
    {
        thirsty_yellow_Panel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        thirsty_yellow_Panel.SetActive(false);

        SoundManager.instance.PlaySE(weakWarning_Sound); //warning sound play
    }

    IEnumerator ShowTRedPanel()
    {
        thirsty_red_Panel.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        thirsty_red_Panel.SetActive(false);

        SoundManager.instance.PlaySE(halfEmergencyWarning_Sound); //warning sound play
    }


}
