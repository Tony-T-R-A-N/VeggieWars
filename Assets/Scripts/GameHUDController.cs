using System.Collections;
using UnityEngine;
using TMPro;

public class GameHUDController : MonoBehaviour {

    public GameObject tryAgainButton;
    public GameObject mainMenuButton;
    public GameObject optionRetryButton;
    public GameObject optionLevelSelectButton;
    public GameObject optionsButton;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI gameMessageText;
    public MainMenuController mainMenuController;
    static int healthValue = 100;
    static int moneyValue = 0;

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
        StopCoroutine(MinimizeOptions());
    }

    IEnumerator MinimizeOptions() {
        yield return new WaitForSeconds(2f);

        optionRetryButton.SetActive(false);
        optionLevelSelectButton.SetActive(false);
        optionsButton.SetActive(true);
    }

    public void GoToMainMenuWhileInGame() {
        mainMenuController.MainMenu();
    }

    public void RetryWhileInGame() {
        mainMenuController.TryAgain();
    }

    public void GoToLevelSelectWhileInGame() {
        mainMenuController.LevelSelect();
    }

    void ResetHUD() {
        healthValue = 100;
        moneyValue = 0;
    }

    public void IncrementHealth(int health) {
        healthValue += health;
        healthText.text = "Health: " + healthValue;
    }

    public void DecrementHealth(int health) {
        healthValue -= health;
        healthText.text = "Health: " + healthValue;

        if (healthValue <= 0) {
            ShowGameOverButtons();
        }
    }

    public void IncrementMoney(int money) {
        moneyValue += money;
        moneyText.text = "Money: $" + moneyValue;
    }

    public void DecrementMoney(int money) {
        moneyValue -= money;
        moneyText.text = "Money: $" + moneyValue;
    }

    public void WaveNumberText(string number) {
        gameMessageText.text = "Wave " + number;
    }

    public void WaveCompleteText() {
        gameMessageText.text = "Wave Complete";
    }

    public void GameOverText() {
        gameMessageText.text = "Game Over";
    }
}
