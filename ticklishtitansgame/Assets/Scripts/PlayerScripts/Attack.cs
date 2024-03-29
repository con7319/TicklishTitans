using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Attack : MonoBehaviour
{   
    public Image windUpBar;
    public TextMeshProUGUI jokeText;
    [SerializeField]public GameObject jokeCanvas;
    public float displayTime = 10.0f;
    ArrayList jokesListArray = new ArrayList();
    private GameObject tickleArea = default;
    public TickleArea tickleAreaScript;
    public EnemyMovement enemyMovementScript;
    private bool canAttack = true;
    private bool isAttacking = false;
    private float attackCooldown = 2.5f;
    private float windTime = 0f;
    private bool tickling = false;
    private int TickleDamage;
    private int level = 0;
    public GameObject Bullet;
    public float initialVelocity;
    public Animator animator;

    void Start()
    {
        tickleArea = transform.GetChild(0).gameObject;
        jokeCanvas.SetActive(false);
        string filePath = Path.Combine(Application.streamingAssetsPath, "jokeslist.csv");
        
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    jokesListArray.Add(line); // Adding each line to the ArrayList
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
    }

    private void Update()
    {
        if (canAttack && Input.GetMouseButton(0))
        {
            if (tickleAreaScript.inCollider && GameManager.Instance.isAttacking)
            {
                isAttacking = true;
                Tickle();
                
            }
        }

        if (tickling)
        {
            tickleArea.SetActive(tickling);
        }

        // Check if the attack input has been released
        if (isAttacking && !Input.GetMouseButton(0))
        {
            isAttacking = false;
            animator.SetBool("isJoking", false);
        }

        if (GameManager.Instance.isAttacking && Input.GetMouseButtonDown(1))
        {
            Joke();
        }

        if(GameManager.Instance.isAttacking && Input.GetMouseButtonUp(0))
        {
            SetWindTimeToZero();
        }

        FillBar(windTime);
    }

    private void Tickle()
    {
        if (canAttack)
        {

            windTime += Time.deltaTime;
        
            if(windTime == 0)
            {
                Debug.Log("This shouldnt be seen");
                level = 0;
            }
            else if(windTime > 1 && windTime < 2)
            {
                Debug.Log("Level 1");
                level = 1;
            }
            else if(windTime > 2 && windTime < 3)
            {
                Debug.Log("Level 2");
                level = 2;
            }
            else if(windTime > 3 && windTime < 4)
            {
                Debug.Log("Level 3");
                level = 3;
            }
        }
    }
    private IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    
    private void Joke()
    {
        if(enemyMovementScript.isJokeBlocking)
        {
            Debug.Log("Block");
        }
        else
        {
            Debug.Log("choosing joke");
            
            int randomInt = UnityEngine.Random.Range(0, jokesListArray.Count);

            if (randomInt >= 0 && randomInt < jokesListArray.Count)
                {
                var line = jokesListArray[randomInt]; 
                
                Debug.Log("joke chosen:");
                Debug.Log(line);
                
                jokeText.text = line.ToString();
                StartCoroutine(ShowAndHideCanvas(displayTime));
                }

            var projectileInstance = GameObject.Instantiate(Bullet, GameObject.Find("TicklePoint").transform.position, Quaternion.identity);
            projectileInstance.GetComponent<Rigidbody>().velocity = initialVelocity * this.transform.forward;
        }

        
    }
    private IEnumerator ShowAndHideCanvas(float time)
    {
        //Show the canvas
        jokeCanvas.SetActive(true);
        GameManager.Instance.isAttacking = false;
        // Wait for the specified time
        yield return new WaitForSeconds(time);

        // Hide the canvas
        GameManager.Instance.isAttacking = true;
        jokeCanvas.SetActive(false);
    }

    private void SetWindTimeToZero()
    {
        windTime = 0;

        switch(level)
        {
            case 0:
                Debug.Log("Nothing");
                level = 0;
                break;
            case 1:
                Debug.Log("1");
                Level1();
                level = 0;
                break;
            case 2:
                Debug.Log("2");
                Level2();
                level = 0;
                break;
            case 3:
                Debug.Log("3");
                Level3();
                level = 0;
                break;
        }
    }

    private void Level1()
    {
        if(enemyMovementScript.isTickleBlocking)
        {
            Debug.Log("Block");
        }
        else
        {
            animator.SetBool("isJoking", true);
            canAttack = false;
            TickleDamage = 5; // Set TickleDamage here if you want to reset it every time Tickle is called
            Debug.Log("Tickle");
            tickleAreaScript.HahaTime(TickleDamage);

            // Add animation code
            // Make this do something

            tickleArea.SetActive(true);

            tickling = true;

            StartCoroutine(AttackCooldown());
        }
    }

    private void Level2()
    {
        if(enemyMovementScript.isTickleBlocking)
        {
            Debug.Log("Block");
        }
        else
        {
            animator.SetBool("isJoking", true);
            canAttack = false;
            TickleDamage = 10; // Set TickleDamage here if you want to reset it every time Tickle is called
            Debug.Log("Tickle");
            tickleAreaScript.HahaTime(TickleDamage);

            // Add animation code
            // Make this do something

            tickleArea.SetActive(true);

            tickling = true;

            StartCoroutine(AttackCooldown());
        }

        StartCoroutine(AttackCooldown());
    }

    private void Level3()
    {
        if(enemyMovementScript.isTickleBlocking)
        {
            Debug.Log("Block");
        }
        else
        {
            animator.SetBool("isJoking", true);
            canAttack = false;
            TickleDamage = 15; // Set TickleDamage here if you want to reset it every time Tickle is called
            Debug.Log("Tickle");
            tickleAreaScript.HahaTime(TickleDamage);

            // Add animation code
            // Make this do something

            tickleArea.SetActive(true);

            tickling = true;

            StartCoroutine(AttackCooldown());
        }
    }

    public void FillBar(float fillValue)
    {
        float amount = (fillValue / 2f) * 180f/360;
        windUpBar.fillAmount = amount;
        
    }
}