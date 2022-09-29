using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "EnemySO")]
public class EnemySO : ScriptableObject
{
    public int _hp;
    public Sprite _enemySprite;
    public int _givesScore;
}
