using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeCamera : MonoBehaviour
{
    private float fadeSpeed = 1f;
    [SerializeField]
    private Image overlay;

    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn(int sceneID)
    {
        overlay.gameObject.SetActive(true);
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            overlay.color = new Color(overlay.color.r, overlay.color.b, overlay.color.g, alpha);
            yield return null;
        }
        SceneManager.LoadScene(sceneID);
    }

    public IEnumerator FadeOut()
    {
        overlay.gameObject.SetActive(true);
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            overlay.color = new Color(overlay.color.r, overlay.color.b, overlay.color.g, alpha);
            yield return null;
        }
        if (alpha < 0)
        {
            overlay.gameObject.SetActive(false);
        }
    }
}
