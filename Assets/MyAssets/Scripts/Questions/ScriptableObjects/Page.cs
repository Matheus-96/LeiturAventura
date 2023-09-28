using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "Page", menuName = "Questions/Book Page")]
public class Page : ScriptableObject
{
    [SerializeField]
    private string numeroDaPagina;
    public string NumeroDaPagina { get { return numeroDaPagina; } set { numeroDaPagina = value; } }

    [SerializeField]
    private List<Question> questions = new();

    public List<Question> GetQuestions()
    {
        return questions;
    }
    public void SetQuestion(Question question)
    {
        questions.Add(question);
    }


}
