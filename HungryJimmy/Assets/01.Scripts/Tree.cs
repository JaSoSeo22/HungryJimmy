using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField]
    private int hp; //나무의 체력

    [SerializeField]
    public GameObject itemPrefab; //통나무 prefab
    [SerializeField]
    public GameObject itemPrefabSecond; //두번째 통나무 prefab
    [SerializeField]
    public GameObject itemPrefabThird; //세번째 통나무 prefab

    [SerializeField]
    private CapsuleCollider capCol; //capsule 콜라이더 -> 파괴후에 비활성화시켜서 없애버릴거임...

    [SerializeField]
    private GameObject go_tree; //일반 나무


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

    public bool isClear = false;

    // // 리스폰 시킬 몬스터를 담을 변수
    // GameObject myRespawnTree;
    // // 리스폰 오브젝트에서 생성된 몇번째 몬스터에 대한 정보
    // public int spawnID { get; set; }
    // // 나무가 처음 생성될때의 위치 저장
    // Vector3 originPos;

    // // 나무가 어느 리스폰 오브젝트로부터 만들어졌는가 정보를 전달 받을 함수
    // public void SetRespawnTree(GameObject respawnTree, int spawnID, Vector3 originPos)
    // {
    //     myRespawnTree = respawnTree;
    //     this.spawnID = spawnID;
    //     this.originPos = originPos;
    // }

    // IEnumerator RemoveTreeWorld()
    // {
    //     yield return new WaitForSeconds(1f);
    //     myRespawnTree.GetComponent<RespawnTree>().RemoveTree(spawnID);
    // }

    // // 나무가 리스폰 될때 초기화 상태로 함
    // public void AddToWorldAgain()
    // {
    //     // 리스폰 오브젝트에서 처음 생성될때의 위치와 같게 함
    //     transform.position = originPos;

    //     GetComponent<CapsuleCollider>().enabled = true;
    // }

    private void Update() 
    {

    }
    public void Hit()
    {
        SoundManager.instance.PlaySE(chop_sound);

        var clone = Instantiate(go_hit_effect_prefab, capCol.bounds.center, Quaternion.identity);
        Destroy(clone, debrisDestroyTime); //일정 시간(destroyTime) 후 파편 클론 파괴

        hp--; //hp를 1씩 깎아서...
        if (hp <= 0) //hp가 0이하면 파괴
            FallDownTree(); //나무 쓰러뜨리기 - 체력주기~!
    }

    private void FallDownTree()
    {
        isClear = true;
        SoundManager.instance.PlaySE(falldown_sound);

        //나무가 파괴 되었기에 비활성화하고 사라지게 하기 -> 잔해만 남도록
        capCol.enabled = false;
        Destroy(go_tree);
        GetComponent<CapsuleCollider>().enabled = false;
        TreeDropItem();
    }


    public void TreeDropItem()
    {
        var itemGo = Instantiate<GameObject>(this.itemPrefab);
        itemGo.transform.position = this.gameObject.transform.position + Vector3.up * 0.1f;
        itemGo.SetActive(true);

        var itemGoSecond = Instantiate<GameObject>(this.itemPrefabSecond);
        itemGoSecond.transform.position = this.gameObject.transform.position + Vector3.up * 0.2f;
        itemGoSecond.SetActive(true);

        var itemGoThird = Instantiate<GameObject>(this.itemPrefabThird);
        itemGoThird.transform.position = this.gameObject.transform.position + Vector3.up * 0.3f;
        itemGoThird.SetActive(true);
    }
}
