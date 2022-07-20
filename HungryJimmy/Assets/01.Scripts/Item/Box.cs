using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    List<int> num = new List<int>();        // 새로운 리스트 생성

    public GameObject box;
    public GameObject logBox;
    public GameObject clothBox;


    // Start is called before the first frame update
    void Start()
    {
        num.Add(0);     // 리스트에 값 추가
        num.Add(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()      // 마우스 클릭하면
    {
        Find();     // Find()실행
    }

    IEnumerator LogBoxChange()      // Log 아이템을 가진 박스 코루틴
    {
        box.SetActive(false);       // 박스 오브젝트 비활성화
        logBox.SetActive(true);     // Log 아이템 박스 활성화
        yield return new WaitForSeconds(3f * Time.deltaTime);       // 지연시간
        logBox.SetActive(false);
    }
    IEnumerator ClothBoxChange()        // Cloth 아이템을 가진 박스 코루틴
    {
        box.SetActive(false);       // 박스 오브젝트 비활성화
        clothBox.SetActive(true);       // 천 아이템 박스 활성화
        yield return new WaitForSeconds(3f * Time.deltaTime);       // 지연시간
        clothBox.SetActive(false);
    }

    public void Find()
    {
        int index = num.FindIndex((int p) => p == 0);       // 리스트에서 값이 0인 값의 인덱스 번호
        int a = num[index];
        Debug.Log(a);
        if (num[index] == 0)        // 리스트 num의 인덱스가 0이면
        {
            box.SetActive(true);
            StartCoroutine(LogBoxChange());     // Log박스 바꿔주는 코루틴 실행
        }
        if (num[index] == 1)        // 리스트 num의 인덱스가 1이면
        {
            box.SetActive(true);
            StartCoroutine(ClothBoxChange());       // Cloth박스 바꿔주는 코루틴 실행
        }
    }

}
