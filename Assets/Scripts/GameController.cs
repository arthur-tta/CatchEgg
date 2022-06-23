using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject egg;
    public float spawnTime;
    public Chicken chicken1;
    public Chicken chicken2;
    public Chicken chicken3;

    List<Chicken> listChicken = new List<Chicken>(3);
    float m_spawnTime;
    int m_score;
    int m_health = 3;
    bool m_isGameOver;
    UI m_ui;

    // Start is called before the first frame update
    private void Awake()
    {
        listChicken.Add(chicken1);
        listChicken.Add(chicken2);
        listChicken.Add(chicken3);
    }

    void Start()
    {
        m_spawnTime = 0;
        m_ui = FindObjectOfType<UI>();
        m_ui.SetScoreText("Score: " + m_score);
        m_ui.SetHealthText("Health: " + m_health);
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTime -= Time.deltaTime;

        if (m_isGameOver)
        {
            m_spawnTime = 0;
            m_ui.ShowGameOverPanel(true);
            return;
        }
        if (m_spawnTime <= 0)
        {
            SpawnEgg();
            m_spawnTime = spawnTime;
        }
    }

    public void Replay()
    {
        m_score = 0;
        m_health = 3;
        m_isGameOver = false;
        m_ui.SetScoreText("Score: " + m_score);
        m_ui.SetHealthText("Health: " + m_health);
        m_ui.ShowGameOverPanel(false);

    }

    private Chicken randomChicken()
    {
        int i = Random.Range(0, 3);
        return listChicken[i];
    }

    public void SpawnEgg()
    {
        Chicken c = randomChicken();
        float x = c.GetSpawnx();
        float y = c.GetSpawny() - 0.2f;
        Vector2 spawnPos = new Vector2(x, y);
        if (egg)
        {
            Instantiate(egg, spawnPos, Quaternion.identity);
        }
    }


    public void SetScore(int value)
    {
        m_score = value;
    }

    public int GetScore()
    {
        return m_score;
    }

    public void IncrementScore()
    {
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }

    public int GetHealth()
    {
        return m_health;
    }

    public void SubHealth()
    {
        m_health--;
        m_ui.SetHealthText("Health: " + m_health);
    }

    public bool IsGameOver()
    {
        return m_isGameOver;
    }
    public void SetGameState(bool state)
    {
        m_isGameOver = state;
    }
}
