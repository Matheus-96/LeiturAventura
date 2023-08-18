using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question : ScriptableObject
{
    [Header(header: "Dados da hist�ria")]

    [SerializeField]
    private string enunciado;

    public string Enunciado { get { return enunciado; } set { enunciado = value; } }
}
