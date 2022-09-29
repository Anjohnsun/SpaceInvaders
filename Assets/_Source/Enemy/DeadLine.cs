using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    [SerializeField] private LosePanel losePanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        losePanel.gameObject.SetActive(true);
    }
}
