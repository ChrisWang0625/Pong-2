using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed = 30;

    private Rigidbody2D rigidBody;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {

        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector2.right * speed;

	}
	
    void OnCollisionEnter2D(Collision2D col)
    {
        // LeftPaddle or RightPaddle
        if((col.gameObject.name == "LeftPaddle") || (col.gameObject.name == "RightPaddle"))
        {
            handlePaddleHit(col);
        }

        // BottomWall or TopWall
        if ((col.gameObject.name == "BottomWall") || (col.gameObject.name == "TopWall"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBloop);
        }
        // LeftWall or RightWall
        if ((col.gameObject.name == "LeftWall") || (col.gameObject.name == "RightWall"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);
            // TODO Update Score UI

            transform.position = new Vector2(0, 0);
        }
    }

    void handlePaddleHit(Collision2D col)
    {

        float y = ballHitPaddleWhere(transform.position, col.transform.position, col.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if (col.gameObject.name == "LeftPaddle")
        {
            dir = new Vector2(1, y).normalized;
        }

        if (col.gameObject.name == "RightPaddle")
        {
            dir = new Vector2(-1, y).normalized;
        }

        rigidBody.velocity = dir * speed;

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.hitPaddleBloop);
    }

    float ballHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }
}
