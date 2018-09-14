using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNextButtonManager : MonoBehaviour {

    public void GameStartClick() {
        SceneManager.LoadScene("Stage" + GameTotalManager.Instance.stageNum);
    }
}
