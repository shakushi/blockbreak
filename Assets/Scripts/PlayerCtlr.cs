using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtlr : MonoBehaviour
{
    [SerializeField]
    public float PlayerSpeed = 1.5f;

    private float PlayerWise = 3.5f;
    private float resolutionX;
    private float fieldSize = 14f;

    private float widthChgPN = 1.5f;
    private float changeWidthTime = 5f;

    private class PlayerInput
    {
        public float MoveDist { get; private set; }
        public PlayerInput(float moveDist)
        {
            MoveDist = moveDist;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        ChangeScale();

        //set resolution
        resolutionX = Screen.width;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHolizon(GetInput());
        ChangeWidth();
        ChangeScale();
    }

    private void ChangeScale()
    {
        //set scale
        Vector3 scale = Vector3.one;
        scale.x = PlayerWise;
        this.transform.localScale = scale;
    }

    private PlayerInput GetInput()
    {
        float value = 0;
        if (Input.GetMouseButton(0))
        {
            value += PlayerSpeed;
            if (Input.mousePosition.x <= resolutionX / 2)
            {
                value *= -1.0f;
            }
        }
        return new PlayerInput(value);
    }
    private void MoveHolizon(PlayerInput input)
    {
        Vector3 movedPos = this.transform.position;
        movedPos.x += input.MoveDist * Time.fixedDeltaTime;
        float movelimit = (fieldSize - PlayerWise) / 2;
        if (movedPos.x > movelimit)
        {
            movedPos.x = movelimit;
        }
        else if (movedPos.x < -movelimit)
        {
            movedPos.x = -movelimit;
        }

        this.transform.position = movedPos;
    }

    private void ChangeWidth()
    {
        if (changeWidthTime >= 1.5f)
        {
            changeWidthTime = 0;
            widthChgPN *= -1.0f;
        }
        else
        {
            PlayerWise += 1.0f * Time.deltaTime * widthChgPN;
            changeWidthTime += Time.deltaTime;
        }
    }
}
