using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInventory : MonoBehaviour
{
    public GameObject selectItemScene, selectCharacterScreen;
    public Button itemFilter, characterFilter;
    [Space]
    public SpriteState state = new SpriteState();

    private void Start()
    {
        if (PlayerPrefs.GetString("previousScene") == "LevelSelector")
        {
            DisplayCharacterSelect();
        }
    }

    public void DisplayItemSelect()
    {
        itemFilter.GetComponent<Image>().sprite = state.pressedSprite;
        characterFilter.GetComponent<Image>().sprite = state.disabledSprite;
        selectItemScene.SetActive(true);
        selectCharacterScreen.SetActive(false);

    }

    public void DisplayCharacterSelect()
    {
        itemFilter.GetComponent<Image>().sprite = state.disabledSprite;
        characterFilter.GetComponent<Image>().sprite = state.pressedSprite;

        selectItemScene.SetActive(false);
        selectCharacterScreen.SetActive(true);
    }

    public void ConfirmSelection()
    {
        FindObjectOfType<SelectItem>().ConfirmItemsEquip();
        FindObjectOfType<SelectCharacter>().ConfirmCharacter();
        FindObjectOfType<NavButtonScript>().ToPreviousScene();
    }
}
