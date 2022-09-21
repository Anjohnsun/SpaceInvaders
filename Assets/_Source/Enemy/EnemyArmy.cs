using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    [Range(1, 9)]
    [SerializeField] private int _columns;
    [Range(1, 50)]
    [SerializeField] private int _enemyNumber;
    private int[] rows;

    [SerializeField] private List<EnemySO> EnemyTypes = new List<EnemySO>();
    [SerializeField] private GameObject ArmyRow;
    [SerializeField] private GameObject EmptyEnemyPrefab;
    [SerializeField] private GameObject LeftPointer;
    [SerializeField] private GameObject RightPointer;

    [SerializeField] private float _speed;
    [SerializeField] private float _verticalSpeed;


    private void Start()
    {
        InitArmy();
    }
    private void InitArmy()
    {
        for (int i = 0; i < _enemyNumber / _columns + 1; i++)
        {
            Instantiate(ArmyRow, transform);
        }

        StartCoroutine(CreateArmy());
    }

    private IEnumerator CreateArmy()
    {
        int enemiesCreated = 0;

        yield return new WaitForSeconds(0.5f);

        for (int i = 0; i < 2; i++)
        {
            transform.GetChild(i).position = new Vector2(transform.GetChild(i).position.x,
                transform.GetChild(i).position.y + 1.45f * i);
            for (int j = 0; j < _columns; j++)
            {
                yield return new WaitForSeconds(0.2f);
                if (enemiesCreated < _enemyNumber)
                {
                    Instantiate(EmptyEnemyPrefab, new Vector2(8.5f - 1.7f * j, transform.GetChild(i).position.y),
                        new Quaternion(), transform.GetChild(i));
                    enemiesCreated++;
                }
            }
        }
        for (int i = 2; i < _enemyNumber / _columns + 1; i++)
        {
            transform.GetChild(i).position = new Vector2(transform.GetChild(i).position.x,
                transform.GetChild(i).position.y + 1.45f * i);
            for (int j = 0; j < _columns; j++)
            {
                if (enemiesCreated < _enemyNumber)
                {
                    Instantiate(EmptyEnemyPrefab, new Vector2(8.5f - 1.7f * j, transform.GetChild(i).position.y),
                        new Quaternion(), transform.GetChild(i));
                    enemiesCreated++;
                }
            }
        }


        LeftPointer = Instantiate(new GameObject(), transform);
        LeftPointer.transform.position = new Vector2(transform.GetChild(0).GetChild(transform.GetChild(2).childCount-1)
            .transform.position.x, 10);
        RightPointer = Instantiate(new GameObject(), transform);
        RightPointer.transform.position = new Vector2(transform.GetChild(0).GetChild(0)
            .transform.position.x, 10);

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (LeftPointer.transform.position.x > -9)
        {
            yield return new WaitForSeconds(0.6f);
            transform.position = new Vector2(transform.position.x-1, transform.position.y);
        }
        yield return new WaitForSeconds(0.6f);
        transform.position = new Vector2(transform.position.x, transform.position.y-0.6f);
        while (RightPointer.transform.position.x <  9)
        {
            yield return new WaitForSeconds(0.6f);
            transform.position = new Vector2(transform.position.x + 1, transform.position.y);
        }
        yield return new WaitForSeconds(0.6f);
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.6f);

        yield return StartCoroutine(Move());
    }
}
