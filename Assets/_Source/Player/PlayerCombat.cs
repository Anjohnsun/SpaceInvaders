using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat
{
    private GameObject _bullet;
    private Transform _shootPoint;
    public PlayerCombat(GameObject bullet, Transform shootPoint)
    {
        _bullet = bullet;
        _shootPoint = shootPoint;
    }
    public void Shoot()
    {
        GameObject.Instantiate(_bullet, _shootPoint.position, _shootPoint.rotation);
    }
}
