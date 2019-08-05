using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavButtonScript : MonoBehaviour
{

    public GameObject menu;

    public void OpenMenu()
    {
        if (menu.gameObject != null)
        {
            menu.SetActive(true);
        }

    }

    public void CloseMenu()
    {
        if (menu.gameObject != null)
        {
            menu.SetActive(false);
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ToSongSelection()
    {
        SceneManager.LoadScene("Song Selector");
    }

    public void ToLessons()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    public void ToStore()
    {
        SceneManager.LoadScene("Store");
    }

    public void ToInventory()
    {
        SavePreviousScene();
        SceneManager.LoadScene("Inventory");
    }

    public void ToCharacterSelect()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void ToItemSelect()
    {
        SceneManager.LoadScene("EquipItems");
    }

    public void SavePreviousScene()
    {
        PlayerPrefs.SetString("previousScene", SceneManager.GetActiveScene().name);
    }

    public void ToPreviousScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("previousScene"));
    }
}
