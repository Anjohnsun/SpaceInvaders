using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{

    public void Move(Transform transform, string way, float speed)
    {
        switch (way)
        {
            case "left":
                transform.position = new Vector2(transform.position.x-speed, transform.position.y);
                Debug.Log("111");
                break;
            case "right":
                transform.position = new Vector2(transform.position.x+speed, transform.position.y);
                break;
        }
        
    }
}
