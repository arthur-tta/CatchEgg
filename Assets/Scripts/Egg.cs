using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    GameController m_gc;
    

    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("deathzone"))
        {
            
            Destroy(gameObject);
            m_gc.SubHealth();
            if(m_gc.GetHealth() == 0)
            {
                m_gc.SetGameState(true);
            }
            
        }
        else if (collision.CompareTag("Player"))
        {
            m_gc.IncrementScore();
            Destroy(gameObject);
        }
    }

    
}
