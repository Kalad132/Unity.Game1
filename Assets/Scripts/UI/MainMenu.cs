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
        Show(_mainMenu);
        Hide(_credits, _fadeTime);
    }

    public void ShowMenu()
    {
        Show(_credits);
        Hide(_mainMenu, _fadeTime);
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

    private void Show(CanvasGroup menu, float startDelay = 0)
    {
        menu.blocksRaycasts = true;
        menu.interactable = true;
        StartCoroutine(ChangeAlpha(menu, 1, _fadeTime, startDelay));
    }

    private void Hide(CanvasGroup menu, float startDelay = 0)
    {
        menu.blocksRaycasts = false;
        menu.interactable = false;
        StartCoroutine(ChangeAlpha(menu, 0, _fadeTime, startDelay));
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
