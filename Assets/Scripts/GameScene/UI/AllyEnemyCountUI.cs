using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyEnemyCountUI : MonoBehaviour {

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void UpdateAllyEnemyCountUI(int allyCount, int enemyCount) {
        text.text = "<color=blue>" + allyCount.ToString() + "</color> : <color=red>" + enemyCount.ToString() + "</color>";
    }
}
