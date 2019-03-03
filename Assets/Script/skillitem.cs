using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillitem : MonoBehaviour {
    public float coldtime = 2;//技能冷卻時間
    private float timer = 0;//計時器初始值
    private Image filledImage;
    private bool isStartTimer;//是否開始計算時間
    public KeyCode keycode;

	// Use this for initialization
	void Start () {
        filledImage = transform.Find("FilledSkill").GetComponent<Image>();//取得FilledSkill內的Image組件

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keycode))//當按下設定的按鈕後
        {
            isStartTimer = true;//計時器開始執行
        }

        if (isStartTimer)//如果計時器開始執行
        {
            timer += Time.deltaTime;//計時器的時間,開始往上累加
            filledImage.fillAmount = (coldtime - timer) / coldtime;//武器黑色的圖透過比例增加
        }
        if (timer >= coldtime)//當計時器的時間超過了 技能冷卻時間
        {
            filledImage.fillAmount = 0;//武器的黑色圖隱藏
            timer = 0;//計時器歸零
            isStartTimer = false;//是否開始計算時間,否
        }
	}
    public void OnClick()
    {
        isStartTimer = true;
    }
}
