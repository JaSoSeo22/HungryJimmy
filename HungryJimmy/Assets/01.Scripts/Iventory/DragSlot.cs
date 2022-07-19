using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour
{
    static public DragSlot instance;        

    public Slot dragSlot;

    // 아이템 이미지
    [SerializeField]
    private Image imageItem;

    void Start()
    {
        instance = this;        // 인스턴스에 자기자신을 넣어줌
    }

    public void DragSetImage(Image _itemImage)
    {
        imageItem.sprite = _itemImage.sprite;       // 이미지의 스프라이트 넣어줌
        SetColor(1);
    }

    public void SetColor(float _alpha)      // 선택할때만 보이게
    {
        Color color = imageItem.color;
        color.a = _alpha;
        imageItem.color = color;
    }
}
