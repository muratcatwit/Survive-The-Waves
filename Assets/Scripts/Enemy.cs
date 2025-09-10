using System;
using System.Threading;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour
{

    //Sprite Managment
    public CharacterDatabase characterDB;
    public TextMeshProUGUI nameText;
    public SpriteRenderer artworkSprite;
    private int selectedOption;
    //spritemanagment end

    private Rigidbody2D rb;

    public PlayerScript player;

    public int hp;

    public float speed;
    private Vector3 direction;

    public int attack;

    public float attack_gap;
    private float attack_timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // sprite management
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = Random.Range(0, characterDB.CharacterCount);
            PlayerPrefs.SetInt("selectedOption", selectedOption); // Save the random selection
        }
        else Load();

        UpdateCharacter(selectedOption);
        // end sprite management
    }

    void Update(){
        direction = player.getPos() - this.transform.position;
        direction.Normalize();
        this.transform.Translate(direction * speed * Time.deltaTime);

        attack_timer -= Time.deltaTime;

        float input = Input.GetAxisRaw("Horizontal");
        float input2 = Input.GetAxisRaw("Vertical");

        if (input > 0)
        {
            input2 = 0;
        }
        if (input2 > 0)
        {
            input = 0;
        }

        // Flip player sprite along the X-axis based on horizontal input
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && input != 0)
        {
            sr.flipX = input > 0;
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            player.health -= attack;
            if (player.health <= 0)
            {
                player.gameObject.SetActive(false);
                GM.instance().setLoseScreen(true);
            }


        }

    }

    //Sprite Managment
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption_0");
    }



}
