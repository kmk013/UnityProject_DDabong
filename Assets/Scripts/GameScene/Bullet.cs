using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData = new BulletData();

    private float dis;

    private void Start()
    {
        bulletData.vStartPos = transform.localPosition;
        bulletData.BulletSetting();

        dis = Vector3.Distance(new Vector3(bulletData.vStartPos.x, 0, bulletData.vStartPos.z), 
                               new Vector3(bulletData.vEndPos.x, 0, bulletData.vEndPos.z));
    }

    private void Update()
    {
        bulletData.UpdateBullet();
        transform.position = bulletData.vPos;
        //transform.rotation = GetRotFromVectors(bulletData.vStartPos, Vector3.Normalize(bulletData.vEndPos - transform.position));
        Vector3 dir = (bulletData.vEndPos - transform.position).normalized;

        Quaternion from = transform.rotation;
        Quaternion to = Quaternion.LookRotation(dir);

        transform.localRotation = Quaternion.Lerp(from, to, Time.fixedDeltaTime);
    }

    private Quaternion GetRotFromVectors(Vector3 posStart, Vector3 posEnd) {
        return Quaternion.Euler(-Mathf.Atan(posEnd.x - posStart.x) * Mathf.Rad2Deg,
                                -Mathf.Atan(posEnd.y - posStart.y) * Mathf.Rad2Deg,
                                -Mathf.Atan(posEnd.z - posStart.z) * Mathf.Rad2Deg);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Ground")) Destroy(this.gameObject);

        if (other.CompareTag("Boat"))
            if(other.transform.parent.GetComponent<Ship>().shipData.side != bulletData.side)
                other.transform.parent.GetComponent<Ship>().shipData.shipHpData.hp -= bulletData.damage;
    }
}
