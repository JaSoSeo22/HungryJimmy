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
}
