using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private int hp; //나무의 체력

    [SerializeField]
    public GameObject itemPrefab; //통나무 prefab

    // //쓰러질 때 랜덤으로 가해질 힘의 세기
    // [SerializeField]
    // private float force;

    [SerializeField]
    private CapsuleCollider capCol; //capsule 콜라이더 -> 파괴후에 비활성화시켜서 없애버릴거임...
    //[SerializeField]
    //private CapsuleCollider chiCol;

    // //자식 트리
    // [SerializeField]
    // private GameObject go_ChildTree;

    // //부모 트리 파괴되면, 캡슐 콜라이더 제거
    // [SerializeField]
    // private CapsuleCollider parentCol;

    // //자식 트리 쓰러질 때 필요한 컴퍼넌트 활성화 및 중력 활성화
    // [SerializeField]
    // private CapsuleCollider childCol;
    // [SerializeField]
    // private Rigidbody childRigid;
    [SerializeField]
    private GameObject go_tree; //일반 나무
    [SerializeField]
    private GameObject go_treedebris; //깨진 나무

    [SerializeField]
    private GameObject go_hit_effect_prefab;    //파편 이펙트

    [SerializeField]
    private float debrisDestroyTime;    //파편 제거 시간

    [SerializeField]
    private float destroyTime;    //나무 제거 시간

    //필요한 사운드 이름
    [SerializeField]
    private string chop_sound; //나무 썰리는 소리
    [SerializeField]
    private string falldown_sound; //나무 떨어지는 소리
    [SerializeField]
    private string logChange_sound; //통나무로 바뀌는 소리

    //
    public void Hit()
    {
        SoundManager.instance.PlaySE(chop_sound);


        // var clone = Instantiate(go_hit_effect_prefab, col.bounds.center, Quaternion.identity);
        // Destroy(clone, debrisDestroyTime);
        //콜라이더의 가운데에 파편 클론 생성
        var clone = Instantiate(go_hit_effect_prefab, capCol.bounds.center, Quaternion.identity);
        Destroy(clone, debrisDestroyTime); //일정 시간(destroyTime) 후 파편 클론 파괴

        hp--; //hp를 1씩 깎아서...
        if (hp <= 0) //hp가 0이하면 파괴
            FallDownTree(); //나무 쓰러뜨리기 - 체력주기~!
    }

    private void FallDownTree()
    {
        SoundManager.instance.PlaySE(falldown_sound);

        //바위가 파괴 되었기에 비활성화하고 사라지게 하기 -> 잔해만 남도록
        capCol.enabled = false;
        //chiCol.enabled = false;
        Destroy(go_tree);

        go_treedebris.SetActive(true); //바위 잔해 활성화시켜 나타나게 하기...
        Destroy(go_treedebris, destroyTime); //일정 시간(destroyTime) 후 debris도 삭제
                                             //Destroy(go_treeCenter); 

        // parentCol.enabled = false; //부모 트리의 콜라이더 비활성화 (콜라이더끼리의 충돌 방지)
        // childCol.enabled = true; //자식 콜라이더 & 리지드바디 활성화
        // childRigid.useGravity = true;

        // childRigid.AddForce(Random.Range(-force,force), 0f, Random.Range(-force,force)); //나무가 기울어지도록 랜덤으로 힘주기

        //StartCoroutine(LogCoroutine()); //나무가 쓰러지고 destroyTime후에 통나무 생성(코루틴)
        DropItem();
    }

    //     IEnumerator LogCoroutine()
    //     {
    //         yield return new WaitForSeconds(destroyTime); //destroyTime만큼 대기

    //         SoundManager.instance.PlaySE(logChange_sound);

    //         Instantiate(go_Log_Prefabs, go_tree.transform.position + (go_tree.transform.up * 3f), Quaternion.LookRotation(go_tree.transform.up)); //나무가 쓰러지는 위치에 통나무 생성 / go_tree가 쓰러지는 방향의 위로 향하도록
    //         Instantiate(go_Log_Prefabs, go_tree.transform.position + (go_tree.transform.up * 6f), Quaternion.LookRotation(go_tree.transform.up));
    //         Instantiate(go_Log_Prefabs, go_tree.transform.position + (go_tree.transform.up * 9f), Quaternion.LookRotation(go_tree.transform.up));

    //         Destroy(go_tree.gameObject);
    //     }

    public void DropItem()
    {
        var itemGo = Instantiate<GameObject>(this.itemPrefab);
        itemGo.transform.position = this.gameObject.transform.position + Vector3.up * 0.1f;
        itemGo.SetActive(true);
    }
}
