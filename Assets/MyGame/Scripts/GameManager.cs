using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const int maxHit = 10;
    public GameObject target;
    public GameObject parentOfTargets;
    public GameObject objCounter;
    public GameObject wonObj;
    public GameObject shootSound;
    public GameObject textObj;
    public GameObject endSound;

    private Text textCounter;
    private int score;
    private bool won;
    private bool disableText;
    private bool startEndSound;

    void Start()
    {
        textCounter = objCounter.GetComponent<Text>();
        InvokeRepeating("Spawn", 1f, 2f);
        won = false;
        wonObj.SetActive(false);
    }

    //Spawn a target att a random position within a specified  x and y range.
    //Instatiate (make a concrete GameObject, i.e, a clone from the given prefab target) the
    //target as child of the parentOfTargets. In this case transform.localposition instead of
    //transform.position is imoirtant!!
    private void Spawn()
    {
        float randomX = Random.Range(-425, 430);
        float randomY = Random.Range(-249, 210);

        Vector2 random2DPosition = new Vector2(randomX, randomY);

        GameObject myTarget = Instantiate(target, parentOfTargets.transform);
        myTarget.transform.localPosition = random2DPosition;

        Debug.Log(random2DPosition);
    }

    void Update()
    {
        if (won == true)
        {
            CancelInvoke("Spawn");
            wonObj.SetActive(true);
        }
        else
        {
            Debug.Log(won);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse pressed");
            shootSound.GetComponent<AudioSource>().Play();
        }

        if (disableText == true)
        {
            CancelInvoke("Text disabled");
            textObj.SetActive(false);
        }

        else
        {
            Debug.Log(disableText);
        }

        
    }

    public void IncrementScore()
    {
        score++;
        Debug.Log("Increment ... " + score);
        textCounter.text = score.ToString();

        if (score == maxHit)
        {
            won = true;
        }

        if (score == maxHit)
        {
            disableText = true;
        }

        if (score == maxHit)
        {
            startEndSound = true;
        }

        if (startEndSound == true)
        {
            endSound.GetComponent<AudioSource>().Play();
        }
    }
    
        
        

    
}