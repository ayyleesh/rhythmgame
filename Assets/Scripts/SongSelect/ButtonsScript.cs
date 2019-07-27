using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    [Header("global")]
    public GameObject popUp;
    public Text gameDetail;
    public bool isActive;
    public PurchasableItems items;
    public Button playButton;

    [Header("Level Select")]    
    public LevelLoader levelLoader;
    public Image character;

    [Header("Song Select")]
    public SnapScroll snapScroll;
    public Image item1, item2;


    public void ShowPopUp()
    {
        isActive = true;
        popUp.SetActive(true);
    }

    public void LoadPopUpInfo(int level, int counter)
    {
        ShowPopUp();
        Debug.Log(levelLoader.levelGroups[level].romajiNames[counter]);
        gameDetail.text = "Learn Hiragana " + levelLoader.levelGroups[level].romajiNames[counter] + "!";
        character.sprite = items.purchasableItems[PlayerPrefs.GetInt("characterID")].itemImage;
        playButton.onClick.AddListener(() => StartGame("scene" + level + counter));
    }

    public void LoadSongInfo(int songIndex)
    {
        ShowPopUp();
        Debug.Log(snapScroll.rhythmSongs[songIndex - 1].itemName);
        gameDetail.text = snapScroll.rhythmSongs[songIndex - 1].itemName;
        item1.sprite = items.purchasableItems[PlayerPrefs.GetInt("itemEquipped1")].itemImage;
        item2.sprite = items.purchasableItems[PlayerPrefs.GetInt("itemEquipped2")].itemImage;
        playButton.onClick.AddListener(() => StartGame("scene" + songIndex));
    }

    public void StartGame(string sceneName)
    {
        Debug.Log(sceneName);
    }

    public void ClosePopUp()
    {
        if (isActive)
        {
            popUp.SetActive(false);
        }
    }

    public void ToInventory()
    {
        SceneManager.LoadScene("Inventory");
    }
}
