using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

public class QuestionController : MonoBehaviour
{
    public List<Question> Questions = new List<Question>();
    public GameObject statementUI;
    public GameObject[] buttonsUI;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(GetQuestionsFromLevel());
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            ShowQuestionOnScreen(Random.Range(0, Questions.Count));
        }
    }

    public void ShowQuestionOnScreen(int questionIndex)
    {
        Question question = Questions[questionIndex];
        
        statementUI.GetComponent<TextMeshProUGUI>().text = question.statement;

        int index = 0;
        foreach (GameObject button in buttonsUI)
        {
            bool isCorrect = index == question.correctAnswer;
            Debug.Log(question.answers.Length);
            button.GetComponent<ButtonController>().SetButtonData(question.answers[index], isCorrect);
            index++;
        }
    }

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
}
