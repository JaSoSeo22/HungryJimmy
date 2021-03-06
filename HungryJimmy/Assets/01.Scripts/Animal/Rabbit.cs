using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rabbit : MonoBehaviour
{

    [SerializeField] private int hp;        // 동물의 체력

    [SerializeField] private float walkSpeed;       // 걷기 스피드
    [SerializeField] private float runSpeed;        // 뛰기 스피드
    private float applySpeed;       // 이동시킬 스피드

    private Vector3 direction;      // 방향 설정

    // 상태변수
    private bool isAction;      // 행동중인지 아닌지 판별
    private bool isWalking;      // 걷는지 안 걷는지 판별
    private bool isRunning;      // 뛰는지 판별
    private bool isDead;        // 죽었는지 판별

    [SerializeField] private float walkTime;    // 걷기 시간
    [SerializeField] private float waitTime;    // 대기 시간
    [SerializeField] private float runTime;     // 뛰기 시간
    private float currentTime;      // 여기에 대기 시간 넣고 1초에 1씩 감소시킬 것

    // 필요한 컴포넌트
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private BoxCollider boxCol;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = waitTime;     // 대기시간 넣어줌
        isAction = true;        // 대기하는 것도 액션이니 트루줌
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Move();
            Rotation();
            ElapseTime();
        }
    }

    private void Move()
    {
        if (isWalking)     // isWalking이나 isRunning일 때 실행
        {
            rigid.MovePosition(transform.position + (transform.forward * applySpeed * Time.deltaTime));
        }
    }

    private void Rotation()
    {
        if (isWalking || isRunning)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, new Vector3(0f, direction.y, 0f), 0.01f);       // X,Z값은 적용되지 않도록
            rigid.MoveRotation(Quaternion.Euler(_rotation));    // Vector3를 Quaternion으로 바꿔줌
        }
    }

    private void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
                RandomAction(); // 다음 랜덤 행동 개시
        }
    }

    // private void ReSet()
    // {
    //     isWalking = false; isRunning = false; isAction = true;      // 모든 상태 초기화
    //     applySpeed = walkSpeed;     // 다시 이동속도를 walkSpeed로 적용
    //     anim.SetBool("isWalking", isWalking); anim.SetBool("isWalking", isWalking);
    //     direction.Set(0f, Random.Range(0f, 360f), 0f);      // 방향 랜덤하게
    //     RandomAction();
    // }

    private void RandomAction()
    {
        int _random = Random.Range(0, 2);   // 대기, 풀뜯기, 두리번, 걷기 
                                            //(,_ 는 실행되지 않으므로 4개 실행하고 싶으면 3이 아닌 4 (0f, 4f 하면 4도 포함시킴))
        if (_random == 0)
            Wait();
        else if (_random == 1)
            StartCoroutine(Walk());
    }

    private void Wait()
    {
        currentTime = waitTime;
        isWalking = false;
        anim.SetBool("isWalking", false);
        Debug.Log("대기");
    }


    // private void TryWalk()
    // {
    //     isWalking = true;
    //     anim.SetBool("isWalking", isWalking);
    //     currentTime = walkTime;
    //     applySpeed = walkSpeed;     // 이동시 walkSpeed적용
    //     Debug.Log("걷기");
    // }

    IEnumerator Walk()
    {
        isWalking = true;
        anim.SetBool("isWalking", isWalking);
        currentTime = walkTime;
        applySpeed = walkSpeed;     // 이동시 walkSpeed적용
        yield return new WaitForSeconds(2f);
        isWalking = false;
        Debug.Log("걷기");
    }

    private void Run(Vector3 _targetPos)        // 위협받거나 데미지 입었을 때 뛰게할것
    {
        // 플레이어와 반대방향으로 도망가게 할것
        direction = Quaternion.LookRotation(transform.position - _targetPos).eulerAngles;

        currentTime = runTime;
        isWalking = false;
        isRunning = true;
        applySpeed = runSpeed;      // 이동시 runSpeed적용
        anim.SetBool("isWalking", isWalking);
    }

    // public void Damage(int _dmg, Vector3 _targetPos)        // 데미지 입을 때 Run 호출시킴
    // {
    //     if (!isDead)
    //     {
    //         hp -= _dmg;

    //         if (hp <= 0)
    //         {
    //             Dead();     // Dead()호출
    //             return;
    //         }

    //         anim.SetTrigger("Hurt");        // Hurt애니메이션 실행
    //         Run(_targetPos);        // _targetPos 방향으로 Run() 실행
    //     }
    // }

    private void Dead()
    {
        isWalking = false;
        isRunning = false;
        isDead = true;
        anim.SetTrigger("isDead");
    }

}

