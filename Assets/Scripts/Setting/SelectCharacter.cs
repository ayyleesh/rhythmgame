using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    public string previousCharacter;
    public string currentCharacter;
    public GameObject currentObject;
    public SpriteState state = new SpriteState();
    int characterID;

    public void Start()
    {
        previousCharacter = PlayerPrefs.GetString("character");
        currentCharacter = PlayerPrefs.GetString("character");
        currentObject = GameObject.Find("Characters/Viewport/Content/"+PlayerPrefs.GetString("character"));
        currentObject.GetComponent<Image>().sprite = state.pressedSprite;
    }

    public void CharacterSelect()
    {
        previousCharacter = currentCharacter;
        currentCharacter = EventSystem.current.currentSelectedGameObject.name;
        if (previousCharacter == currentCharacter) return;
        GameObject.Find(currentCharacter).GetComponent<Image>().sprite = state.pressedSprite;
        GameObject.Find(previousCharacter).GetComponent<Image>().sprite = state.disabledSprite;
        characterID = GameObject.Find("Characters/Viewport/Content/" + currentCharacter).GetComponent<Characters>().character.itemID;
    }

    public void ConfirmCharacter()
    {
        PlayerPrefs.SetString("character", currentCharacter);
        Debug.Log("selected " + PlayerPrefs.GetString("character"));
        Debug.Log(characterID);
        PlayerPrefs.SetInt("characterID", characterID);
    }
}
