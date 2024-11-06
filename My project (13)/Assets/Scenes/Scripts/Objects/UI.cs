using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void Scenes()
    {
        SceneManager.LoadScene(0);
    }
    public void Scenes2()
    {
        SceneManager.LoadScene(1);
    }
}
