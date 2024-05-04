using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public int scoreCount = 0;
    public GameObject score;
    public Rigidbody2D rb;
    public Rigidbody2D gun;
    public Vector2 bulletDirection;
    public GameObject bullet;
    public GameObject Player;
    public float Force = 10.0f;
    public float offset = 0.6f;
    public GameObject bullet2;
    public GameObject deathScreen;



    void FixedUpdate()
    {
        Vector3 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newshoot = (MousePosition - new Vector3(rb.position.x,rb.position.y,0)).normalized;
        float angle = Mathf.Atan2(newshoot.y,newshoot.x) * Mathf.Rad2Deg - 90;
        gun.rotation = angle;
        gun.position = rb.position + new Vector2(newshoot.x,newshoot.y).normalized * offset;
        bulletDirection = newshoot;


        if (Input.anyKey /*&& !Input.GetKey(KeyCode.Mouse0)*/)
        {
            rb.velocity = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(0.0f, Force);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(0.0f, -Force);
            }
            if (Input.GetKey(KeyCode.A))
            {
                rb.velocity = new Vector2(-Force, 0.0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                rb.velocity = new Vector2(Force, 0.0f);
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(Force, Force).normalized * Force;
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(Force, -Force).normalized * Force;
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                rb.velocity = new Vector2(-Force, Force).normalized * Force;
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                rb.velocity = new Vector2(-Force, -Force).normalized * Force;
            }
        }
        else
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
    }
    private void Update()
    {
        bullet.GetComponent<Rigidbody2D>().position = gun.position;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            bullet2 = Instantiate(bullet, rb.position, Quaternion.identity);
            bullet2.GetComponent<Rigidbody2D>().velocity = bulletDirection.normalized * 3f * Force;
            Destroy(bullet2,5f);
            if (bullet2.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
            {
                Destroy(bullet2);
            }
            


        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Enemy")
        {
            Destroy(bullet);
            deathScreen.SetActive(true);
            scoreCount -= 5;
            score.GetComponent<Text>().text = scoreCount.ToString();
            Player.GetComponent<EnemySpawner>().dead = true;
            Player.SetActive(false);
        }
    }

    public void updateScore()
    {
        scoreCount += 5;
        score.GetComponent<Text>().text = scoreCount.ToString();
    }

}
