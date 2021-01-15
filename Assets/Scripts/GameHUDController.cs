using System.Collections;
using UnityEngine;

public class GameHUDController : MonoBehaviour {

    public GameObject tryAgainButton;
    public GameObject mainMenuButton;
    public GameObject optionRetryButton;
    public GameObject optionLevelSelectButton;
    public GameObject optionsButton;
    public MainMenuController mainMenuController;

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

    public void GoToMainMenuWhileInGame() {
        mainMenuController.MainMenu();
    }

    public void RetryWhileInGame() {
        mainMenuController.TryAgain();
    }

    public void GoToLevelSelectWhileInGame() {
        mainMenuController.LevelSelect();
    }
}
