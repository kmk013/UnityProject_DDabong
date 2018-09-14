using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestText : SingleTon<TestText> {

    public void SetText(string text) {
        GetComponent<Text>().text = text;
    }
}
