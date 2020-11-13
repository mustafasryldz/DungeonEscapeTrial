using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Start_Button()
    {
        SceneManager.LoadScene("Game");
    }
    public void Quit_Button()
    { 
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
