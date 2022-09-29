using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    [Range(7, 11)]
    [SerializeField] private int _enemyColumns;
    [Range(2, 25)]
    [SerializeField] private int _enemyRows;

    public static List<Sprite> EnemySprites;
    [SerializeField] private List<Sprite> SpritesForEnemies;
    [SerializeField] private GameObject ArmyRow;
    [SerializeField] private GameObject EmptyEnemyPrefab;
    [SerializeField] private GameObject LeftPointer;
    [SerializeField] private GameObject RightPointer;

    [SerializeField] private float _speed;
    [SerializeField] private float _verticalSpeed;

    [SerializeField] private WinPanel winPanel;

    public static int _alive = 0;
    [SerializeField] public int Score
    {
        get => Score;
        set
        {
            Score += value;
        }
    }


    private void Start()
    {
        InitArmy();
        EnemySprites = SpritesForEnemies;
    }
    private void InitArmy()
    {
        for (int i = 0; i < _enemyRows + 1; i++)
        {
            Instantiate(ArmyRow, transform);
        }

        StartCoroutine(CreateArmy());
    }

    private IEnumerator CreateArmy()
    {
        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 2; i++)
        {
            transform.GetChild(i).position = new Vector2(8,
                transform.GetChild(i).position.y + 1.45f * i);
            for (int j = 0; j < _enemyColumns; j++)
            {
                yield return new WaitForSeconds(0.2f);
                {
                    Instantiate(EmptyEnemyPrefab, new Vector2(8f - 1.5f * j, transform.GetChild(i).position.y),
                        new Quaternion(), transform.GetChild(i));

                    //Подставление СО 
                }
            }
        }
        for (int i = 2; i < _enemyRows; i++)
        {
            transform.GetChild(i).position = new Vector2(8,
                transform.GetChild(i).position.y + 1.45f * i);
            for (int j = 0; j < _enemyColumns; j++)
            {
                {
                    Instantiate(EmptyEnemyPrefab, new Vector2(8f - 1.5f * j, transform.GetChild(i).position.y),
                        new Quaternion(), transform.GetChild(i));

                    //Подставление СО 
                }
            }
        }

        _alive = _enemyColumns * _enemyRows;


        LeftPointer = Instantiate(new GameObject(), transform);
        LeftPointer.transform.position = new Vector2(transform.GetChild(0).GetChild(transform.GetChild(2).childCount - 1)
            .transform.position.x, 10);
        RightPointer = Instantiate(new GameObject(), transform);
        RightPointer.transform.position = new Vector2(transform.GetChild(0).GetChild(0)
            .transform.position.x, 10);

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (LeftPointer.transform.position.x > -8)
        {
            yield return new WaitForSeconds(0.6f);
            transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            if (_alive <= 0)
            {
                winPanel.gameObject.SetActive(true);
            }
        }
        yield return new WaitForSeconds(0.6f);
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.6f);
        while (RightPointer.transform.position.x < 8)
        {
            yield return new WaitForSeconds(0.6f);
            transform.position = new Vector2(transform.position.x + 1, transform.position.y);
            if (_alive <= 0)
            {
                winPanel.gameObject.SetActive(true);
            }
        }
        yield return new WaitForSeconds(0.6f);
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.6f);

        yield return StartCoroutine(Move());
    }

    public static void IncreaseKilledEnemies()
    {
        _alive--;
    }
}
