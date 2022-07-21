using UnityEngine;


public class TreeRespawn : MonoBehaviour
{
    public GameObject items;      // 생성할 아이템
    public Transform respawnTransform;       // 리스폰 트랜스폼

    public float timeBetSpawnMax = 1000f;      // 최대 시간 간격
    public float timeBetSpawnMin = 500f;      // 최소 시간 간격
    private float timeBetSpawn;      // 생성 간격

    private float lastSpawnTime;        // 마지막 생성 시점 

    // Start is called before the first frame update
    void Start()
    {
        // 생성 간격과 마지막 생성 시점 초기화
        timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
        lastSpawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 마지막 생성시점 + 생성간격보다 시작후 실행 시간이 클 때
        if (Time.time >= lastSpawnTime + timeBetSpawn && respawnTransform != null)  
        {
            // 마지막 생성 시간 갱신
            lastSpawnTime = Time.time;
            // 생성 주기를 랜덤으로 변경
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            // 나무 생성 실행
            Spawn();


        }
    }

    // 실제 나무 생성 처리
    private void Spawn()
    {

        Vector3 spawnPosition = respawnTransform.transform.position;        // 리스폰 위치값 가져오기
        GameObject item = Instantiate(items, spawnPosition, Quaternion.identity);   // 나무 프리팹 생성

        // 생성된 아이탬을 10초 뒤에 파괴
        Destroy(item, 10f);
    }

}
