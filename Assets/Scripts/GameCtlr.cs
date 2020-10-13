using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtlr : MonoBehaviour, IGameCtlr
{
    [SerializeField]
    public Boll boll;
    [SerializeField]
    public GameObject RestartButton;

    private bool onGame = true;
    private int blocknum = 30;
    private int score = 0;
    public void GameReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        boll.OnGame = false;
        onGame = false;
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);

        RestartButton.SetActive(true);
    }
    public void AddScore(int value)
    {
        score += value;
    }
    public int Score { get{ return score; } }

    public void DecBlocks()
    {
        blocknum--;
    }

    void Update()
    {
        if (blocknum <= 0 && onGame)
        {
            GameOver();
        }
    }

    void Start()
    {
        StartCoroutine("GameStart");
    }

    private IEnumerator GameStart()
    {
        yield return new WaitForSeconds(0.8f);
        boll.OnGame = true;
    }
}
