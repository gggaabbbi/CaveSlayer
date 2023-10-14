using System;
using System.Collections;
using UnityEngine;
public class WolfBehaviour : MonoBehaviour
{
    [SerializeField, Range(0f, 10f)] private float velocity;
    [SerializeField] private float distanceThreshold;

    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector2 playerPosition;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(transform.position, PlayerBehaviour.Instance.GetPlayerPosition());
        if (distanceFromPlayer <= distanceThreshold)
        {
            SetIsMovingAnimParameter(true);
            playerPosition = PlayerBehaviour.Instance.GetPlayerPosition();
            transform.position = Vector2.MoveTowards(transform.position, playerPosition, velocity * Time.deltaTime);
        }

        if (rigidbody.velocity.magnitude == 0)
        {
            SetIsMovingAnimParameter(false);
        }

        CheckEnemySprite();
    }

    private void CheckEnemySprite()
    {
        if (transform.position.x - playerPosition.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x - playerPosition.x > 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void SetIsMovingAnimParameter(bool isMoving)
    {
        animator.SetBool("isMoving", isMoving);
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.35f);
        Destroy(this.gameObject);
        GameManager.instance.EnemyKills();
    }
}
