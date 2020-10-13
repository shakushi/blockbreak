using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    private int score = 30;
    private IGameCtlr gameCtlr;
    private void Awake()
    {
        gameCtlr = GameObject.Find("GameCtlr").GetComponent<GameCtlr>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameCtlr.AddScore(score);
            gameCtlr.DecBlocks();
            Destroy(this.gameObject);
        }
    }
}
