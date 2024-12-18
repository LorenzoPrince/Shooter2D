using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        Cursor.visible = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scene1");
    }
    public void Exit()
    {
        Cursor.visible = true;
        Application.Quit();
    }
}
