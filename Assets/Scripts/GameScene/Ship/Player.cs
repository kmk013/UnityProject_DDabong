using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : Panoksun
{
    [Space(15)]
    public CannonGroup leftCannonGroup;
    public CannonGroup rightCannonGroup;
    public AimPoint aimPoint;

    [HideInInspector] public int playerShootIndex = 0;

    private void Start()
    {
        ShipSetting();

        shipData.nav.speed = 0;
    }

    private void Update()
    {
        TestText.Instance.SetText(shipData.nav.speed.ToString());
        transform.position = new Vector3(transform.position.x, -5.8f, transform.position.z);
        PlayerTouchPadCommand();
        Attack();

        if (IsCanShoot() != 2) aimPoint.ChangeValidSprite(true);
        else aimPoint.ChangeValidSprite(false);
        shipData.shipRepairData.RepairTimeFlow();

        foreach (var i in shipData.weaponDatas) i.SwitchIsShoot();
        UIManager.Instance.armedsUI.UpdateReloadUI(shipData.weaponDatas);
        UIManager.Instance.armedsUI.UpdateRepairUI(shipData.shipRepairData);
        UIManager.Instance.hpbarUI.UpdateHpBar(shipData.shipHpData.maxHp, shipData.shipHpData.hp);

        if (shipData.shipHpData.hp <= 0) SceneManager.LoadScene("StartScene");
    }

    private void PlayerTouchPadCommand()
    {
        Vector2 touchPadVector = OVRInput.Get(OVRInput.Axis2D.Any);

        if (touchPadVector.y >= -0.5f && touchPadVector.y <= 0.5f) shipData.nav.speed = Mathf.Abs(touchPadVector.y) * 4 * shipData.shipSpeedData.moveSpeed;
        if (touchPadVector.y > 0) shipData.nav.SetDestination(transform.position + transform.forward);
        else if (touchPadVector.y < 0) shipData.nav.SetDestination(transform.position - transform.forward);

        if (touchPadVector.x > 0.25f)
            transform.Rotate(Vector3.up * shipData.shipSpeedData.rotateSpeed);
        else if (touchPadVector.x < -.25f)
            transform.Rotate(Vector3.down * shipData.shipSpeedData.rotateSpeed);
    }

    private int IsCanShoot()
    {
        float rot = Vector3.Angle(Camera.main.transform.forward, transform.forward);

        if (CameraManager.Instance.GetRaycastHit().collider != null &&
            CameraManager.Instance.GetRaycastHit().collider.name.Equals("Area") &&
            shipData.weaponDatas[playerShootIndex].isCanShoot &&
            Vector3.Distance(transform.position, CameraManager.Instance.GetRaycastHit().transform.position) <= shipData.weaponDatas[playerShootIndex].radius &&
            ((rot >= -135 && rot <= -45) || (rot >= 45 && rot <= 135)))
        {
            if (Camera.main.transform.rotation.y - transform.rotation.y > 0 &&
                    !rightCannonGroup.cannonsGroupData.isReShootDelaying)
                return 0;

            if (Camera.main.transform.rotation.y - transform.rotation.y < 0 &&
                         !leftCannonGroup.cannonsGroupData.isReShootDelaying)
                return 1;
        }
        return 2;
    }

    private void Attack()
    {
        if (OVRInput.GetDown(OVRInput.Button.One) && IsCanShoot() != 2 && playerShootIndex == 0)
        {
            if (IsCanShoot() == 0) rightCannonGroup.ShootCannons(shipData.weapons[playerShootIndex], shipData.side, CameraManager.Instance.GetRaycastHit().point);
            else if (IsCanShoot() == 1) leftCannonGroup.ShootCannons(shipData.weapons[playerShootIndex], shipData.side, CameraManager.Instance.GetRaycastHit().point);
            shipData.weaponDatas[playerShootIndex].reUseTime = shipData.weaponDatas[playerShootIndex].reUseDelay;
        }
    }
}