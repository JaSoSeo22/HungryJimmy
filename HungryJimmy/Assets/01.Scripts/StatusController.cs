using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    // 체력
    [SerializeField]
    private int stamina;
    public float currentStamina;

    // 체력이 줄어드는 속도
    [SerializeField]
    private float staminaDecreaseTime;
    private int currentStaminaDecreaseTime;

    // 배고픔
    [SerializeField]
    private int hungry;
    public int currentHungry;

    // 배고픔이 줄어드는 속도
    [SerializeField]
    private int hungryDecreaseTime;
    private int currentHungryDecreaseTime;

    // 목마름
    [SerializeField]
    private float thirsty;
    public float currentThirsty;

    // 목마름이 줄어드는 속도
    [SerializeField]
    private int thirstyDecreaseTime; //지정해둔 속도
    private int currentThirstyDecreaseTime; //계속 변하는 양(시간)

    // 필요한 이미지
    [SerializeField]
    private Image[] images_Gauge;

    private bool isDead = false;
    private HealthManager theHealth;

    public GameObject rainPrefab; // 비 내리는 파티클 이펙트 오브젝트 

    public bool isRain = false; // 비가 오는지 확인


    private const int HUNGRY = 0, THIRSTY = 1, STAMINA = 2;

    void Start()
    {
        currentStamina = stamina;
        currentHungry = hungry;
        currentThirsty = thirsty;
    }


    void Update()
    {
        if (!isDead)
        {
            Hungry();
            Thirsty();
            Stamina();
            GaugeUpdate();
        }
    }

    private void Hungry()       // 배고픔 구현
    {
        if (currentHungry > 0)      // 현재 배고픔이 0보다 클 경우에만 깎음
        {
            if (currentHungryDecreaseTime <= hungryDecreaseTime)
                currentHungryDecreaseTime++;
            else
            {
                currentHungry--;
                currentHungryDecreaseTime = 0;
            }
        }
        else        // 0보다 작아졌을때
            theHealth.Dead();
            // Debug.Log("배고픔 수치가 0이 되었습니다");
    }

    private void Thirsty()      // 목마름 구현
    {
        if (currentThirsty > 0)
        {
            if (currentThirstyDecreaseTime <= thirstyDecreaseTime)
                currentThirstyDecreaseTime++; //1씩 계속 증가
            else
            {
                currentThirsty--;
                currentThirstyDecreaseTime = 0;
            }
             if(!isRain)
            {
                Raining();
                isRain = false;
            }
        }
        else
            theHealth.Dead();
            // Debug.Log("목마름 수치가 0이 되었습니다");
    }

    private void Stamina()       // 체력 구현
    {
        if (currentStamina > 0)      // 현재 체력이 0보다 클 경우에만 깎음
        {
            if (currentStaminaDecreaseTime <= staminaDecreaseTime)
                currentStaminaDecreaseTime++;
            else
            {
                currentStamina--;
                currentStaminaDecreaseTime = 0;
            }

        }
        else        // 0보다 작아졌을때
            theHealth.Dead();
            // Debug.Log("체력 수치가 0이 되었습니다");
    }

    private void Raining() //비 내리기
    {
        if (rainPrefab.activeInHierarchy) //하이어라키 창에 비 프리팹이 활성화 되었다면
        {
            currentThirsty += 3f * Time.deltaTime; //총 30의 수분 주기(비가 10초동안 옴)
        }
    }

    private void GaugeUpdate()      // 상태 수치 변화 시각화
    {
        images_Gauge[STAMINA].fillAmount = (float)currentStamina / stamina;
        images_Gauge[HUNGRY].fillAmount = (float)currentHungry / hungry;
        images_Gauge[THIRSTY].fillAmount = (float)currentThirsty / thirsty;
    }

    // stamina 회복 (아이템 사용시)
    public void IncreaseStamina(int _count)
    {
        if (currentStamina + _count < stamina)        // currentStamina와 회복될 수치를 더했을때 stamina가 넘는가?
        {
            currentStamina += _count;
        }
        else
            currentStamina = stamina;
    }

    // Stamina 감소
    public void DecreaseStamina(float _count)
    {
        currentStamina -= _count;

        if (currentStamina <= 0)     // currentStamina 0 이하가 되면 움직임이 매우 느려짐
            Debug.Log("캐릭터의 stamina가 0이 되었습니다!!");
    }

    public void IncreaseThirsty(int _count)
    {
        if (currentThirsty + _count < thirsty)
        {
            currentThirsty += _count;
        }
        else
            currentThirsty = thirsty;
    }

    // Hungry 증가
    public void IncreaseHungry(int _count)
    {
        if (currentHungry + _count < hungry)
        {
            currentHungry += _count;
        }
        else
            currentHungry = hungry;
    }

    // Hungry 감소
    public void DecreaseHungry(int _count)
    {
        currentHungry -= _count;
    }


}
