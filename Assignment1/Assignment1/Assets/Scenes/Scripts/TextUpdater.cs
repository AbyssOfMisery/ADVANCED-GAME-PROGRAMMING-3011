using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextUpdater : MonoBehaviour
{
    public GameObject ScanningToggle;
    public GameObject Toggle;
    public GameObject Scans;
    public GameObject Score;
    public GameObject Extractions;
    public GameObject Tips;
    public GameObject gameOverPanel;

    private Toggle toggleBox;
    private Text toggleText;
    private Text scansText;
    private Text scoreText;
    private Text extractionsText;
    private Text tipsText;
    // Start is called before the first frame update
    void Start()
    {
        ScanningToggle = GameObject.Find("ScanningToggle");
        toggleBox = ScanningToggle.GetComponent<Toggle>();

        Toggle = GameObject.Find("Label");
        toggleText = Toggle.GetComponent<Text>();

        Scans = GameObject.Find("ScansText");
        scansText = Scans.GetComponent<Text>();

        Score = GameObject.Find("ScoreText");
        scoreText = Score.GetComponent<Text>();

        Extractions = GameObject.Find("ExtractionText");
        extractionsText = Extractions.GetComponent<Text>();

        Tips = GameObject.Find("TipsText");
        tipsText = Tips.GetComponent<Text>();

       
    }

    // Update is called once per frame
    void Update()
    {
        toggleBox.isOn = GameInfo.Scanning;
        toggleText.text = toggleBox.isOn ? "Scanning" : "Extracting";
        scansText.text = "Scans: " + GameInfo.Scans.ToString();
        scoreText.text = "Score: " + GameInfo.Score.ToString();
        extractionsText.text = "Extractions: " + GameInfo.Extractions.ToString();
        tipsText.text = GameInfo.Tip;

        if (!GameInfo.CanExtract)
        {
            GameInfo.TipIndex = 4;
            tipsText.text = GameInfo.Tip;

            GameObject root = GameObject.Find("Canvas");

            gameOverPanel = root.transform.Find("GameOverPanel").gameObject;
            gameOverPanel.SetActive(true);
            Destroy(this);
        }
    }
}
