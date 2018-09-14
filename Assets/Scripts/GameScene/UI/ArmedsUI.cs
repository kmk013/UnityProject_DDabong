using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedsUI : MonoBehaviour
{
    [HideInInspector] public List<ReloadUI> reloadUIs = new List<ReloadUI>();

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            reloadUIs.Add(transform.GetChild(i).GetComponent<ReloadUI>());
    }

    public void UpdateReloadUI(List<ShipWeaponData> weaponDatas)
    {
        foreach (var i in reloadUIs)
            if (reloadUIs.IndexOf(i) < reloadUIs.Count - 1)
                i.ReloadTimeFlow(weaponDatas[reloadUIs.IndexOf(i)].reUseTime, weaponDatas[reloadUIs.IndexOf(i)].reUseDelay);
    }

    public void UpdateRepairUI(ShipRepairData data)
    {
        if (data.isRepairing)
            reloadUIs[reloadUIs.Count - 1].ReloadTimeFlow(data.repairUseTime, data.repairUseDelay);
        else if (!data.isCanRepair)
            reloadUIs[reloadUIs.Count - 1].ReloadTimeFlow(data.repairDelayDelay - data.repairDelayTime, data.repairDelayDelay);
    }
}
