using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    private IGameCtlr gameCtlr;
    private void Awake()
    {
        gameCtlr = GameObject.Find("GameCtlr").GetComponent<GameCtlr>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameCtlr.GameOver();
        }
    }
}
