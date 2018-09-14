using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPoint : MonoBehaviour {

    public Sprite validSprite;
    public Sprite unValidSprite;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeValidSprite(bool isValid) {
        if (isValid) spriteRenderer.sprite = validSprite;
        else spriteRenderer.sprite = unValidSprite;
    }
}
