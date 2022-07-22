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
    public GameObject paddlePrefab;
    public GameObject ropePrefab;
    public GameObject clothPrefab;
    public Inventory inventory;

    //모닥불 오브젝트 관리
    public int lifetime = 15; //모닥불 지속 시간
    public GameObject moonImg; //밤 상태


    [SerializeField]
    private Transform targetTransform;

    public void Wood()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "Log")
                {
                    if (inventory.slots[i].itemCount >= 3)
                    {
                        var itemGo = Instantiate<GameObject>(this.woodPrefab);
                        itemGo.transform.position = this.targetTransform.transform.position + Vector3.forward * 0.5f;
                        itemGo.SetActive(true);

                        inventory.slots[i].SetSlotCount(-3);
                    }
                    else
                    {
                        Debug.Log("나무는 있는데 수량이 부족해!");
                    }
                }

            }
            else
            {
                Debug.Log("나무 아이템이 없습니다.");
            }
        }
    }

    public void Ax()
    {
        bool c = false;
        bool d = false;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            for (int j = 0; j < inventory.slots.Length; j++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "Log" && inventory.slots[i].itemCount >= 1)
                    {
                        c = true;
                        inventory.slots[i].SetSlotCount(-1);
                    }
                    Debug.Log("나무");
                    if (inventory.slots[j].item != null)
                    {
                        if (inventory.slots[j].item.itemName == "RockItem" && inventory.slots[j].itemCount >= 1)
                        {
                            Debug.Log("돌 확인");
                            d = true;
                            inventory.slots[j].SetSlotCount(-1);
                        }
                    }

                }
            }

        }

        if (c && d)
        {
            var itemGo = Instantiate<GameObject>(this.axPrefab);
            itemGo.transform.position = this.targetTransform.transform.position + Vector3.forward * 2f + Vector3.up * 0.9f;
            itemGo.SetActive(true);

            c = false;
            d = false;
        }
    }

    public void Pick()
    {
        bool a = false;
        bool b = false;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            for (int j = 0; j < inventory.slots.Length; j++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "Log" && inventory.slots[i].itemCount >= 2)
                    {
                        a = true;
                        inventory.slots[i].SetSlotCount(-2);
                    }
                    if (inventory.slots[j].item != null)
                    {
                        if (inventory.slots[j].item.itemName == "RockItem" && inventory.slots[j].itemCount >= 2)
                        {
                            b = true;
                            inventory.slots[j].SetSlotCount(-2);
                        }
                    }

                }
            }

        }

        if (a && b)
        {
            var itemGo = Instantiate<GameObject>(this.rockstalkPrefab);
            itemGo.transform.position = this.targetTransform.transform.position + Vector3.forward * 2f + Vector3.up * 0.9f;
            itemGo.SetActive(true);

            a = false;
            b = false;
        }
    }

    public void BonFire()
    {
        bool e = false;
        bool f = false;
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            for (int j = 0; j < inventory.slots.Length; j++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "Log" && inventory.slots[i].itemCount >= 3)
                    {
                        e = true;
                        inventory.slots[i].SetSlotCount(-3);
                    }
                    if (inventory.slots[j].item != null)
                    {
                        if (inventory.slots[j].item.itemName == "RockItem" && inventory.slots[j].itemCount >= 2)
                        {
                            f = true;
                            inventory.slots[j].SetSlotCount(-2);
                        }
                    }

                }
            }

        }
        if (e && f)
        {
                if(moonImg.activeInHierarchy)
                {
                    var itemGo = Instantiate<GameObject>(this.bonfirePrefab);
                    itemGo.transform.position = this.targetTransform.transform.position + Vector3.forward * 2f;
                    itemGo.SetActive(true);

                    Destroy(itemGo,lifetime); //일정 시간이 지나면 모닥불 없애기

                    e = false;
                    f = false;
                }
            
        }
        

    }

    public void Boat()
    {
        bool g = false;
        bool h = false;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            for (int j = 0; j < inventory.slots.Length; j++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "Woods" && inventory.slots[i].itemCount >= 4)
                    {
                        g = true;
                        inventory.slots[i].SetSlotCount(-4);
                    }
                    if (inventory.slots[j].item != null)
                    {
                        if (inventory.slots[j].item.itemName == "Rope" && inventory.slots[j].itemCount >= 4)
                        {
                            h = true;
                            inventory.slots[j].SetSlotCount(-4);
                        }
                    }

                }
            }

        }

        if (g && h)
        {
            var itemGo = Instantiate<GameObject>(this.boatPrefab);
            itemGo.transform.position = this.targetTransform.transform.position + Vector3.forward * 5f;
            itemGo.SetActive(true);
            g = false;
            h = false;
        }

    }

    public void Paddle()
    {
        bool k = false;
        bool l = false;

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            for (int j = 0; j < inventory.slots.Length; j++)
            {
                if (inventory.slots[i].item != null)
                {
                    if (inventory.slots[i].item.itemName == "Woods" && inventory.slots[i].itemCount >= 2)
                    {
                        k = true;
                        inventory.slots[i].SetSlotCount(-2);
                    }
                    if (inventory.slots[j].item != null)
                    {
                        if (inventory.slots[j].item.itemName == "Rope" && inventory.slots[j].itemCount >= 1)
                        {
                            l = true;
                            inventory.slots[j].SetSlotCount(-1);
                        }
                    }

                }
            }

        }

        if (k && l)
        {
            var itemGo = Instantiate<GameObject>(this.paddlePrefab);
            itemGo.transform.position = this.targetTransform.transform.position + Vector3.forward * 2f;
            itemGo.SetActive(true);

            k = false;
            l = false;
        }

    }

    public void Rope()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].item != null)
            {
                if (inventory.slots[i].item.itemName == "Cloth")
                {
                    if (inventory.slots[i].itemCount >= 2)
                    {
                        var itemGo = Instantiate<GameObject>(this.ropePrefab);
                        itemGo.transform.position = this.targetTransform.transform.position + Vector3.forward * 2f;
                        itemGo.SetActive(true);

                        inventory.slots[i].SetSlotCount(-2);
                    }
                    else
                    {
                        Debug.Log("천은 있는데 수량이 부족해!");
                    }
                }
            }
            else
            {
                Debug.Log("천 아이템이 없습니다.");
            }
        }

    }
    
}
