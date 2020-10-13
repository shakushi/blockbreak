using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItext : MonoBehaviour
{
    [SerializeField]
    public Boll boll;
    [SerializeField]
    public Text SpeedUI;

    // Update is called once per frame
    void Update()
    {
        float speed = boll.MoveSpeed;
        SpeedUI.text = "speed:" + speed.ToString();
    }
}
