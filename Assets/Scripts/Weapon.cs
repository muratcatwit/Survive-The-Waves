using System;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform playerTransform;

    public Vector3 baseOffset = new Vector3(1f, 0f, 0f);
    private Vector3 currentOffset;

    public float attack_gap = 1f;
    private float attack_timer = 1f;
    public int damage = 1;
    private Vector2 direction = Vector2.right;

    private Rigidbody2D rb;
    private Collider2D hitbox;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitbox = GetComponent<Collider2D>();
        currentOffset = baseOffset;

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + currentOffset;
        }

        attack_timer += Time.deltaTime;
        if (attack_timer >= attack_gap)
        {
            //PerformAttack();
            attack_timer = 0f;
        }
    }

    void PerformAttack()
    {
        // Example visual swing: rotate briefly
        StartCoroutine(SwingAnimation());

        // Optionally expand collider briefly here
        // or enable/disable collider to "pulse" hit detection
    }

    System.Collections.IEnumerator SwingAnimation()
    {
        Quaternion originalRot = transform.rotation;
        transform.rotation = Quaternion.Euler(0, 0, direction.x >= 0 ? -45 : 45);
        yield return new WaitForSeconds(0.1f);
        transform.rotation = originalRot;
    }

    public void SetDirection(Vector2 in_direct)
    {
        if (in_direct == Vector2.zero)
            return;

        direction = in_direct.normalized;
        currentOffset = new Vector3(baseOffset.x * direction.x, baseOffset.y * direction.y, 0);

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.flipX = direction.x < 0;
            sr.flipY = direction.y < 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy e = other.GetComponent<Enemy>();
            if (e != null)
            {
                e.hp -= damage;

                if (e.hp <= 0)
                {
                    e.gameObject.SetActive(false);
                }
            }
        }
    }
}
