using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;
    
    public int maxHealth = 5; 
    public float timeInvincible = 2;
    public int health { get { return currentHealth; } }
    int currentHealth;

    bool isInvincible;
    float invincibleTimer;


    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if(invincibleTimer < 0 )
            {
                isInvincible = false;
            }
        }

    }
    private void FixedUpdate()
    {
        Vector2 positon = rigidbody2d.position;
        positon.x = positon.x + 3.0f * horizontal * Time.deltaTime;
        positon.y = positon.y + 3.0f * vertical * Time.deltaTime; ;

        rigidbody2d.MovePosition(positon);
    }
    public void ChangeHealth(int amount)
    { 
        if(amount < 0)
        {
            if(isInvincible)
            {
                return;
            }
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

}

