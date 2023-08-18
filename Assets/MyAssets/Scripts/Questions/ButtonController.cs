using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public Image imageUI;
    public bool isCorrectAnswer;
    public BalloonController balloonController;
    public QuestionController questionController;
    // Start is called before the first frame update
    public void SetButtonText(string text, bool _isCorrectAnswer)
    {
        textMesh.enabled = true;
        imageUI.enabled = false;
        textMesh.text = text;
        isCorrectAnswer = _isCorrectAnswer;
    }
    public void SetButtonImage(Sprite image, bool _isCorrectAnswer)
    {
        textMesh.enabled = false;
        imageUI.enabled = true;
        imageUI.sprite = image;
        isCorrectAnswer = _isCorrectAnswer;
    }
    public void Evaluate()
    {
        Debug.Log("teste");
        if(isCorrectAnswer)
        {
            questionController.DisableUI();

            if (imageUI.enabled)
                balloonController.SetImage(imageUI.sprite);
            /*
            else
                balloonController.SetText(textMesh.text);
            */
        }
        
    }
}
