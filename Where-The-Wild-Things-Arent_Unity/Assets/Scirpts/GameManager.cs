using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool isGameOver = false;

    public void RestartButton()
    {
        SceneManager.LoadScene("WhereTheWildThingArent");
    }

}
