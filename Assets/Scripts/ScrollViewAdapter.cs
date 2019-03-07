using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewAdapter : MonoBehaviour {

    public RectTransform prefab;
    public ScrollRect scrollView;
    public RectTransform content;
    public __appManager app;

    List<ExampleItemView> views = new List<ExampleItemView>();

	// Use this for initialization
	void Start () {

        UpdateItems();
        app = FindObjectOfType<__appManager>();
    }

    public void UpdateItems()
    {
        int newCount = 10;

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

	IEnumerator FetchItemModelsFromServer (int count, Action<ExampleItemModel[]> onDone)
    {
        // Simulating Server delay
        yield return new WaitForSeconds(0.25f);

        var results = new ExampleItemModel[count];
        for (int i = 0; i < count; ++i)
        {
            results[i] = new ExampleItemModel();
            // Lakhpa, Dorjee, Tensing, Nawang, Tashi Penba Pasang Purbu Lhakpa Mikmar dawa nyima
            //https://en.wikipedia.org/wiki/Tibetan_calendar#Days

            string[] middleName = {"A.", "B.", "C.", "D.", "E.", "F.", "G.", "H.", "I.", "J.", "K.", "L.", "M.", "N.", "O.", "P.", "Q.", "R.", "S.", "T.", "U.", "V.", "W.", "X.", "Y.", "Z."};
            string[] stringArray = { "Lakhpa", "Dorjee", "Tensing", "Nawang", "Tashi", "Penba", "Pasang", "Purbu", "Lhakpa", "Mikmar", "Dawa", "Nyima"};

            results[i].name = "Sherpa " + middleName[UnityEngine.Random.Range(0, middleName.Length)] + " " + stringArray[UnityEngine.Random.Range(0, stringArray.Length)];
            results[i].age = UnityEngine.Random.Range(18, 45);

            if (app.summitUnlocked == true)
            {
                results[i].firstAid = UnityEngine.Random.Range(0, 6);
                results[i].stamina = UnityEngine.Random.Range(0, 6);
                results[i].survival = UnityEngine.Random.Range(0, 6);
            }
            else if (app.camp3Unlocked == true)
            {
                results[i].firstAid = UnityEngine.Random.Range(0, 5);
                results[i].stamina = UnityEngine.Random.Range(0, 5);
                results[i].survival = UnityEngine.Random.Range(0, 5);
            }
            else
            {
                results[i].firstAid = UnityEngine.Random.Range(0, 3);
                results[i].stamina = UnityEngine.Random.Range(0, 3);
                results[i].survival = UnityEngine.Random.Range(0, 3);
            }


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
