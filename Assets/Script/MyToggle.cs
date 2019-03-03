using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyToggle : MonoBehaviour {
    public GameObject isOngameObject;
    public GameObject isOffgameObject;
    private Toggle toggle;
    // Use this for initialization
    void Start () {
        toggle = GetComponent<Toggle>();
        OnvalueChange(toggle.isOn);//如果toggle被點擊的話
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnvalueChange(bool isOn)
    {
        isOngameObject.SetActive(isOn);
        isOffgameObject.SetActive(!isOn);
    }
}
