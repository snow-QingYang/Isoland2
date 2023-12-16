using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;
    [SceneName] public string startScene;

    private bool isFade;

    private void Start()
    {
        StartCoroutine(TransitionToScene(string.Empty, startScene));
    }
    public void Transition(string from, string to)
    {
        if (!isFade)
        StartCoroutine(TransitionToScene(from, to));
    }
    private IEnumerator  TransitionToScene(string from, string to)
    {
        yield return Fade(1);
        if(from != string.Empty)
        {
            EventHandler.CallBeforeSceneUnloaded();
            yield return SceneManager.UnloadSceneAsync(from);
        }
       
        yield return SceneManager.LoadSceneAsync(to,LoadSceneMode.Additive);


        Scene newScene = SceneManager.GetSceneByName(to);
        SceneManager.SetActiveScene(newScene);
        EventHandler.CallAfterSceneLoaded();
        yield return Fade(0);
    }
    /// <summary>
    /// 1 stands for black and 0 stands for  transparant
    /// </summary>
    /// <param name="targetAlpha"></param>
    /// <returns></returns>
    private IEnumerator Fade (float targetAlpha)
    {
        isFade = true;
        fadeCanvasGroup.blocksRaycasts = true;
        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;
        while (!Mathf.Approximately(fadeCanvasGroup.alpha ,targetAlpha)) {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
            yield return null;

        }
        fadeCanvasGroup.blocksRaycasts = false;

        isFade = false;

    }
}

