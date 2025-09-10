using UnityEngine;

using UnityEngine.UI;

using TMPro;

public class CharacterManager : MonoBehaviour 
{
    public CharacterDatabase characterDB;

    public TextMeshProUGUI nameText;
    public SpriteRenderer artworkSprite;

    public int characterSlot = 0;

    private int selectedOption = 0;

    void Start()
    {
        Load();
        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption = (selectedOption + 1) % characterDB.CharacterCount;

        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption += characterDB.CharacterCount;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption) 
    { 
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    private void Load()
    {
        string key = $"selectedOption_{characterSlot}";
        if (PlayerPrefs.HasKey(key))
        {
            selectedOption = PlayerPrefs.GetInt(key);
        }
        else
        {
            selectedOption = 0;
        }
    }

    private void Save()
    {
        string key = $"selectedOption_{characterSlot}";
        PlayerPrefs.SetInt(key, selectedOption);
    }

}
