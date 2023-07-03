using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver :MonoBehaviour {

    public GameObject gameOverScreen;
    public TextMeshProUGUI secondsSurvivedUI;
    bool gameOver;
    // Start is called before the first frame update
    void Start () {
        FindObjectOfType<PlayerMovement>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update () {
        if (gameOver) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnGameOver () {
        gameOverScreen.SetActive(true);
        secondsSurvivedUI.text = ((int)Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
