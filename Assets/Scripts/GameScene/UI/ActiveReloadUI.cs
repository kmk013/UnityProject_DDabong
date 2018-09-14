using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ActiveReloadUI : SingleTon<ActiveReloadUI> {

    private RectTransform rectTransform;

    public Player player;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        rectTransform.anchoredPosition = new Vector2(-1.275f, UIManager.Instance.armedsUI.reloadUIs[0].transform.parent.GetComponent<RectTransform>().anchoredPosition.y);
    }

    public void SetActiveReloadUI(GameObject gameObject)
    {
        rectTransform.anchoredPosition = new Vector2(
            -(1.65f - gameObject.GetComponent<RectTransform>().anchoredPosition.x),
            gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition.y
        );
    }

}
