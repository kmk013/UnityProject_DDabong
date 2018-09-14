using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class Ship : MonoBehaviour
{
    public ShipData shipData = new ShipData();

    public void GameManagerListAdd()
    {
        if (shipData.side == Side.ALLY)
            GameManager.Instance.allyList.Add(this.gameObject);
        else
            GameManager.Instance.enemyList.Add(this.gameObject);
    }

    public void ShipSetting() {
        GameManagerListAdd();

        shipData.nav = GetComponent<NavMeshAgent>();
        shipData.nav.speed = shipData.shipSpeedData.moveSpeed;
        shipData.nav.acceleration = shipData.shipSpeedData.maxAcceleration;

        shipData.shipHpData.hp = shipData.shipHpData.maxHp;
        shipData.shipRepairData.isCanRepair = true;

        foreach (var i in shipData.weapons)
        {
            shipData.weaponDatas[shipData.weapons.IndexOf(i)].damage = i.GetComponent<Bullet>().bulletData.damage;
            shipData.weaponDatas[shipData.weapons.IndexOf(i)].radius = i.GetComponent<Bullet>().bulletData.radius;
        }
    }
}
