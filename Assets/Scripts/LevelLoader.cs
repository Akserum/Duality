using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private GameObject loadPanel;
    [SerializeField] private TextMeshProUGUI loadText;
    [SerializeField] private Slider loadSlider;

    public void LoadLevel(string sceneName)
    {
        StartCoroutine(AsyncLoad(sceneName));
    }

    private IEnumerator AsyncLoad(string sceneName)
    {
        loadPanel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadSlider.value = progress;
            loadText.text = progress * 100f + "%";
            yield return null;
        }
    }
}
