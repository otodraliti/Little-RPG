using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#region
[System.Serializable]
public class Letter
{
    public GameObject Button;

}
[System.Serializable]
public class Rows
{
    public GameObject Row;
    public Vector3 StartPose;
    public Vector3 StartScale;
    public List<Letter> Letters = new List<Letter>{new Letter(), new Letter(), new Letter() };
}

[System.Serializable]
public class EndPositions
{
    public Transform leftEndPose;
    public Transform rightEndPose;
    public Transform midChose;
    public Transform leftChose;
    public Transform rightChose;
}
#endregion


public class GameManager : MonoBehaviour
{
    //all Variables
    #region
    //main system
    public List<Rows> Rows;
    public EndPositions[] endPose;

    
    public Actions Action;


    // Set timers
   // public float SetChoseTimer;
    public float maxBreakTimer;


    // Set speed
    public float MoveSpeed;
    public float ScaleSpeed;
    public float ChoseResultSpeed;

    // other var
    private bool ChoseEnable;
    private bool AddRound;
    public int roundCounter;
    private int x;
    //public Sprite changeSprite;


    public List<GameObject> ActionPrefabs;
    public GameObject RowPrefab;

    // seted from sets
    private float BreakTimer;

    #endregion

    private void Start()
    {
        SetStartPosition();
        DoOnce();
    }

    private void Update()
    {
        Turns();
        if (isSpawnCompelte == false)
        {
            Spawner();
        }
    }

    //Turns
    #region
    private void Turns()
    {
        ChoseMaker();
        Inputs();
    }
    #endregion


    private void DoOnce()
    {
        ChoseEnable = true;
        maxBreakTimer = 1f;
        BreakTimer = maxBreakTimer;
        for (int i = 0; i < Rows.Count; i++)
        {
            int RandomPrefab = Random.Range(0, ActionPrefabs.Count);
            GameObject PrefabLeft = Instantiate(ActionPrefabs[RandomPrefab], Rows[i].Row.gameObject.transform.GetChild(0).transform.position, Quaternion.identity);

            RandomPrefab = Random.Range(0, ActionPrefabs.Count);
            GameObject PrefabMid = Instantiate(ActionPrefabs[RandomPrefab], Rows[i].Row.gameObject.transform.GetChild(1).transform.position, Quaternion.identity);

            RandomPrefab = Random.Range(0, ActionPrefabs.Count);
            GameObject PrefabRight = Instantiate(ActionPrefabs[RandomPrefab], Rows[i].Row.gameObject.transform.GetChild(2).transform.position, Quaternion.identity);

            PrefabLeft.transform.parent = Rows[i].Row.transform.GetChild(0).gameObject.transform;
            PrefabMid.transform.parent = Rows[i].Row.transform.GetChild(1).gameObject.transform;
            PrefabRight.transform.parent = Rows[i].Row.transform.GetChild(2).gameObject.transform;

            PrefabLeft.gameObject.transform.localScale = new Vector3(1, 1, 1);
            PrefabMid.gameObject.transform.localScale = new Vector3(1, 1, 1);
            PrefabRight.gameObject.transform.localScale = new Vector3(1, 1, 1);

            Rows[i].Letters[0].Button = Rows[i].Row.transform.GetChild(0).gameObject;
            Rows[i].Letters[1].Button = Rows[i].Row.transform.GetChild(1).gameObject;
            Rows[i].Letters[2].Button = Rows[i].Row.transform.GetChild(2).gameObject;
        }
    }
    public bool isSpawnCompelte = true;

    private void Spawner()
    {
        if (isSpawnCompelte == false)
        {
            Rows.Add(new Rows());
            GameObject InstRow = Instantiate(RowPrefab, new Vector3(0, 1.8f, 0), Quaternion.identity);
            Rows[3].Row = InstRow;
            Rows[3].StartPose = new Vector3(0, 1.8f, 0);
            Rows[3].StartScale = new Vector3(0.7f, 0.7f, 0.7f);
            Rows[3].Row.transform.position = Rows[3].StartPose;
            Rows[3].Row.transform.localScale = Rows[3].StartScale;

            int RandomPrefab = Random.Range(0, ActionPrefabs.Count);
            GameObject PrefabLeft = Instantiate(ActionPrefabs[RandomPrefab], Rows[3].Row.gameObject.transform.GetChild(0).transform.position, Quaternion.identity);
            PrefabLeft.transform.parent = Rows[3].Row.transform.GetChild(0).transform;
            PrefabLeft.gameObject.transform.localScale = new Vector3(1, 1, 1);
            Rows[3].Letters[0].Button = Rows[3].Row.transform.GetChild(0).gameObject;

            RandomPrefab = Random.Range(0, ActionPrefabs.Count);
            GameObject PrefabMid = Instantiate(ActionPrefabs[RandomPrefab], Rows[3].Row.gameObject.transform.GetChild(1).transform.position, Quaternion.identity);
            PrefabMid.transform.parent = Rows[3].Row.transform.GetChild(1).transform;
            PrefabMid.gameObject.transform.localScale = new Vector3(1, 1, 1);
            Rows[3].Letters[1].Button = Rows[3].Row.transform.GetChild(1).gameObject;

            RandomPrefab = Random.Range(0, ActionPrefabs.Count);
            GameObject PrefabRight = Instantiate(ActionPrefabs[RandomPrefab], Rows[3].Row.gameObject.transform.GetChild(2).transform.position, Quaternion.identity);
            PrefabRight.transform.parent = Rows[3].Row.transform.GetChild(2).transform;
            PrefabRight.gameObject.transform.localScale = new Vector3(1, 1, 1);
            Rows[3].Letters[2].Button = Rows[3].Row.transform.GetChild(2).gameObject;

            isSpawnCompelte = true;
        }
    }

    private void SetStartPosition()
    {
        for (int i = 0; i < Rows.Count; i++)
        {
            Rows[i].Row.transform.position = Rows[i].StartPose;
        }
    }

    #region
    private void Movement()
    {
        
        for (int i = Rows.Count -1; i > 0; i--)
        {
            for (int c = 0; c < Rows[1].Letters.Count; c++)
            {
                Rows[1].Letters[c].Button.GetComponent<BoxCollider>().enabled = true;
            }
            Vector2 targetTriggerPosition = Rows[i-1].StartPose;
            Vector2 thisTriggerPosition = Rows[i].Row.transform.position;

            Vector3 targetRowSize = Rows[i - 1].StartScale;
            Vector3 thisRowSize = Rows[i].Row.transform.localScale;

            Rows[i].Row.transform.position = Vector2.Lerp(thisTriggerPosition, targetTriggerPosition, MoveSpeed * Time.deltaTime);
            Rows[i].Row.transform.localScale = Vector2.Lerp(thisRowSize, targetRowSize, MoveSpeed * Time.deltaTime) ;
        }

    }
    #endregion


    //ChoseMaker region. Changing x value to get input effects;
    #region 
    private void ChoseMaker()
    {
        Vector3 LeftFalsePose = endPose[0].leftEndPose.transform.position;
        Vector3 RightFalsePose = endPose[0].rightEndPose.transform.position;

        Vector3 LeftChosePose = endPose[0].leftChose.transform.position;
        Vector3 MidChosePose = endPose[0].midChose.transform.position;
        Vector3 RightChosePose = endPose[0].rightChose.transform.position;

        switch (x)
        {
            case 0:
                {
                    // waiting to chose smth or delay
                    if (AddRound == true)
                    {
                        for (int i = Rows.Count -1; i > 0; i--)
                        {
                            Vector2 targetTriggerPosition = Rows[i - 1].StartPose;
                            Vector2 thisTriggerPosition = Rows[i].Row.transform.position;
                            Rows[i].Row.transform.position = targetTriggerPosition;
                            
                            Rows[i].StartPose = Rows[i-1].StartPose;

                            Vector3 targetRowSize = Rows[i - 1].StartScale;
                            Rows[i].Row.transform.localScale = targetRowSize;

                            Rows[i].StartScale = Rows[i - 1].StartScale;

                        }
                        Rows[0].Row.SetActive(false);
                        Destroy(Rows[0].Row);
                        Rows.Remove(Rows[0]);
                        //isSpawnCompelte = false;
                        isSpawnCompelte = false;
                        ChoseEnable = true;
                        AddRound = false;
                    }
                    return;
                }
            case 1:
                {
                    //left chosen
                    if (maxBreakTimer >= 0)
                    {
                        BreakTimer -= Time.deltaTime;
                    }
                    Movement();
                    
                    Vector3 LeftLetterPose = Rows[0].Letters[0].Button.transform.position;
                    Vector3 MidLetterPose = Rows[0].Letters[1].Button.transform.position;
                    Vector3 RightLetterPose = Rows[0].Letters[2].Button.transform.position;

                    Rows[0].Letters[0].Button.transform.position = Vector3.Lerp(LeftLetterPose, LeftChosePose, ChoseResultSpeed * Time.deltaTime);
                    Rows[0].Letters[1].Button.transform.position = Vector3.Lerp(MidLetterPose, RightFalsePose, ChoseResultSpeed * Time.deltaTime);
                    Rows[0].Letters[2].Button.transform.position = Vector3.Lerp(RightLetterPose, RightFalsePose, ChoseResultSpeed * Time.deltaTime);

                    if (BreakTimer < 0)
                    {
                        BreakTimer = maxBreakTimer;
                        AddRound = true;
                        x = 0;
                        break;
                    }
                    return;
                }
            case 2:
                {
                    //Mid chosen
                    if (maxBreakTimer >= 0)
                    {
                        BreakTimer -= Time.deltaTime;
                    }

                    Movement();
                    Vector3 LeftLetterPose = Rows[0].Letters[0].Button.transform.position;
                    Vector3 MidLetterPose = Rows[0].Letters[1].Button.transform.position;
                    Vector3 RightLetterPose = Rows[0].Letters[2].Button.transform.position;

                    Rows[0].Letters[0].Button.transform.position = Vector3.Lerp(LeftLetterPose, LeftFalsePose, ChoseResultSpeed * Time.deltaTime);
                    Rows[0].Letters[1].Button.transform.position = Vector3.Lerp(MidLetterPose, MidChosePose, ChoseResultSpeed * Time.deltaTime);
                    Rows[0].Letters[2].Button.transform.position = Vector3.Lerp(RightLetterPose, RightFalsePose, ChoseResultSpeed * Time.deltaTime);
                    if (BreakTimer < 0)
                    {
                        BreakTimer = maxBreakTimer;
                        AddRound = true;
                        x = 0;
                        break;
                    }

                    return;
                }
            case 3:
                {
                    //right Chosen
                    if (maxBreakTimer >= 0)
                    {
                        BreakTimer -= Time.deltaTime;
                    }

                    Movement();
                    Vector3 LeftLetterPose = Rows[0].Letters[0].Button.transform.position;
                    Vector3 MidLetterPose = Rows[0].Letters[1].Button.transform.position;
                    Vector3 RightLetterPose = Rows[0].Letters[2].Button.transform.position;

                    Rows[0].Letters[0].Button.transform.position = Vector3.Lerp(LeftLetterPose, LeftFalsePose, ChoseResultSpeed * Time.deltaTime);
                    Rows[0].Letters[1].Button.transform.position = Vector3.Lerp(MidLetterPose, LeftFalsePose, ChoseResultSpeed * Time.deltaTime);
                    Rows[0].Letters[2].Button.transform.position = Vector3.Lerp(RightLetterPose, RightChosePose, ChoseResultSpeed * Time.deltaTime);
                    if (BreakTimer < 0)
                    {
                        BreakTimer = maxBreakTimer;
                        AddRound = true;
                        x = 0;
                        break;
                    }

                    return;
                }
        }
    }
    #endregion

    //Inputs for PC and Mobile (check before build)
    #region
    private void Inputs()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if (ChoseEnable == true)
                {
                    if (bc != null)
                    {
                        if (bc.gameObject.tag == "Left")
                        {
                            x = 1;
                            if (bc.gameObject.transform.GetChild(0).tag == "Sword")
                            {
                                Action.PlayerAtack();
                            }
                            if (bc.gameObject.transform.GetChild(0).tag == "Shield")
                            {
                                Action.PlayerDef();
                            }
                            if (bc.gameObject.transform.GetChild(0).tag == "Healing")
                            {
                                Action.PlayerHealing();
                            }
                            ChoseEnable = false;
                        }
                        if (bc.gameObject.tag == "Mid")
                        {
                            x = 2;
                            if (bc.gameObject.transform.GetChild(0).tag == "Sword")
                            {
                                Action.PlayerAtack();
                            }
                            if (bc.gameObject.transform.GetChild(0).tag == "Shield")
                            {
                                Action.PlayerDef();
                            }
                            if (bc.gameObject.transform.GetChild(0).tag == "Healing")
                            {
                                Action.PlayerHealing();
                            }
                            ChoseEnable = false;
                        }
                        if (bc.gameObject.tag == "Right")
                        {
                            x = 3;
                            if (bc.gameObject.transform.GetChild(0).tag == "Sword")
                            {
                                Action.PlayerAtack();
                            }
                            if (bc.gameObject.transform.GetChild(0).tag == "Shield")
                            {
                                Action.PlayerDef();
                            }
                            if (bc.gameObject.transform.GetChild(0).tag == "Healing")
                            {
                                Action.PlayerHealing();
                            }
                            ChoseEnable = false;
                        }
                        
                    }
                }

            }
        }


        // trun on Mobile version

        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    switch (touch.phase)
        //    {
        //        // Record initial touch position.
        //        case TouchPhase.Began:
        //            {
        //                RaycastHit hit;
        //                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //                if (Physics.Raycast(ray, out hit))
        //                {
        //                    BoxCollider bc = hit.collider as BoxCollider;
        //                    if (ChoseEnable == true)
        //                    {
        //                        if (bc != null)
        //                        {
        //                            if (bc.gameObject.tag == "Left")
        //                            {
        //                                Debug.Log("Left");
        //                                Word = Word + bc.gameObject.name;
        //                                ChoseTimer = 0;
        //                                x = 1;
        //                                ChoseEnable = false;
        //                                break;
        //                            }
        //                            if (bc.gameObject.tag == "Mid")
        //                            {
        //                                Debug.Log("Mid");
        //                                Word = Word + bc.gameObject.name;
        //                                ChoseTimer = 0;
        //                                x = 2;
        //                                ChoseEnable = false;
        //                                break;
        //                            }
        //                            if (bc.gameObject.tag == "Right")
        //                            {
        //                                Debug.Log("Right");
        //                                Word = Word + bc.gameObject.name;
        //                                ChoseTimer = 0;
        //                                x = 3;
        //                                ChoseEnable = false;
        //                                break;
        //                            }
        //                            ChoseEnable = false;
        //                        }
        //                    }

        //                }
        //                break;
        //            }
        //    }
        //}
    }
    #endregion
}
