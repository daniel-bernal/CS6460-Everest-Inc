using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapter_Team : MonoBehaviour
{

    public RectTransform prefab;
    public ScrollRect scrollView;
    public RectTransform content;
    public __appManager app;

    List<ExampleItemView> views = new List<ExampleItemView>();

    // Use this for initialization
    void Start()
    {
        app = FindObjectOfType<__appManager>();
        UpdateItems();
    }

    public void UpdateItems()
    {
        int newCount = app.getParty();

        StartCoroutine(FetchItemModelsFromServer(newCount, results => OnReceiveNewModel(results)));
    }

    void OnReceiveNewModel(ExampleItemModel[] models)
    {
        foreach (Transform child in content.transform)
            Destroy(child.gameObject);

        views.Clear();

        int i = 0;
        foreach (var model in models)
        {
            var instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
            var view = InitializeItemView(instance, model);
            views.Add(view);

            ++i;
        }
    }

    ExampleItemView InitializeItemView(GameObject viewGameObject, ExampleItemModel model)
    {
        ExampleItemView view = new ExampleItemView(viewGameObject.transform);

        view.nameText.text = model.name;
        view.costText.text = "Cost: $" + model.cost.ToString();
        view.ageText.text = model.age.ToString();
        view.firstaidText.text = model.firstAid.ToString();
        view.staminaText.text = model.stamina.ToString();
        view.survivalText.text = model.survival.ToString();

        return view;

    }

    IEnumerator FetchItemModelsFromServer(int count, Action<ExampleItemModel[]> onDone)
    {
        // Simulating Server delay
        yield return new WaitForSeconds(0.25f);

        app = FindObjectOfType<__appManager>();

        var results = new ExampleItemModel[count];
        for (int i = 0; i < count; ++i)
        {


            results[i] = new ExampleItemModel();

            results[i].name = app.sherpaTeam[i].name;
            results[i].age = app.sherpaTeam[i].age;
            results[i].firstAid = app.sherpaTeam[i].firstAid;
            results[i].stamina = app.sherpaTeam[i].stamina;
            results[i].survival = app.sherpaTeam[i].survival;



            if (results[i].firstAid + results[i].stamina + results[i].survival == 15)
            {
                results[i].cost = 10000;
            }
            else if (results[i].firstAid + results[i].stamina + results[i].survival >= 12)
            {
                results[i].cost = 7500;
            }
            else if (results[i].firstAid + results[i].stamina + results[i].survival >= 9)
            {
                results[i].cost = 5000;
            }
            else if (results[i].firstAid + results[i].stamina + results[i].survival >= 6)
            {
                results[i].cost = 2500;
            }
            else
            {
                results[i].cost = 1000;
            }
        }

        onDone(results);
    }

    public class ExampleItemView
    {
        public Text nameText, ageText, firstaidText, staminaText, survivalText, costText;

        public ExampleItemView(Transform rootView)
        {
            nameText = rootView.Find("Name").GetComponent<Text>();
            costText = rootView.Find("Cost").GetComponent<Text>();
            ageText = rootView.Find("Age").GetComponent<Text>();
            firstaidText = rootView.Find("FirstAid").GetComponent<Text>();
            staminaText = rootView.Find("Stamina").GetComponent<Text>();
            survivalText = rootView.Find("Survival").GetComponent<Text>();
        }
    }

    public class ExampleItemModel
    {
        public string name;
        public int cost, firstAid, stamina, survival, age;
    }

}
