using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public Scene scene;
    public int index;

    public Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(LoadNextLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(index);
    }
}
