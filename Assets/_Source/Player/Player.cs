using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private float _shootingDelay = 1;

    private PlayerMovement _playerMovement;
    private PlayerCombat _playerCombat;

    private void Start()
    {
        _playerMovement = new PlayerMovement();
        _playerCombat = new PlayerCombat(_bulletPrefab, _shootingPoint);

        StartCoroutine(Shoot());
    }

    public void Move(string way)
    {
        _playerMovement.Move(_transform, way, _speed);
    }
    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(_shootingDelay);
        _playerCombat.Shoot();
        Debug.Log("Shoot!");
        yield return StartCoroutine(Shoot());
    }
}
