using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft : MonoBehaviour
{
    public GameObject axPrefab;
    public GameObject woodPrefab;
    public GameObject rockstalkPrefab;
    public GameObject bonfirePrefab;
    public GameObject boatPrefab;
    [SerializeField]
    private Transform targetTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Wood()
    {
        var itemGo = Instantiate<GameObject>(this.woodPrefab);
        itemGo.transform.position = this.targetTransform.transform.position + Vector3.forward * 0.5f;
        itemGo.SetActive(true);
    }

    public void Ax()
    {
        var itemGo = Instantiate<GameObject>(this.axPrefab);
        itemGo.transform.position = this.targetTransform.transform.position + Vector3.forward * 2f + Vector3.up * 0.5f;
        itemGo.SetActive(true);
    }

    public void Pick()
    {
        var itemGo = Instantiate<GameObject>(this.rockstalkPrefab);
        itemGo.transform.position = this.targetTransform.transform.position + Vector3.forward * 2f + Vector3.up * 0.9f;
        itemGo.SetActive(true);
    }

    public void BonFire()
    {
        var itemGo = Instantiate<GameObject>(this.bonfirePrefab);
        itemGo.transform.position = this.targetTransform.transform.position + Vector3.forward * 2f;
        itemGo.SetActive(true);
    }

    public void Boat()
    {
        var itemGo = Instantiate<GameObject>(this.boatPrefab);
        itemGo.transform.position = this.targetTransform.transform.position + Vector3.forward * 5f;
        itemGo.SetActive(true);
    }
}
