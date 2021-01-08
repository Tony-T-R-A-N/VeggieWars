using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    int levelOffset = 1;

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void LevelSelect() {
        SceneManager.LoadScene(1);
    }

    // Pass in the level; the scene index will be adjusted.
    public void Level(int level) {
        SceneManager.LoadScene(level + levelOffset);
    }

    public void TryAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
