using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup _mainMenu;
    [SerializeField] private CanvasGroup _credits;
    [SerializeField] private float _fadeTime;

    public void Exit()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        SetVisibility(_mainMenu, true);
        SetVisibility(_credits, false, _fadeTime);
    }

    public void ShowMenu()
    {
        SetVisibility(_credits, true);
        SetVisibility(_mainMenu, false, _fadeTime);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        _credits.alpha = 0;
        _credits.interactable = false;
        _credits.blocksRaycasts = false;
    }

    private void SetVisibility(CanvasGroup menu, bool visibility, float startDelay = 0)
    {
        menu.blocksRaycasts = visibility;
        menu.interactable = visibility;
        float targetAlpha = visibility ? 1 : 0;
        StartCoroutine(ChangeAlpha(menu, targetAlpha, _fadeTime, startDelay));
    }

    private IEnumerator ChangeAlpha(CanvasGroup menu, float alpha, float changingTime, float startDelay = 0)
    {
        yield return new WaitForSeconds(startDelay);
        var startingAlpha = menu.alpha;
        float fadingTimer = 0;
        while (fadingTimer < changingTime)
        {
            fadingTimer += Time.deltaTime;
            menu.alpha = Mathf.Lerp(startingAlpha, alpha, fadingTimer / changingTime);
            yield return null;
        }
    }
}
