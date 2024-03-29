using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance = null;
    int sceneIndex;
    int levelComplete;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }
    public void isEndGame()
    {
        if (sceneIndex == 3)
        {
            Invoke("LoadMainMenu,", 1f);
        }
        else
        {
            if (levelComplete < sceneIndex)
                PlayerPrefs.SetInt("LevelComplete", sceneIndex);
            Invoke("NextLevel", 1f);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NextLevel()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
