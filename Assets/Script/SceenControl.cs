using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenControl : MonoBehaviour
{
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber); 
    }
}
