using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
{

    public Item item; // 획득한 아이템
    public int itemCount; // 획득한 아이템 갯수
    public Image itemImage; // 아이템의 이미지

    [SerializeField] private bool isQuickSlot;      // 퀵슬롯 여부 판단
    [SerializeField] private int quickSlotNumber;       // 퀵슬롯 번호

    // 필요한 컴포넌트
    [SerializeField]
    private TextMeshProUGUI text_Count; // 아이템 갯수
    [SerializeField]
    private GameObject go_CountImage; // 획득한 아이템 갯수창 이미지


    [SerializeField]
    private RectTransform baseRect;       // 인벤토리 사각영역
    [SerializeField]
    private RectTransform quickSlotBaseRect;        // 퀵슬롯의 영역
    private InputNumber theInputNumber;     // InputNumber받아오기
    private ItemEffectDatabase theItemEffectDatabase;       // ItemEffectDatabase 받아오기

    private void Start()
    {
        theInputNumber = FindObjectOfType<InputNumber>();
        theItemEffectDatabase = FindObjectOfType<ItemEffectDatabase>();
        // text_Count = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // 이미지의 투명도 조절 
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;       // 이미지의 알파값 조절
        itemImage.color = color;
    }

    // 아이템 획득
    public void AddItem(Item _item, int _count = 1)      // 보통 아이템 1개씩 획득하니까 _count = 1, AddItem(_item, 3); -> 아이템 3개 획득
    {
        //
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;      // sprite에 itemImage넣어줌
        if (item.itemType != Item.ItemType.Equipment)        // 아이템 타입이 장비일때는 활성화 시키지 않을것
        {
            go_CountImage.SetActive(true);      // 아이템 들어왔으므로 go_CountImage활성화
            text_Count.text = itemCount.ToString();     // Integer 타입은 text와 호환이 안되므로 ToString으로 형변환
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }

        SetColor(1);        // 아이템이 들어왔으므로
    }

    public int GetQuickSlotNumber()     // 퀵슬롯 넘버 받아옴
    {
        return quickSlotNumber;
    }

    // 아이템 갯수 조정
    public void SetSlotCount(int _count)
    {
        itemCount += _count;        // -3넣으면 3개가 깎이는것
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)      // 아이템이 없으므로
        {
            ClearSlot();        // 슬롯초기화
        }
    }

    // 슬롯 초기화
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);        // 슬롯 투명

        text_Count.text = "0";
        go_CountImage.SetActive(false);

    }

    // 아이템 사용하는 구간
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)     // 우클릭시
        {
            if (item != null)       // 아이템이 있는지 없는지 확인하고 실행
            {
                theItemEffectDatabase.UseItem(item);
                if (item.itemType == Item.ItemType.Used)        // 소모품일 경우
                {
                    SetSlotCount(-1);       // 아이템 -1씩 소비
                }
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null && Inventory.inventoryActivated)       // item이 null이 아니고 Inventory.inventoryActivated가 true일때
        {
            Debug.Log(Inventory.inventoryActivated);
            DragSlot.instance.dragSlot = this;      // DragSlot이 나 자신이 됨
            DragSlot.instance.DragSetImage(itemImage);      // 드래그중인 이미지도 바뀜

            DragSlot.instance.transform.position = eventData.position;        // DragSlot의 포지션을 이벤트가 위치한 위치로 바꿈
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)       // item이 null이 아닐 때
        {
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    // 드래그가 끝나기만해도 호출
    public void OnEndDrag(PointerEventData eventData)
    {
        // 드래그 했는데 인벤토리 창이나 퀵슬롯 영역을 벗어난 경우
        if (!((DragSlot.instance.transform.localPosition.x > baseRect.rect.xMin     // 최소값보다 크고 최대값보다 작다
        && DragSlot.instance.transform.localPosition.x < baseRect.rect.xMax
        && DragSlot.instance.transform.localPosition.y > baseRect.rect.yMin
        && DragSlot.instance.transform.localPosition.y < baseRect.rect.yMax)        // 인벤토리 영역
        || (DragSlot.instance.transform.localPosition.x > quickSlotBaseRect.rect.xMin       // 퀵슬롯 영역
        && DragSlot.instance.transform.localPosition.x < quickSlotBaseRect.rect.xMax
        && DragSlot.instance.transform.localPosition.y > quickSlotBaseRect.transform.localPosition.y - quickSlotBaseRect.rect.yMax 
        && DragSlot.instance.transform.localPosition.y < quickSlotBaseRect.transform.localPosition.y - quickSlotBaseRect.rect.yMin)))
        {
            if (DragSlot.instance.dragSlot != null)     // Slot이 null이 아닐때만 실행
            {
                theInputNumber.Call();      // InputNumber의 Call()실행
            }
        }
        else        // 인벤토리 혹은 퀵슬롯 영역에서 드래그가 끝났다면
        {
            DragSlot.instance.SetColor(0);      // 이미지 투명한 상태로 만들어줌
            DragSlot.instance.dragSlot = null;
        }
    }

    // 다른 슬롯위에서 드래그가 끝났을 때 호출
    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.dragSlot != null)     // DragSlot이 null이 아닐때만 ChangeSlot()실행
        {
            ChangeSlot();

            // if (isQuickSlot)        // 인벤토리에서 퀵슬롯으로 혹은 퀵슬롯에서 퀵슬롯으로
            // {
            //     theItemEffectDatabase.isActivatedQuickSlot(quickSlotNumber);       // 활성화된 퀵슬롯이면 교체작업
            // }
            // else        // 인벤토리 -> 인벤토리, 퀵슬롯 -> 인벤토리 경우
            // {
            //     if (DragSlot.instance.dragSlot.isQuickSlot)     // 퀵슬롯 -> 인벤토리
            //     {
            //         theItemEffectDatabase.isActivatedQuickSlot(DragSlot.instance.dragSlot.quickSlotNumber);        // 활성화된 퀵슬롯이면 교체작업
            //     }
            // }
        }
    }

    private void ChangeSlot()       // a슬롯에 있는걸 b슬롯으로 옮길때 이미 b정보는 파괴되므로 임시정보 저장해줌
    {
        Item _tempItem = item;      // 자기자신
        int _tempItemCount = itemCount;     //자기자신의 갯수

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);     // b에 a정보 넣기

        if (_tempItem != null)      // 빈슬롯이 아니면
        {
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);      // null이 아니면 b정보 넣어줌
        }
        else    // 빈슬롯이면
        {
            DragSlot.instance.dragSlot.ClearSlot();     // 빈슬롯이면 슬롯 초기화
        }
    }

    // 마우스가 슬롯에 들어갈 때 발동
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("함수실행시작");
        if (item != null)       // item이 null이 아닐때 실행하도록
        {
            theItemEffectDatabase.ShowToolTip(item, transform.position);    // theItemEffectDatabase에서 ShowToolTip호출
        }
    }

    // 마우스가 슬롯에서 빠져나갈 때 발동
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("함수실행끝");

        theItemEffectDatabase.HideToolTip();        // theItemEffectDatabase에서 HideToolTip호출
    }
}
