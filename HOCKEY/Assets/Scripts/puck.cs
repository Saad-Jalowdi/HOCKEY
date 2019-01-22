using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puck : MonoBehaviour {

    public ScoreManager ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    public float MaxSpeed;
    float timeleft=3; 
    

    private Rigidbody2D rb;
    public Rigidbody2D AIrb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        WasGoal = false;
    }
    private void Update()
    {
        if (rb.velocity == new Vector2(0,0)&& AIrb.velocity == new Vector2(0, 0))
        {
            timeleft -= Time.deltaTime;
            if (timeleft<0)
            {
                rb.position = new Vector2(0,0);
                timeleft = 3;
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!WasGoal)
        {
            if (other.tag == "AiGoal")
            {
                ScoreScriptInstance.Increment(ScoreManager.Score.PlayerScore);
                WasGoal = true;
                AudioManger.ins.PlayGoal();
                StartCoroutine(ResetPuck(false));
            }
            else if (other.tag == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreManager.Score.AiScore);
                WasGoal = true;
                AudioManger.ins.PlayGoal();
                StartCoroutine(ResetPuck(true));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManger.ins.PlayPuckCollision();
    }

    private IEnumerator ResetPuck(bool didAiScore)
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = rb.position = new Vector2(0, 0);

        if (didAiScore)
            rb.position = new Vector2(0, -1);
        else
            rb.position = new Vector2(0, 1);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, MaxSpeed);
    }

}
