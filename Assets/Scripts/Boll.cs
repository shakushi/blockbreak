using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boll : MonoBehaviour
{
    [SerializeField]
    public float accerarate = 1.2f;
    [SerializeField]
    public float maxSpeed = 2.0f;

    private Vector3 moveDir;
    private bool onGame = false;

    public float MoveSpeed
    {
        get { return moveDir.magnitude; }
    }

    public bool OnGame
    {
        set { onGame = value; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        moveDir = new Vector3(1.0f, 0, 1.0f) * maxSpeed * 0.8f;
    }       

    // Update is called once per frame
    void Update()
    {
        if (!onGame)
        {
            return;
        }
        MovewithVel();
        if (!Mathf.Approximately(this.transform.position.y, 0.5f))
        {
            Vector3 modifyPos = this.transform.position;
            modifyPos.y = 0.5f;
            this.transform.position = modifyPos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("background"))
        {
            return;
        }
        Vector3 n = Vector3.zero;
        n = collision.contacts[0].normal;
        moveDir = specularRef(moveDir, n.normalized);
        moveDir *= 0.90f;
    }

    private void MovewithVel()
    {
        Vector3 acceraDir = moveDir * accerarate;
        if (acceraDir.magnitude <= maxSpeed)
        {
            moveDir = acceraDir;
        }
        else
        {
            moveDir = moveDir.normalized * maxSpeed;
        }

        Vector3 movedPos = this.transform.position;
        movedPos += moveDir * Time.deltaTime;
        this.transform.position = movedPos;
    }

    //https://qiita.com/edo_m18/items/b145f2f5d2d05f0f29c9
    //鏡面反射 : R=F+2(−F⋅N)N
    private Vector3 specularRef(Vector3 enter, Vector3 n)
    {
        return enter + 2 * Vector3.Dot(-enter, n) * n;
    }
}
