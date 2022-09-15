using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Player _player;
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _player.Move("left");
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _player.Move("right");
        }
    }

}
