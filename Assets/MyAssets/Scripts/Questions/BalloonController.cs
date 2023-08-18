using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public string text;
    public Sprite sprite;

    public SpriteRenderer imageUI;
    public TextMeshPro textUI;
    public void SetImage(Sprite image)
    {
        imageUI.gameObject.SetActive(true);
        textUI.gameObject.SetActive(false);

        imageUI.color = new Color(1, 1, 1, 0);
        imageUI.sprite = image;
        StartCoroutine(TweenColor());
    }

    public IEnumerator TweenColor()
    {
        float alpha = 0f;
        while (alpha < 1f)
        {
            imageUI.color = new Color(1, 1, 1, alpha);
            alpha += Time.deltaTime * 0.5f;
            yield return null;
        }
        yield return null;
    }
}
