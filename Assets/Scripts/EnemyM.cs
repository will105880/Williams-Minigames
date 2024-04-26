using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyM : MonoBehaviour
{
    public GameObject m_Enemy;
    public GameObject m_Player;
    public Rigidbody2D rb;
    public Rigidbody2D Player;
    public float Force = 5.0f;



    void FixedUpdate()
    {
        rb.velocity = new Vector2(Player.position.x-rb.position.x,Player.position.y-rb.position.y).normalized * Force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Enemy")
        {
            Destroy(m_Enemy);
            m_Player.GetComponent<PlayerMovement>().updateScore();
        }
    }
}
