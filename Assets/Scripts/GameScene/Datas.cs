using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum Side
{
    ALLY,
    ENEMY
}

public enum PlayerOrAI
{
    PLAYER,
    AI
}

public enum Condition
{
    FIRE,
    LOW_MORALE
}

[System.Serializable]
public class ShipData
{
    public PlayerOrAI playerOrAI;
    public Side side;
    public List<GameObject> weapons = new List<GameObject>();
    public List<ShipWeaponData> weaponDatas = new List<ShipWeaponData>();

    [HideInInspector] public NavMeshAgent nav;

    public ShipHpData shipHpData = new ShipHpData();
    public ShipSpeedData shipSpeedData = new ShipSpeedData();
    public ShipRepairData shipRepairData = new ShipRepairData();
}

[System.Serializable]
public struct ShipHpData
{
    public float maxHp;
    [HideInInspector] public float hp;
}

[System.Serializable]
public struct ShipSpeedData
{
    [Range(0.0f, 1.0f)] public float moveSpeed;
    [Range(0.0f, 1.0f)] public float rotateSpeed;
    [Range(0.0f, 1.0f)] public float maxAcceleration;
}

[System.Serializable]
public struct ShipRepairData
{
    [HideInInspector] public bool isCanRepair;
    [HideInInspector] public bool isRepairing;

    [HideInInspector] public float repairUseTime;
    [HideInInspector] public float repairDelayTime;
    public float repairUseDelay;
    public float repairDelayDelay;

    public void RepairTimeFlow()
    {
        if (isRepairing)
            if (repairUseTime >= repairUseDelay)
            {
                isCanRepair = false;
                isRepairing = false;
                repairUseTime = 0;
            }
            else
                repairUseTime += Time.deltaTime;
        else if (!isCanRepair)
            if (repairDelayTime >= repairDelayDelay)
            {
                isCanRepair = true;
                repairDelayTime = 0;
            }
            else
                repairDelayTime += Time.deltaTime;
    }
}

[System.Serializable]
public class ShipWeaponData
{
    public float damage;
    public float radius;

    [Space(15)]
    [HideInInspector] public bool isCanShoot;
    [HideInInspector] public float reUseTime;
    public float reUseDelay;

    public void SwitchIsShoot()
    {
        if (reUseTime <= 0)
        {
            isCanShoot = true;
            reUseTime = 0;
        }
        else
        {
            isCanShoot = false;
            reUseTime -= Time.deltaTime;
        }
    }
}

////////////////////////////////////////////////////////////
[System.Serializable]
public class CannonsGroupData
{
    [HideInInspector] public bool isReShootDelaying;

    [HideInInspector] public float reShootTime;
    public float reShootDelay;

    public void ReShootTimeFlow()
    {
        if (isReShootDelaying)
        {
            if (reShootTime <= reShootDelay)
                reShootTime += Time.deltaTime;
            else
            {
                reShootTime = reShootDelay;
                isReShootDelaying = false;
            }
        }
    }
}

/// ////////////////////////////////////////////////////////
[System.Serializable]
public class BulletData
{
    [HideInInspector] public Side side;

    public float damage;
    public float radius;

    [HideInInspector] public Vector3 vStartPos;              // 출발지
    [HideInInspector] public Vector3 vEndPos;                // 목적지
    [HideInInspector] public Vector3 vPos;                   // 현재 위치

    private float fV_X;                                      // X축으로 속도
    private float fV_Y;                                      // Y축으로 속도
    private float fV_Z;                                      // Z축으로 속도

    private float fg;                                        // Y축으로의 중력가속도 (9.8아님 밑에서 구해줌)
    private float fEndTime;                                  // 도착지점 도달 시간
    private float fMaxHeight = 1f;                           // 최대 높이
    private float fHeight;                                   // 최대높이의 Y - 시작높이의 Y
    private float fEndHeight;                                // 도착지점 높이 Y - 시작지점 높이 Y
    private float fTime;                                     // 흐르는 시간.
    private float fMaxTime = 2.5f;                           // 최대높이 까지 가는 시간. 정해준다. 

    public void BulletSetting()
    {
        fEndHeight = vEndPos.y - vStartPos.y;

        fHeight = fMaxHeight;

        fg = 2 * fHeight / (fMaxTime * fMaxTime);

        fV_Y = Mathf.Sqrt(2 * fg * fHeight);

        float a = fg;
        float b = -2 * fV_Y;
        float c = 2 * fEndHeight;

        fEndTime = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);

        fV_X = -(vStartPos.x - vEndPos.x) / fEndTime;
        fV_Z = -(vStartPos.z - vEndPos.z) / fEndTime;
    }

    public void UpdateBullet()
    {
        fTime += Time.deltaTime;

        vPos.x = vStartPos.x + fV_X * fTime;
        vPos.y = vStartPos.y + (fV_Y * fTime) - (0.5f * fg * fTime * fTime);
        vPos.z = vStartPos.z + fV_Z * fTime;
    }
}