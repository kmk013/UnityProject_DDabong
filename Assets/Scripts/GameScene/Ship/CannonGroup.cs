using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonGroup : MonoBehaviour
{
    [HideInInspector] public List<Cannon> cannons = new List<Cannon>();
    public CannonsGroupData cannonsGroupData = new CannonsGroupData();

    public AudioSource shootSound;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            cannons.Add(transform.GetChild(i).GetComponent<Cannon>());
    }

    private void Update()
    {
        cannonsGroupData.ReShootTimeFlow();
    }

    public void ShootCannons(GameObject gameObject, Side side, Vector3 endPos)
    {
        if (!cannonsGroupData.isReShootDelaying)
        {
            shootSound.Play();
            cannonsGroupData.isReShootDelaying = true;
            foreach (var i in cannons)
            {
                i.shootObject = gameObject;
                i.InstantiateBullet(side, endPos);
            }
        }
    }
}
