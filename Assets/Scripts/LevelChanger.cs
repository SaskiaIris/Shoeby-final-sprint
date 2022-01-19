using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;
    [SerializeField]
    private int clicked, clicksNeeded;

    void Start()
    {
        clicked = 0;
        clicksNeeded = 4;
    }

    public void FadeToNextLevel()
    {
        clicked++;
        if (clicked == clicksNeeded)
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void FadeToLevel (int levelIndex) 
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
