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
        StartCoroutine(ChangeAlpha(_mainMenu, true));
        StartCoroutine(ChangeAlpha(_credits, false, _fadeTime));
    }

    public void ShowMenu()
    {
        StartCoroutine(ChangeAlpha(_credits, true));
        StartCoroutine(ChangeAlpha(_mainMenu, false, _fadeTime));
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

    private IEnumerator ChangeAlpha(CanvasGroup menu, bool hide, float startDelay = 0)
    {
        yield return new WaitForSeconds(startDelay);
        menu.interactable = !hide;
        menu.blocksRaycasts = !hide;
        float fadingTimer = 0;
        while (fadingTimer < _fadeTime)
        {
            fadingTimer += Time.deltaTime;
            if(hide)
                menu.alpha = Mathf.Clamp(1f - fadingTimer / _fadeTime, 0, 1);
            else
                menu.alpha = Mathf.Clamp(fadingTimer / _fadeTime, 0, 1);
            yield return null;
        }
    }    
}
