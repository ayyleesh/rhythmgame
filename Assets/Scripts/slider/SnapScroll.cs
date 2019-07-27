using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnapScroll : MonoBehaviour
{
    [Header("Controllers")]
    [Range(0, 500)]
    public int panelOffset;
    [Range(0f, 5f)]
    public float scaleOffset;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(1f, 20f)]
    public float scaleSpeed;
    [Header("Other Objects")]
    public GameObject panel;
    public RhythmSong[] rhythmSongs;

    private GameObject[] instPanel;
    private Vector2[] panelPosition;
    private Vector2[] panelScale;

    private Vector2 contentVector;
    private RectTransform contentRect;

    public int selectedPanelID, panelCounter;
    private bool isScrolling;

    void Start()
    {
        panelCounter = rhythmSongs.Length;
        contentRect = GetComponent<RectTransform>();
        instPanel = new GameObject[panelCounter];
        panelPosition = new Vector2[panelCounter];
        panelScale = new Vector2[panelCounter];

        for (int i = 0; i < panelCounter; i++)
        {
            instPanel[i] = Instantiate(panel, transform, false);
            instPanel[i].transform.GetChild(0).GetComponent<Image>().sprite = rhythmSongs[i].itemThumbnail;
            instPanel[i].transform.GetChild(1).GetComponent<Text>().text = rhythmSongs[i].itemName;
            instPanel[i].transform.GetChild(2).GetComponentInChildren<Text>().text = "Lv." + rhythmSongs[i].level;
            if (i == 0) continue;
            instPanel[i].transform.localPosition = new Vector2(instPanel[i].transform.localPosition.x, instPanel[i-1].transform.localPosition.y - panel.GetComponent<RectTransform>().sizeDelta.y - panelOffset);
            panelPosition[i] = -instPanel[i].transform.localPosition;
        }  
    }

    private void FixedUpdate()
    {
        float nearestPos = float.MaxValue;
        for (int i = 0; i < panelCounter; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.y - panelPosition[i].y);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedPanelID = i;
            }
            float scale = Mathf.Clamp(1 / (distance / panelOffset) * scaleOffset, 0.8f, 1f);
            panelScale[i].x = Mathf.SmoothStep(instPanel[i].transform.localScale.x, scale, scaleSpeed * Time.fixedDeltaTime);
            panelScale[i].y = Mathf.SmoothStep(instPanel[i].transform.localScale.y, scale, scaleSpeed * Time.fixedDeltaTime);
            instPanel[i].transform.localScale = panelScale[i];
            
        }
        if (isScrolling) return;
        contentVector.y = Mathf.SmoothStep(contentRect.anchoredPosition.y, panelPosition[selectedPanelID].y, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
    }
    
}
