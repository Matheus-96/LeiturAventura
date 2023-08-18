using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionText", menuName = "Questões/Questão de texto")]
public class QuestionText : Question
{
    public List<string> respostas = new();

    public int respostaCorreta;
}
