using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectCharacter : MonoBehaviour
{
    public string previousCharacter;
    public string currentCharacter;
    public GameObject currentObject;
    public SpriteState state = new SpriteState();
    public int characterID;

    public void Start()
    {
        previousCharacter = PlayerPrefs.GetString("character");
        currentCharacter = PlayerPrefs.GetString("character");
        currentObject = GameObject.Find("Characters/Scroll View/Viewport/Content/" + PlayerPrefs.GetString("character"));
        currentObject.GetComponent<Image>().sprite = state.pressedSprite;
    }

    public void CharacterSelect()
    {
        currentObject = EventSystem.current.currentSelectedGameObject;
        previousCharacter = currentCharacter;
        currentCharacter = currentObject.name;
        if (previousCharacter == currentCharacter) return;
        GameObject.Find(currentCharacter).GetComponent<Image>().sprite = state .pressedSprite;
        GameObject.Find(previousCharacter).GetComponent<Image>().sprite = state.disabledSprite;
        characterID = currentObject.GetComponent<CharacterSlot>().character.itemID;
    }

    public void ConfirmCharacter()
    {
        PlayerPrefs.SetString("character", currentCharacter);
        Debug.Log("selected " + PlayerPrefs.GetString("character"));
        PlayerPrefs.SetInt("characterID", characterID);
    }
}
