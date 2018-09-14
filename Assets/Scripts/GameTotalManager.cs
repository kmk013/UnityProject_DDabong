using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTotalManager : SingleTon<GameTotalManager> {

    public int stageNum;

    public List<bool> isClear = new List<bool>();

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
