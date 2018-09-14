using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonManager : MonoBehaviour {

    private int id = 0;

    public List<GameObject> stageButtons = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < GameTotalManager.Instance.isClear.Count; i++) {
            if (GameTotalManager.Instance.isClear[i] == true)
                stageButtons[i].SetActive(true);
        }
    }

    public void StartButtonClick() {
        if(id != 0) {
            GameTotalManager.Instance.stageNum = id;
            SceneManager.LoadScene("StartNextScene");
        }
    }

    public void StageButtonClick(int stageId) {
        id = stageId;
        StartTextManager.Instance.ChangeIntroText(stageId);
    }
}
