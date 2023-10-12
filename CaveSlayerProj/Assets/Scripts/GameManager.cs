using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI lifeNumber;

    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private TextMeshProUGUI killNumber;

    private int maxLife = 3;
    private int currentLife;

    private int kills = 0;

    private void Awake()
    {
        instance = this;
        currentLife = maxLife;
        UpdatePlayerLife(currentLife);
    }


    public void PlayerLife()
    {
        currentLife--;
        UpdatePlayerLife(currentLife);
    }

    public void EnemyKills()
    {
        kills++;
        UpdateEnemyKills(kills);
    }

    public void UpdatePlayerLife(int currentLife)
    {
        lifeNumber.text = currentLife.ToString();
    }

    public void UpdateEnemyKills(int kills)
    {
        killNumber.text = kills.ToString();
    }
}
