using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScreenController : MonoBehaviour
{
    Image panel;
    TextMeshProUGUI text;
    public string textToShow;
    public UnityEvent onIntroEnd, onEndingEnd, onEndingDeath;
    // Start is called before the first frame update
    void Start()
    {
        panel = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = textToShow;
        StartCoroutine(nameof(IntroRoutine));
    }

    public void EndScene()
    {
        StartCoroutine(nameof(EndRoutine));
    }
    public void EndSceneDeath()
    {
        StartCoroutine(nameof(EndRoutineDeath));
    }

    public IEnumerator IntroRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        onIntroEnd?.Invoke();

        while (panel.color.a > 0)
        {
            Color color = new Color(0, 0, 0, panel.color.a - 0.05f); ;
            panel.color = color;
            text.color = color;
            yield return new WaitForSeconds(0.001f);
        }
    }

    public IEnumerator EndRoutine()
    {
        while (panel.color.a < 1)
        {
            Color color = new Color(0, 0, 0, panel.color.a + 0.025f); ;
            panel.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        onEndingEnd?.Invoke();
    }
    public IEnumerator EndRoutineDeath()
    {
        while (panel.color.a < 1)
        {
            Color color = new Color(0, 0, 0, panel.color.a + 0.01f); ;
            panel.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        onEndingDeath?.Invoke();
    }

    
}
