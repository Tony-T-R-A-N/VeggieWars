using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHUDController : MonoBehaviour {

    public GameObject tryAgainButton;
    public GameObject mainMenuButton;
    public GameObject optionRetryButton;
    public GameObject optionLevelSelectButton;
    public GameObject optionsButton;
    static int enemiesAlive = 0;

    public void IncrementEnemiesAlive() {
        enemiesAlive++;
    }

    public void DecrementEnemiesAlive() {
        enemiesAlive--;

        if (enemiesAlive <= 0) {
            ShowGameOverButtons();
        }
    }

    public void ShowGameOverButtons() {
        tryAgainButton.SetActive(true);
        mainMenuButton.SetActive(true);
        optionRetryButton.SetActive(false);
        optionLevelSelectButton.SetActive(false);
        optionsButton.SetActive(false);
    }

    public void ShowOptions() {
        optionRetryButton.SetActive(true);
        optionLevelSelectButton.SetActive(true);
        optionsButton.SetActive(false);

        StartCoroutine(MinimizeOptions());
    }

    IEnumerator MinimizeOptions() {
        yield return new WaitForSeconds(2f);

        optionRetryButton.SetActive(false);
        optionLevelSelectButton.SetActive(false);
        optionsButton.SetActive(true);
    }
}
