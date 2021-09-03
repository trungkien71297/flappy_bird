using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMenu : MonoBehaviour
{
    [SerializeField] TMP_Text maxScore;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        maxScore.text = PlayerPrefs.GetInt("score", 0).ToString();
    }

    // Update is called once per frame
    public void StartGame()
    {        
        SceneManager.LoadScene(1);
    }
}
