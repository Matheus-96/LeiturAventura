using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

public class QuestionController : MonoBehaviour
{
    public Page page;
    public List<Question> questionList;
    public GameObject statementUI;
    public GameObject[] buttonsUI;
    public BalloonController balloonController;


    // Start is called before the first frame update
    void Start()
    {
        questionList = page.GetQuestions();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //StartCoroutine(GetQuestionsFromLevel());
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            ShowRandomQuestionOnScreen();
        }
    }

    public void ShowRandomQuestionOnScreen()
    {
        int questionIndex = Random.Range(0, questionList.Count);
        var _question = questionList[questionIndex];
        statementUI.GetComponent<TextMeshProUGUI>().text = _question.Enunciado;

        if (_question is QuestionText questionText)
        {
            FillTextAnswers(questionText);
        }
        else if (_question is QuestionImage questionImage)
        {
            FillImageAnswers(questionImage);
        }
    }

    private void FillTextAnswers(QuestionText question)
    {
        int index = 0;
        foreach (GameObject button in buttonsUI)
        {
            bool isCorrect = index == question.respostaCorreta;
            button.GetComponent<ButtonController>().SetButtonText(question.respostas[index], isCorrect);
            index++;
        }
    }

    private void FillImageAnswers(QuestionImage questionImage)
    {
        int index = 0;
        foreach (GameObject button in buttonsUI)
        {
            bool isCorrect = index == questionImage.respostaCorreta;
            button.GetComponent<ButtonController>().SetButtonImage(questionImage.respostas[index], isCorrect);
            index++;
        }
    }


    /*
    IEnumerator GetQuestionsFromLevel()
    {
        using(UnityWebRequest request = UnityWebRequest.Get("https://run.mocky.io/v3/0e6908ed-7175-4d67-b433-a03172be0da8"))
        {
            yield return request.SendWebRequest();

            if(request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error");
            } else
            {
                var text = request.downloadHandler.text;
                Questions.Clear();
                Questions = JsonConvert.DeserializeObject<List<Question>>(text);
            }
        }
    }
    */
}
