using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public void OnStartGame(string ScneneName)
    {
        Application.LoadLevel(ScneneName);//讀取場景,場景名稱
    }
}
