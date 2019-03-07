using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapter_Contract : MonoBehaviour
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
        int newCount = 0;

        // determine level of contracts available
        if (app.summitUnlocked)
        {
            newCount = 10;
        }
        else if (app.camp4Unlocked)
        {
            newCount = 8;
        }
        else if (app.camp3Unlocked)
        {
            newCount = 5;
        }
        else if (app.camp2Unlocked)
        {
            newCount = 4;
        }
        else
        {
            newCount = 3;
        }

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

        view.levelText.text = "Level " + model.level.ToString() + " Contract"; 
        view.priceText.text = model.price.ToString();


        if (model.risk == 3)
        {
            view.riskText.text = "High";
        }
        else if (model.risk == 2)
        {
            view.riskText.text = "Medium";
        }
        else
        {
            view.riskText.text = "Low";
        }

        view.destinationText.text = model.destination.ToString();
        view.numClimbersText.text = model.climbers.ToString();

        return view;

    }

    IEnumerator FetchItemModelsFromServer(int count, Action<ExampleItemModel[]> onDone)
    {
        // Simulating Server delay
        yield return new WaitForSeconds(0.25f);

        var results = new ExampleItemModel[count];
        for (int i = 0; i < count; ++i)
        {
            
            results[i] = new ExampleItemModel();
            int contractLevel = 0;

            // set number of climbers on contract
            results[i].climbers = UnityEngine.Random.Range(1, app.partySize + 1);

            // determine level of contracts available
            if (app.summitUnlocked)
            {
                contractLevel = UnityEngine.Random.Range(1, 6);

                if (contractLevel == 5)
                {
                    results[i].price = 15000 * results[i].climbers;
                }
                else if (contractLevel == 4)
                {
                    results[i].price = 12500 * results[i].climbers;
                }
                else if (contractLevel == 3)
                {
                    results[i].price = 10000 * results[i].climbers;
                }
                else if (contractLevel == 2)
                {
                    results[i].price = 7500 * results[i].climbers;
                }
                else
                {
                    results[i].price = 5000 * results[i].climbers;
                }
            }
            else if (app.camp4Unlocked)
            {
                contractLevel = UnityEngine.Random.Range(1, 5);

                if (contractLevel == 4)
                {
                    results[i].price = 12500 * results[i].climbers;
                }
                else if (contractLevel == 3)
                {
                    results[i].price = 10000 * results[i].climbers;
                }
                else if (contractLevel == 2)
                {
                    results[i].price = 7500 * results[i].climbers;
                }
                else
                {
                    results[i].price = 5000 * results[i].climbers;
                }
            }
            else if (app.camp3Unlocked)
            {
                contractLevel = UnityEngine.Random.Range(1, 4);

                if (contractLevel == 3)
                {
                    results[i].price = 10000 * results[i].climbers;
                }
                else if (contractLevel == 2)
                {
                    results[i].price = 7500 * results[i].climbers;
                }
                else
                {
                    results[i].price = 5000 * results[i].climbers;
                }
            }
            else if (app.camp2Unlocked)
            {
                contractLevel = UnityEngine.Random.Range(1, 3);
                if (contractLevel == 2)
                {
                    results[i].price = 7500 * results[i].climbers;
                }
                else
                {
                    results[i].price = 5000 * results[i].climbers;
                }
            }
            else
            {
                contractLevel = 1;
                results[i].price = 5000 * results[i].climbers;
            }

            results[i].level = contractLevel;

            results[i].destination = contractLevel;

            if (contractLevel == 5)
            {
                results[i].risk = 3;
            }
            else if (contractLevel >= 3)
            {
                results[i].risk = 2;
            }
            else
            {
                results[i].risk = 1;
            }

        }

        onDone(results);
    }

    public class ExampleItemView
    {
        public Text levelText, riskText, destinationText, numClimbersText, priceText;

        public ExampleItemView(Transform rootView)
        {
            levelText = rootView.Find("Level").GetComponent<Text>();
            priceText = rootView.Find("Price").GetComponent<Text>();
            riskText = rootView.Find("Risk").GetComponent<Text>();
            destinationText = rootView.Find("Destination").GetComponent<Text>();
            numClimbersText = rootView.Find("Climbers").GetComponent<Text>();
        }
    }

    public class ExampleItemModel
    {
        public int level, price, destination, climbers, risk;
    }

}
