using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpbarUI : MonoBehaviour {

    public Image hpBarImage;

    public void UpdateHpBar(float maxHp, float hp) {
        hpBarImage.fillAmount = hp / maxHp;
    }
}
