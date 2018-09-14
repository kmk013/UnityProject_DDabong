using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Panoksun : Ship
{
    private List<GameObject> copyAllyOrEnemyList;

    private bool isMoving;

    private void Start()
    {
        ShipSetting();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (isMoving && Vector3.Distance(transform.position, SearchNearObject().transform.position) > 100f)
            shipData.nav.SetDestination(SearchNearObject().transform.position);
    }

    private GameObject SearchNearObject()
    {
        if (shipData.side == Side.ALLY)
            copyAllyOrEnemyList = GameManager.Instance.enemyList;
        else
            copyAllyOrEnemyList = GameManager.Instance.allyList;

        copyAllyOrEnemyList.Sort(delegate (GameObject a, GameObject b)
        {
            if (Vector3.Distance(transform.position, b.transform.position) > Vector3.Distance(transform.position, a.transform.position)) return -1;
            else if (Vector3.Distance(transform.position, a.transform.position) > Vector3.Distance(transform.position, b.transform.position)) return 1;
            return 0;
        });

        return copyAllyOrEnemyList[0];
    }
}