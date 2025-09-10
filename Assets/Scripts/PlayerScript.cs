using TMPro;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    //Sprite Managment
    public CharacterDatabase characterDB;
    public TextMeshProUGUI nameText;
    public SpriteRenderer artworkSprite;
    private int selectedOption;

    //Player Stats
    public float speed;
    public Weapon weapon;
    private Rigidbody2D rb;
    private float input;
    private float input2;
    public GameObject enemy;
    public float health;
    public TimerScript t;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //sprite managment
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else Load();
        UpdateCharacter(selectedOption);
        //end sprite managment

    }

    void Update(){
        input=Input.GetAxisRaw("Horizontal");
        input2=Input.GetAxisRaw("Vertical");
        
        if(input>0){
            input2=0;
        }
        if(input2>0){
            input=0;
        }

        //diagonal speed correction
        if (input!=0 && input2!=0){ 
            input = input * 0.7f;
            input2 = input2 * 0.7f;
        }

        // Flip player sprite along the X-axis based on horizontal input
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && input != 0)
        {
            sr.flipX = input > 0;
        }

        weapon.SetDirection(new Vector2(input, input2));


    }

    void FixedUpdate(){
        rb.linearVelocity = new Vector2(input * speed, input2 * speed);
        
    }

    public Vector3 getPos(){
        return this.transform.position;
    }

    public void reset()
    {
        Vector3 pos = new Vector3(-0.9599609f, 0.9799805f, 0f);
        transform.position = pos;
        enemy.transform.position = new Vector3(5f, 0f, 0f);
        this.gameObject.SetActive(true);
        health = 10;
        weapon.gameObject.SetActive(true);
        GM.instance().setLoseScreen(false);
        if (t!=null)
        {
            t.ResetTimer();
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
