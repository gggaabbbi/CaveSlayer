using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI lifeNumber;
    [SerializeField] private TextMeshProUGUI killText;
    [SerializeField] private TextMeshProUGUI killNumber;

    private int maxLife = 10;
    private int currentLife;
    private int kills = 0;

    [Header("UI")]
    [SerializeField] private GameObject killsText;
    [SerializeField] private GameObject killsNumber;
    [SerializeField] private GameObject lifesText;
    [SerializeField] private GameObject lifesNumber;
    [SerializeField] private GameObject gameOver;


    private void Awake()
    {
        instance = this;
        currentLife = maxLife;
        UpdatePlayerLife(currentLife);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(currentLife <= 0)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            killsText.SetActive(false);
            killsNumber.SetActive(false);
            lifesText.SetActive(false);
            lifesNumber.SetActive(false);
        }
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
