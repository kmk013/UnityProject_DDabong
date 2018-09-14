using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingleTon<GameManager> {

    [Range(1, 10)]
    public float mouseSensitivity;

    public List<GameObject> allyList = new List<GameObject>();
    public List<GameObject> enemyList = new List<GameObject>();

    public int stageId;

    private void Update()
    {
        UIManager.Instance.allyEnemyCountUI.UpdateAllyEnemyCountUI(allyList.Count, enemyList.Count);

        if(enemyList.Count <= 0) {
            GameTotalManager.Instance.isClear[stageId] = true;
            SceneManager.LoadScene("StartScene");
        }
    }
}
