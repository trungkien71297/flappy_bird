using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameState : MonoBehaviour
{
    [SerializeField] GameObject restartButton;
    [SerializeField] TMP_Text text;
    public bool isStart { get; set; }
    public int score { get; set; } = 0;

    public bool gameOver { get; set; }

    public void UpdateScore()
    {
        score++;
        text.text = score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void DisableButton()
    {
        restartButton.SetActive(false);
    }

    public void EnbaleButton()
    {
        restartButton.SetActive(true);
        Button button = restartButton.GetComponent<Button>();
        button.onClick.AddListener(delegate { SetRestartClick(); });
    }

    private void SetRestartClick()
    {
        SceneManager.LoadScene(0);
    }

}
