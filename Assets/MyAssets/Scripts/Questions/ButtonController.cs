using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public bool isCorrectAnswer;
    // Start is called before the first frame update
    void Awake()
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }


    public void SetButtonData(string text, bool _isCorrectAnswer)
    {
        textMesh.text = text;
        isCorrectAnswer = _isCorrectAnswer;
    }
}
