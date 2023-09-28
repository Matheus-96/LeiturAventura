using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Story", menuName = "Questions/Story")]
public class History : ScriptableObject
{
    [Header(header: "Dados da história")]
    
    [SerializeField]
    private string titulo;

    [SerializeField]
    private string genero;

    [SerializeField]
    private Page paginas;

}
