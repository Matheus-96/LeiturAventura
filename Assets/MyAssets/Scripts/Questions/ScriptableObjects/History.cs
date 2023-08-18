using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hist�ria", menuName = "Hist�ria")]
public class History : ScriptableObject
{
    [Header(header: "Dados da hist�ria")]
    
    [SerializeField]
    private string titulo;

    [SerializeField]
    private string genero;

    [SerializeField]
    private Page paginas;

}
