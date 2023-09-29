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
        StartCoroutine(TweenColorImage(imageUI));
    }
    public void SetText(string text)
    {
        textUI.gameObject.SetActive(true);
        imageUI.gameObject.SetActive(false);

        textUI.color = new Color(0, 0, 0, 0);
        textUI.text = text;
        StartCoroutine(TweenColorText(textUI));
    }

    public IEnumerator TweenColorImage(SpriteRenderer sprite)
    {
        float alpha = 0f;
        while (alpha < 1f)
        {
            sprite.color = new Color(1, 1, 1, alpha);
            alpha += Time.deltaTime * 0.5f;
            yield return null;
        }
        yield return null;
    }
    public IEnumerator TweenColorText(TextMeshPro text)
    {
        float alpha = 0f;
        while (alpha < 1f)
        {
            text.color = new Color(0, 0, 0, alpha);
            alpha += Time.deltaTime * 0.5f;
            yield return null;
        }
        yield return null;
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LevelController.Instance.ShowQuestion();
            gameObject.SetActive(false);
        }
    }

    public void ShowBaloon()
    {
        gameObject.SetActive(true);
        LevelController.Instance.MarkCurrentStepAsDone();
    }
}
