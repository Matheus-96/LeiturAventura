using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Text Question", menuName = "Questions/Question/Text Question")]
public class QuestionText : Question
{
    public List<string> respostas = new();

    public int respostaCorreta;
}
