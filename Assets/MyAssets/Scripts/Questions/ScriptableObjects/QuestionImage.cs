using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionImage", menuName = "Questões/Questão de imagem")]
public class QuestionImage : Question
{
    public List<Sprite> respostas = new();

    public int respostaCorreta;
}
