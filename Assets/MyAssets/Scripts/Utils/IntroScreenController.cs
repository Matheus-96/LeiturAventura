using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroScreenController : MonoBehaviour
{
    Image panel;
    TextMeshProUGUI text;
    public string textToShow;

    // Start is called before the first frame update
    void Start()
    {
        panel = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = textToShow;
        StartCoroutine(nameof(IntroRoutine));
    }

    public IEnumerator IntroRoutine()
    {
        yield return new WaitForSeconds(1.5f);

        while (panel.color.a > 0)
        {
            Color color = new Color(0, 0, 0, panel.color.a - 0.01f); ;
            panel.color = color;
            text.color = color;
            yield return new WaitForSeconds(0.01f);
        }

        Destroy(gameObject);
    }
}
