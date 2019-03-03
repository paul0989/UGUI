using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelScroll : MonoBehaviour,IBeginDragHandler, IEndDragHandler {

    private ScrollRect scrollRect;
    public float smoothing = 5;
    public Toggle[] toggleArray;//滑動時頁籤跟著跳
    private float[] pageArray = new float[] { 0, 0.335f, 0.665f, 0.99f };//放入取得的座標
    private float targetHorizontalPosition=0;//定義目標點
    private bool isDraging = false;
    // Use this for initialization
    void Start () {
        scrollRect = GetComponent<ScrollRect>();//取得Component裡的ScrollRect組件
	}
	
	// Update is called once per frame
	void Update () {
        if (isDraging == false)//因為update內會每個frame都執行,較消耗資源,所以加了isDraging布林做開關
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(scrollRect.horizontalNormalizedPosition, targetHorizontalPosition, Time.deltaTime * smoothing);//Mathf.Lerp把一個值緩動的變換
        }
    }

    public void OnBeginDrag(PointerEventData eventData)//拖曳物件起始點
    {
        //throw new System.NotImplementedException();
        isDraging = true;
    }

    public void OnEndDrag(PointerEventData eventData)//拖曳物件結束發生
    {
        //throw new System.NotImplementedException();
        //Vector2 temp = scrollRect.normalizedPosition;//取得拖曳結尾的座標
        isDraging = false;
        float posX = scrollRect.horizontalNormalizedPosition;//EnDrag的點
        int index = 0;//預設的頁碼
        float offset = Math.Abs( pageArray[index]-posX);//差值運算
        //print(posX);
        for (int i = 1; i < pageArray.Length; i++)
        {
            float offsettemp = Math.Abs(pageArray[i] - posX);//取得的座標距離目前座標距離
            if (offsettemp < offset)
            {
                index = i;
                offset = offsettemp;//實現跳頁(離Array點最近的位置)
            }
        }
        targetHorizontalPosition = pageArray[index];
        toggleArray[index].isOn = true;//滑動時頁籤跟著跳
        //scrollRect.horizontalNormalizedPosition = pageArray[index];//取得座標
    }
    public void TurnToPage1(bool isOn)//Toggle的Is On
    {
        if (isOn)
        {
            targetHorizontalPosition = pageArray[0];//跳到第一頁
        }
    }
    public void TurnToPage2(bool isOn)//Toggle的Is On
    {
        if (isOn)
        {
            targetHorizontalPosition = pageArray[1];//跳到第二頁
        }
    }
    public void TurnToPage3(bool isOn)//Toggle的Is On
    {
        if (isOn)
        {
            targetHorizontalPosition = pageArray[2];//跳到第三頁
        }
    }
    public void TurnToPage4(bool isOn)//Toggle的Is On
    {
        if (isOn)
        {
            targetHorizontalPosition = pageArray[3];//跳到第四頁
        }
    }
}
