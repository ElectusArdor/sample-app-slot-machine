using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public GameObject spinBtn;
    private GameObject fruit;
    public bool move, stopMoveBack, toPosition;
    private float speedCoef, tmr;
    private string oppFruit;
    Vector3 target;

    void Start()
    {
        move = false;
        stopMoveBack = false;
        toPosition = false;

        tmr = 0.2f;

        spinBtn = Camera.main.GetComponent<GameObjectsList>().spinBtn;

        fruit = Instantiate(Camera.main.GetComponent<GameObjectsList>().fruits[Random.Range(0, 8)]);
        fruit.transform.SetParent(transform, false);

        if (name.Substring(7) == "1")
            GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        oppFruit = coll.gameObject.transform.GetChild(0).name;
    }

    private void Move()
    {
        if (move && !stopMoveBack)
        {
            speedCoef = (tmr - 0.2f) * (0.9f - tmr) * 400f;
            tmr += Time.deltaTime;

            if (name.Substring(7) == "1")
                transform.localPosition = new Vector3(transform.localPosition.x - Time.deltaTime * speedCoef, transform.localPosition.y, transform.localPosition.z);
            else
                transform.localPosition = new Vector3(transform.localPosition.x + Time.deltaTime * speedCoef, transform.localPosition.y, transform.localPosition.z);

            if (tmr >= 0.9f)
            {
                stopMoveBack = true;
                tmr = 0.5f;
            }
        }
        else if (move && !toPosition)
        {
            speedCoef = (tmr - 0.5f) * (3f - tmr) * 1600f;
            tmr += Time.deltaTime;

            if (name.Substring(7) == "1")
                transform.localPosition = new Vector3(transform.localPosition.x + Time.deltaTime * speedCoef, transform.localPosition.y, transform.localPosition.z);
            else
                transform.localPosition = new Vector3(transform.localPosition.x - Time.deltaTime * speedCoef, transform.localPosition.y, transform.localPosition.z);

            if (tmr >= 2.8f)
            {
                toPosition = true;
                tmr = 1f;
            }
        }
        else if (toPosition)
        {
            if (name.Substring(7) == "1")
            {
                if (transform.localPosition.x <= -720f)
                    target = new Vector3(-720f, transform.localPosition.y, transform.localPosition.z);
                else if (transform.localPosition.x <= -360f)
                    target = new Vector3(-360f, transform.localPosition.y, transform.localPosition.z);
                else if (transform.localPosition.x <= 0f)
                    target = new Vector3(0f, transform.localPosition.y, transform.localPosition.z);
                else if (transform.localPosition.x <= 360f)
                    target = new Vector3(360f, transform.localPosition.y, transform.localPosition.z);
                else if (transform.localPosition.x <= 720f)
                    target = new Vector3(720f, transform.localPosition.y, transform.localPosition.z);
                else
                    target = new Vector3(1080f, transform.localPosition.y, transform.localPosition.z);
            }
            else
            {
                if (transform.localPosition.x >= 720f)
                    target = new Vector3(720f, transform.localPosition.y, transform.localPosition.z);
                else if (transform.localPosition.x >= 360f)
                    target = new Vector3(360f, transform.localPosition.y, transform.localPosition.z);
                else if (transform.localPosition.x >= 0f)
                    target = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
                else if (transform.localPosition.x >= -360f)
                    target = new Vector3(-360f, transform.localPosition.y, transform.localPosition.z);
                else if (transform.localPosition.x >= -720f)
                    target = new Vector3(-720f, transform.localPosition.y, transform.localPosition.z);
                else
                    target = new Vector3(-1080f, transform.localPosition.y, transform.localPosition.z);
            }

            if (name.Substring(7) == "1")
            {
                transform.localPosition = new Vector3(transform.localPosition.x + 5f * Time.deltaTime * (10f + target.x - transform.localPosition.x), transform.localPosition.y, transform.localPosition.z);
                if (transform.localPosition.x >= target.x)
                {
                    StopMove();
                    if (oppFruit == transform.GetChild(0).name && transform.localPosition.x > -400f && transform.localPosition.x < 400f)
                        Main.score += Camera.main.GetComponent<GameObjectsList>().bid * 2;
                }
            }
            else
            {
                transform.localPosition = new Vector3(transform.localPosition.x - 5f * Time.deltaTime * (10f + transform.localPosition.x - target.x), transform.localPosition.y, transform.localPosition.z);
                if (transform.localPosition.x <= target.x)
                {
                    StopMove();
                }
            }
        }
    }

    private void OverJump()
    {
        if (transform.localPosition.x >= 1080f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x - 1800f, transform.localPosition.y, transform.localPosition.z);
        }
        else if (transform.localPosition.x <= -1080f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x + 1800f, transform.localPosition.y, transform.localPosition.z);
            Destroy(fruit);

            fruit = Instantiate(Camera.main.GetComponent<GameObjectsList>().fruits[Random.Range(0, 8)]);
            fruit.transform.SetParent(transform, false);
        }
    }

    private void StopMove()
    {
        spinBtn.GetComponent<Spin>().move = false;
        move = false;
        stopMoveBack = false;
        toPosition = false;
        tmr = 0.2f;
        transform.localPosition = target;
    }

    void Update()
    {
        move = spinBtn.GetComponent<Spin>().move;

        Move();

        OverJump();
    }
}
