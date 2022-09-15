using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 0.1f;
    [SerializeField] private float _bulletDelay = 1;
    private void Start()
    {
        StartCoroutine(MoveBullet());
    }

    private IEnumerator MoveBullet()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + _bulletSpeed);
        yield return new WaitForSeconds(_bulletDelay);
        yield return StartCoroutine(MoveBullet());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this);
    }
}
