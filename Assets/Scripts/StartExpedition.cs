using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StartExpedition : MonoBehaviour {

    public __appManager app;
    public Button button;
    public Text buttonText;
    private ModalPanel modalPanel;
    private UnityAction startExpeditionAction;
    private UnityAction dontStartExpeditionAction;

    void Awake()
    {
        modalPanel = ModalPanel.Instance();

        startExpeditionAction = new UnityAction(ExpeditionStart);
        dontStartExpeditionAction = new UnityAction(CancelExpeditionStart);
    }

    // Use this for initialization
    void Start()
    {
        app = FindObjectOfType<__appManager>();

        if (!app.activeContract)
        {
            button.interactable = false;
            buttonText.color = new Color(255, 255, 255, 0.5f);
        }
    }

    public void ExpeditionCheck()
    {
        modalPanel.startCheck("Don't forget to buy supplies! \n\nAre you ready to start the Expedition?", startExpeditionAction, dontStartExpeditionAction);
    }

    void CancelExpeditionStart()
    {

    }

    // Update is called once per frame
    public void ExpeditionStart() {

        app.nextCampScene = 3;
        app.lastSceneNum = SceneManager.GetActiveScene().buildIndex;

        LoadingScreenManager.LoadScene(14);

    }

    public void AdvanceExpedition(int sceneNum)
    {
        app.nextCampScene = sceneNum;
        app.lastSceneNum = SceneManager.GetActiveScene().buildIndex;

        LoadingScreenManager.LoadScene(14);
    }
}
