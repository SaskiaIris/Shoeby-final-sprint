using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {
    public Animator animator;

    private int levelToLoad;
    [SerializeField]
    private int clicked = 0;
    [SerializeField]
    private int clicksNeeded = 4;

    /*void Start() {
        clicked = 0;
        clicksNeeded = 4;
    }*/

    public void FadeToNextLevelStart() {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
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