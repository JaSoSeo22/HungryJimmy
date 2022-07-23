using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckItem : MonoBehaviour
{
    public Inventory inventory;
    public GameObject axePrefab;
    public GameObject treeaxePrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckAxe()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "Rockstalk")
                {
                    axePrefab.SetActive(true);
                }
            }
        }
    }

    public void CheckTreeAxe()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "Ax Stone")
                {
                    treeaxePrefab.SetActive(true);
                }
            }
        }
    }

    public void Hand()
    {
        treeaxePrefab.SetActive(false);
        axePrefab.SetActive(false);
    }

}
