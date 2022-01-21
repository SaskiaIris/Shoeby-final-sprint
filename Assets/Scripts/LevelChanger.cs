using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {
    public Animator animator;

    private int levelToLoad;
    [SerializeField]
    private int clicked = 0;
    [SerializeField]
    private int clicksNeeded = 4;

    [SerializeField]
    private int clicksNeededResetGame = 8;

    public void FadeToNextLevelStart() {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToStartLevel() {
        clicked++;
        if(clicked == clicksNeededResetGame) {
            FadeToLevel(0);
            Debug.Log("switch nuuuuuuuu");
        };
    }

    public void FadeToNextLevelPillarButton() {
        clicked++;
        if (clicked == clicksNeeded)
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void FadeToLevel (int levelIndex) {
        levelToLoad = levelIndex;
        animator.SetTrigger("Fadeout");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }
}