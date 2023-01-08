using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
    public void FailGame()
    {
        SceneManager.LoadScene("BreakBrick"); // BreakBrick 씬으로 이동하라
    } 

    
}
