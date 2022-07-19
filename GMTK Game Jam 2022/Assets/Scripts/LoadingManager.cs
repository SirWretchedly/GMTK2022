using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;
    public GameObject LoadingPanel;
    public GameObject LoadingWheel;
    private float MinLoadTime = 6;
    private float WheelSpeed = 2;
    private bool isLoading;

    public Image FadeImage;
    private float fadeTime = 0.2f;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        LoadingPanel.SetActive(false);
        FadeImage.gameObject.SetActive(false);
    }

    public void LoadScene() {
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine() {

        isLoading = true;

        FadeImage.gameObject.SetActive(true);
        FadeImage.canvasRenderer.SetAlpha(0);

        while(!fade(1)) {
            yield return null;
        }

        LoadingPanel.SetActive(true);
        StartCoroutine(SpinWheelRoutine());

        while(!fade(0)) {
            yield return null;
        }

        AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        float elapsed = 0f;

        while(!op.isDone){
            elapsed += Time.deltaTime;
            yield return null;
        }

        while(elapsed < MinLoadTime){
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        while(!fade(1)) {
            yield return null;
        }

        LoadingPanel.SetActive(false);

        while(!fade(0)) {
            yield return null;
        }
    }

    private bool fade(float target) {
        FadeImage.CrossFadeAlpha(target, fadeTime, true);
        if (Mathf.Abs(FadeImage.canvasRenderer.GetAlpha() - target) <= 0.05f) {
            FadeImage.canvasRenderer.SetAlpha(target);
            return true;
        }
        return false;
    }

    private IEnumerator SpinWheelRoutine() {
        while(isLoading) {
            LoadingWheel.transform.Rotate(0, 0, -WheelSpeed);
            yield return null;
        }
    }
}
