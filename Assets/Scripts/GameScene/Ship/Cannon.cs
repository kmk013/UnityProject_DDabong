using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    [HideInInspector] public GameObject shootObject;

    public void InstantiateBullet(Side side, Vector3 endPos) {
        GameObject obj = Instantiate(shootObject, transform.position, Quaternion.identity);

        obj.GetComponent<Bullet>().bulletData.side = side;
        obj.GetComponent<Bullet>().bulletData.vEndPos = endPos + new Vector3(Random.Range(-0.25f, 0.25f), 0, Random.Range(-0.25f, 0.25f));
    }
}
