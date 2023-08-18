using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionImage", menuName = "Quest�es/Quest�o de imagem")]
public class QuestionImage : Question
{
    public List<Sprite> respostas = new();

    public int respostaCorreta;
}
