using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Image Question", menuName = "Questions/Question/Image Question")]
public class QuestionImage : Question
{
    public List<Sprite> respostas = new();

    public int respostaCorreta;
}
