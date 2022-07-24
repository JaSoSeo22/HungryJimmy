using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private float logTime;
    public GameObject newLogPrefab;
    [SerializeField] Transform logTransform;

    [SerializeField] private float fruitTime;
    public GameObject newFruitPrefab;
    [SerializeField] Transform fruitTransform;

    public GameObject waterPrefab;
    [SerializeField] Transform waterTransform;

    public GameObject rainPrefab; // 비 내리는지 확인할 오브젝트


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SearchLog();
        SearchFruit();
    }

    IEnumerator RespawnLogTree()
    {
        yield return new WaitForSeconds(logTime);
        var itemGo = Instantiate<GameObject>(this.newLogPrefab);
        itemGo.transform.position = this.logTransform.transform.position;
        itemGo.SetActive(true);
    }

    IEnumerator RespawnFruitTree()
    {
        yield return new WaitForSeconds(fruitTime);
        var itemGo = Instantiate<GameObject>(this.newFruitPrefab);
        itemGo.transform.position = this.fruitTransform.transform.position;
        itemGo.SetActive(true);
    }

    IEnumerator RespawnWater()
    {
        yield return new WaitForSeconds(3f);
        var itemGo = Instantiate<GameObject>(this.waterPrefab);
        itemGo.transform.position = this.waterTransform.transform.position;
        itemGo.SetActive(true);
    }

    private void SearchLog()
    {
        if (GameObject.FindGameObjectWithTag("Tree") != null)
        {
            if (GameObject.FindGameObjectWithTag("Tree").GetComponent<Tree>().isClear == true)
            {
                StartCoroutine(RespawnLogTree());
            }
        }

    }
    
    private void SearchFruit()
    {
        if (GameObject.FindGameObjectWithTag("FruitTree") != null)
        {
            if (GameObject.FindGameObjectWithTag("FruitTree").GetComponent<FruitTree>().isClear == true)
            {
                StartCoroutine(RespawnFruitTree());
            }
        }

    }

    private void SearchRain()
    {
        if (rainPrefab.activeInHierarchy)
        {
            if (GameObject.FindGameObjectWithTag("Status").GetComponent<StatusController>().isRain == true)
            {
                StartCoroutine(RespawnWater());
            }
            
        }
    }
}
