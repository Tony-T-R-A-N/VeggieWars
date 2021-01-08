using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {
    
    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void LevelSelect() {
        SceneManager.LoadScene(1);
    }

    public void TryAgain() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
