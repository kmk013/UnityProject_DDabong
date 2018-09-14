using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Atakebune : Ship
{
    private List<GameObject> copyAllyOrEnemyList;

    private float reShootTime = 0;

    private void Start()
    {
        ShipSetting();
    }

    private void Update()
    {
        Move();
        Attack();
        Function();

        foreach(var a in shipData.weaponDatas)
            a.SwitchIsShoot();

        reShootTime -= Time.deltaTime;
        if (reShootTime <= 0) reShootTime = 0;
    }

    public void Attack()
    {
        foreach (var i in GameManager.Instance.allyList)
            foreach (var j in shipData.weaponDatas)
                if (Vector3.Distance(transform.position, i.transform.position) <= j.radius && 
                    j.isCanShoot && reShootTime <= 0)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        GameObject obj = Instantiate(shipData.weapons[shipData.weaponDatas.IndexOf(j)], transform.position, Quaternion.identity);
                        obj.GetComponent<Bullet>().bulletData.side = shipData.side;
                    obj.GetComponent<Bullet>().bulletData.vEndPos = i.transform.position + new Vector3(Random.Range(-0.25f, 0.25f), 0, Random.Range(-0.25f, 0.25f));
                    }
                    j.reUseTime = 60f;
                    reShootTime = 10f;
                }
    }

    public void Move()
    {
        shipData.nav.SetDestination(SearchNearObject().transform.position);
    }

    public void Function()
    {
        foreach(var i in GameManager.Instance.enemyList)
            if(Vector3.Distance(transform.position, i.transform.position) <= 150f)
                foreach (var j in i.GetComponent<Ship>().shipData.weaponDatas)
                    j.reUseDelay = j.reUseDelay / 100 * 5;
            else
                foreach (var j in i.GetComponent<Ship>().shipData.weaponDatas)
                    j.reUseDelay = 60;
    }

    private GameObject SearchNearObject()
    {
        if (shipData.side == Side.ALLY) copyAllyOrEnemyList = GameManager.Instance.enemyList;
        else copyAllyOrEnemyList = GameManager.Instance.allyList;

        copyAllyOrEnemyList.Sort(delegate (GameObject a, GameObject b)
        {
            if (Vector3.Distance(transform.position, b.transform.position) > Vector3.Distance(transform.position, a.transform.position)) return -1;
            else if (Vector3.Distance(transform.position, a.transform.position) > Vector3.Distance(transform.position, b.transform.position)) return 1;
            return 0;
        });

        return copyAllyOrEnemyList[0];
    }
}
