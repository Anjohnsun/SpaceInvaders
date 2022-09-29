using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    public void StartNewLevel()
    {
        SceneManager.LoadScene(0);
    }
}
