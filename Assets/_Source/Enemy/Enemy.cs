using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private SpriteRenderer sprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp--;
        if (hp <= 0) Destroy(gameObject);
    }
    public void InitializeEnemy(EnemySO enSO)
    {
        sprite.sprite = enSO._enemySprite;
        hp = enSO._hp;
    }
}
