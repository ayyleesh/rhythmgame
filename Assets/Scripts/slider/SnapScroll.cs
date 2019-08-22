using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SnapScroll : MonoBehaviour
{
    [Range(1, 50)]
    [Header("Controllers")]
    public int panelCounter;
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
    public MenuObject[] menu;

    private GameObject[] instPanel;
    private Vector2[] panelPosition;
    private Vector2[] panelScale;

    private Vector2 contentVector;
    private RectTransform contentRect;

    public int selectedPanelID;
    private bool isScrolling;

    void Start()
    {
        contentRect = GetComponent<RectTransform>();
        panelCounter = menu.Length;
        instPanel = new GameObject[panelCounter];
        panelPosition = new Vector2[panelCounter];
        panelScale = new Vector2[panelCounter];

        for (int i = 0; i < panelCounter; i++)
        {
            instPanel[i] = Instantiate(panel, transform, false);
            instPanel[i].transform.GetChild(0).GetComponent<Image>().sprite = menu[i].itemThumbnail;
            instPanel[i].transform.GetChild(1).GetComponent<Text>().text = menu[i].itemName;
            instPanel[i].transform.GetChild(2).GetComponentInChildren<Text>().text = "Stage " + menu[i].level;
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
