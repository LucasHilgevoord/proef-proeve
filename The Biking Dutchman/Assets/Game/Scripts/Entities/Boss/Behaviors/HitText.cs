using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitText : MonoBehaviour
{
    [SerializeField]
    private TextMesh[] textM;

    private float fadeDelay = 1f;
    private float fadeSpeed = 0.5f;
    private float moveSpeed = 3f;
    private float destroyTime = 10f;
    private Vector3 offset = new Vector3(0, 5, 0);

    private void Start()
    {
        StartCoroutine(FadeOutText());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + offset, moveSpeed/1000);
        for (int i = 1; i < textM.Length; i++)
        {
            textM[i].color = new Color(textM[i].color.r, textM[i].color.g, textM[i].color.b, textM[0].color.a);
        }
    }

    public IEnumerator FadeOutText()
    {
        yield return new WaitForSeconds(fadeDelay);
        textM[0].color = new Color(textM[0].color.r, textM[0].color.g, textM[0].color.b, 1);
        while (textM[0].color.a > 0.0f)
        {
            textM[0].color = new Color(textM[0].color.r, textM[0].color.g, textM[0].color.b, textM[0].color.a - (Time.deltaTime / fadeSpeed));
            yield return null;
        }
        Destroy(gameObject);
    }
}
