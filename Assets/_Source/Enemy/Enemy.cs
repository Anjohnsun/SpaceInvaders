using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private SpriteRenderer spriteR;
    [SerializeField] private int givesScore;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        hp--;
        if (hp <= 0)
        {
            Score.IncreaseScore(givesScore);
            EnemyArmy.IncreaseKilledEnemies();
            Destroy(gameObject);
        }
    }
    private void InitializeEnemy(Sprite Sprite)
    {
        spriteR.sprite = Sprite;
        hp = Random.Range(0, 2);
        givesScore = Random.Range(0,5);
    }

    void OnBecameVisible()
    {
        InitializeEnemy(EnemyArmy.EnemySprites[Random.Range(0, 3)]);
        Debug.Log("Working!");
    }

    
}

