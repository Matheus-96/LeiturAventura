using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdatePoints : MonoBehaviour
{
    GameManagerSO m_GameManagerSO;
    TextMeshProUGUI m_TextMeshProUGUI;
    private void Awake()
    {
        m_TextMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
        m_GameManagerSO = Resources.Load<GameManagerSO>("General/GameManager");
        m_GameManagerSO.OnCollectPoint += UpdatePointsHandler;
        m_TextMeshProUGUI.text = m_GameManagerSO.Points.ToString();
    }

    private void UpdatePointsHandler()
    {
        m_TextMeshProUGUI.text = m_GameManagerSO.Points.ToString();
    }


}
