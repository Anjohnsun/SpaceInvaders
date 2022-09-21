using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    [SerializeField] private float _leftBorder;
    [SerializeField] private float _rightBorder;

    public PlayerMovement(float lb, float rb)
    {
        _leftBorder = lb;
        _rightBorder = rb;
    }
    public void Move(Transform transform, string way, float speed)
    {
        switch (way)
        {
            case "left":
                if(transform.position.x > _leftBorder)
                transform.position = new Vector2(transform.position.x-speed, transform.position.y);
                break;
            case "right":
                if (transform.position.x < _rightBorder)
                    transform.position = new Vector2(transform.position.x+speed, transform.position.y);
                break;
        }
        
    }
}
