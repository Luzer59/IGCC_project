using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    public void ChangeLevel(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
}
