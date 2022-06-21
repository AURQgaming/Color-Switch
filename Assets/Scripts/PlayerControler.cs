using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public float jumpHeight = 6f;
    public int score;
    public TextMeshProUGUI scoreText;

    public Rigidbody2D rigidbody;

    public  SpriteRenderer sr;
    public Color[] playerColors;
    public string currentColor;

    public GameObject[] obstracles;
    public Transform spawnPoint;


    void Start()
    {
        SetRandomeColor();

    }

    void Update()
    {
        if( Input.GetButtonDown("Jump") || Input.GetMouseButton(0) )
        {
            rigidbody.velocity = Vector2.up * jumpHeight;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "ColorChanger")
        {
            SetRandomeColor();
            SpawnObtracles();
            
            return;  
        }
        
        if(collision.tag != currentColor && collision.tag != "Star")
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if(collision.tag == "Star")
        {
            score++;
            scoreText.text = score.ToString();
            
        }
       
         
    }

   

    public void SetRandomeColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Blue";
                sr.color = playerColors[0];
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = playerColors[1];
                break;
            case 2:
                currentColor = "Pink";
                sr.color = playerColors[2];
                break;
            case 3:
                currentColor = "Purple";
                sr.color = playerColors[3];
                break;
            

        }
    }

    public void SpawnObtracles()
    {
        int num = Random.Range(0, 2);

        Instantiate(obstracles[num], new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z),Quaternion.identity);
    }
}