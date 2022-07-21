using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false;      // 인벤토리 활성화 되면 다른 움직임들 막을 때 사용할것

    // 필요한 컴포넌트 
    [SerializeField]
    private GameObject go_InventoryBase;        // 활성화될 인벤토리창

    [SerializeField]
    private GameObject go_SlotsParent;      // 슬롯들의 부모객체 여기서는 Grid Setting을 의미


    private Slot[] slots;       // 인벤토리 슬롯들
    private bool isNotPut;      // 
    private int slotNumber;

    public Slot[] GetSlots() { return slots; }        // 슬롯에 있는 값 전부 반환

    [SerializeField] private Item[] items;      // 아이템 정보 받아올 배열 for문 돌려서 받아올것

    public void LoadToInven(int _arrayNum, string _itemName, int _itemNum)      // 아이템 이름, 번호만 가지고 넣기
    {
        for (int i = 0; i < items.Length; i++)      // 아이템 갯수만큼 돌림
        {
            if (items[i].itemName == _itemName)     // 넘어온 아이템의 이름이 같다면
            {
                slots[_arrayNum].AddItem(items[i], _itemNum);       // 아이템 추가
            }
        }
    }


    private void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();     // 배열안에 슬롯들이 들어감
    }

    private void Update()
    {

    }

    public void OpenInventory()
    {
        inventoryActivated = true;
        GameManager.isOpenInventory = true;
        go_InventoryBase.SetActive(true);
    }

    public void CloseInventory()
    {
        inventoryActivated = false;
        GameManager.isOpenInventory = false;
        go_InventoryBase.SetActive(false);
    }

    public void AcquireItem(Item _item, int _count = 1)     // 아이템 기본값이 1로 지정
    {
        PutSlot(slots, _item, _count);     // 퀵슬롯부터 채우고 싶으면 quickslots, 슬롯은 slots
        // if (isNotPut)       // 퀵슬롯 슬롯 채우기
        // {
        //     PutSlot(quickslots, _item, _count);
        // }

        // if (isNotPut)
        // {
        //     Debug.Log("퀵슬롯과 인벤토리가 꽉찼습니다");
        // }
    }

    // 슬롯에 아이템 채우기
    public void PutSlot(Slot[] _slots, Item _item, int _count)      // 뭘획득했고 몇개인지 기본값은 1로
    {

        if (Item.ItemType.Equipment != _item.itemType)      // 획득한 아이템이 장비가 아니라면
        {
            for (int i = 0; i < _slots.Length; i++)     // 반복문 돌려서 이미 획득한 아이템이면 갯수만 증가
            {
                if (_slots[i].item != null)      // 슬롯이 null이 아니면
                {
                    if (_slots[i].item.itemName == _item.itemName)      // 슬롯안에 이미 아이템이 들어가 있는것
                    {
                        slotNumber = i;
                        _slots[i].SetSlotCount(_count);     // 슬롯의 i번째 _count만큼 갯수 증가
                        isNotPut = false;
                        return;
                    }
                }
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                slots[i].AddItem(_item, _count);
                isNotPut = false;
                return;
            }
        }

        isNotPut = true;        // 실행되면 
    }

}