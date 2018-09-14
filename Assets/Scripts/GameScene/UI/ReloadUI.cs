using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadUI : MonoBehaviour
{
    public GameObject reloadImageObj;
    public GameObject reloadTextObj;

    public Player player;

    private Button thisButton;
    private Image reloadImage;
    private Text reloadText;

    private void Start()
    {
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(() =>
        {
            if (name.Equals("R"))
            {
                if (player.shipData.shipRepairData.isCanRepair)
                {
                    player.shipData.shipRepairData.isCanRepair = false;
                    player.shipData.shipRepairData.isRepairing = true;
                }
            }
            else
            {
                player.playerShootIndex = int.Parse(name) - 1;
                ActiveReloadUI.Instance.SetActiveReloadUI(this.gameObject);
            }
        });

        reloadImage = reloadImageObj.GetComponent<Image>();
        reloadText = reloadTextObj.GetComponent<Text>();
    }

    public void ReloadTimeFlow(float time, float delay)
    {
        float tot = time / delay;
        reloadImage.fillAmount = tot;

        if (time > 0)
            reloadText.text = ((int)time).ToString();
        else
            reloadText.text = "";
    }

    public void Click() {
        if (name.Equals("R"))
        {
            if (player.shipData.shipRepairData.isCanRepair)
            {
                player.shipData.shipRepairData.isCanRepair = false;
                player.shipData.shipRepairData.isRepairing = true;
            }
        }
        else
            player.playerShootIndex = int.Parse(name) - 1;
    }
}