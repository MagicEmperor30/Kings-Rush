using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] CanvasGroup menuCanvasGroup;
    [SerializeField] float transitionTime = 1f;

    public void StartButton()
    {
        StartCoroutine(TransitionToMainLevel());
    }

    private IEnumerator TransitionToMainLevel()
    {
        yield return StartCoroutine(FadeOut());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        float startAlpha = menuCanvasGroup.alpha;

        while (elapsedTime < transitionTime)
        {
            menuCanvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / transitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        menuCanvasGroup.alpha = 0f;
    }

    public void QuitButton()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
