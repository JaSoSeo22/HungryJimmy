using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject box;
    public GameObject openBox;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

        }
    }

    void OnMouseDown()
    {
        StartCoroutine(BoxChange());
    }

    IEnumerator BoxChange()
    {
        box.SetActive(false);
        openBox.SetActive(true);
        yield return new WaitForSeconds(3f*Time.deltaTime);
        openBox.SetActive(false);
    }

}
