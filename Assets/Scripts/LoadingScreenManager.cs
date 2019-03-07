// LoadingScreenManager
// --------------------------------
// built by Martin Nerurkar (http://www.martin.nerurkar.de)
// for Nowhere Prophet (http://www.noprophet.com)
//
// Licensed under GNU General Public License v3.0
// http://www.gnu.org/licenses/gpl-3.0.txt

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{

    [Header("Loading Visuals")]
    public Image loadingIcon;
    public Image loadingDoneIcon;
    public Text loadingText;
    public Image progressBar;
    public Image fadeOverlay;
    public Text FunFacts;

    [Header("Timing Settings")]
    public float waitOnLoadEnd = 0.75f;
    public float fadeDuration = 0.25f;

    [Header("Loading Settings")]
    public LoadSceneMode loadSceneMode = LoadSceneMode.Single;
    public ThreadPriority loadThreadPriority;

    [Header("Other")]
    // If loading additive, link to the cameras audio listener, to avoid multiple active audio listeners
    public AudioListener audioListener;

    AsyncOperation operation;
    Scene currentScene;

    public static int sceneToLoad = -1;
    // IMPORTANT! This is the build index of your loading scene. You need to change this to match your actual scene index
    static int loadingSceneIndex = 2;

    public static void LoadScene(int levelNum)
    {
        Application.backgroundLoadingPriority = ThreadPriority.High;
        sceneToLoad = levelNum;
        SceneManager.LoadScene(loadingSceneIndex);
    }

    string getFact()
    {
        string[] stringArray = { "There are two main routes to the summit: the south-east ridge from Nepal and the north ridge from Tibet.",
                                 "The officially recognised height of Mount Everest is 29,029ft (8,848m), based on a 1954 ground-based measurement. A disputed satellite-based measurement in 1999 suggested it was six feet taller.",
                                 "The first woman to climb Everest was Junko Tabei, from Japan, in 1975.",
                                 "Temperatures on the mountain can get as low as -60\u00B0F celsius .",
                                 "Geologically speaking, Mt Everest is about 60 million years old.",
                                 "Sherpa is the name of a nomadic people in eastern Nepal, who also use it as their last name. Usually, their first name is the day of the week on which they were born.",
                                 "The highest 848 metres of the mountain are known as the \"death zone\".",
                                 "Climbers have left an estimated 120 tons of litter on the mountain, including oxygen tanks, tents and other kits.",
                                 "The largest group to climb Everest was a 410-member Chinese team, in 1975.",
                                 "Avalanches are the foremost cause of death, followed by falls.",
                                 "It is estimated that expeditions to climb the mountain take two months from start to end.",
                                 "The summit is just below the cruising height of a jet (around 31,000ft).",
                                 "The fastest descent was made in 11 minutes: Frenchman Jean-Marc Boivin paraglided down in 1988.",
                                 "The most dangerous area on the mountain is Khumbu ice fall, which is thought to have claimed 19 lives.",
                                 "The record for the most summits is 21, held by 53-year-old Apa Sherpa, known as \"Super Sherpa\". His most recent was in 2011.",
                                 "Climbers start using bottled oxygen at 26,000ft. It makes a 3,000ft difference in how they feel.",
                                 "Remember that a Contract with low risk doesn't mean that there is no risk. There is always risk.",
                                 "A Contracts price is based on how many climbers there are and the destination camp."
                                };
        
        return stringArray[Random.Range(0, stringArray.Length)];
    }

    void Start()
    {
        if (sceneToLoad < 0)
            return;

        fadeOverlay.gameObject.SetActive(true); // Making sure it's on so that we can crossfade Alpha
        currentScene = SceneManager.GetActiveScene();
        StartCoroutine(LoadAsync(sceneToLoad));

        FunFacts.text = getFact();
    }
    
    private IEnumerator LoadAsync(int levelNum)
    {
        ShowLoadingVisuals();

        yield return null;

        FadeIn();
        StartOperation(levelNum);

        float lastProgress = 0f;

        // operation does not auto-activate scene, so it's stuck at 0.9
        while (DoneLoading() == false)
        {
            // Added to give the appearance for loading, even when it loads super fast
            yield return new WaitForSeconds(1.75f);

            if (Mathf.Approximately(operation.progress, lastProgress) == false)
            {
                progressBar.fillAmount = operation.progress;
                lastProgress = operation.progress;

                // Added to give the appearance for loading, even when it loads super fast
                yield return new WaitForSeconds(1.0f);
            }
        }

        if (loadSceneMode == LoadSceneMode.Additive)
            audioListener.enabled = false;

        ShowCompletionVisuals();

        yield return new WaitForSeconds(waitOnLoadEnd);

        FadeOut();

        yield return new WaitForSeconds(fadeDuration);

        if (loadSceneMode == LoadSceneMode.Additive)
            SceneManager.UnloadScene(currentScene.name);
        else
            operation.allowSceneActivation = true;
    }

    private void StartOperation(int levelNum)
    {
        Application.backgroundLoadingPriority = loadThreadPriority;
        operation = SceneManager.LoadSceneAsync(levelNum, loadSceneMode);


        if (loadSceneMode == LoadSceneMode.Single)
            operation.allowSceneActivation = false;
    }

    private bool DoneLoading()
    {
        return (loadSceneMode == LoadSceneMode.Additive && operation.isDone) || (loadSceneMode == LoadSceneMode.Single && operation.progress >= 0.9f);
    }

    void FadeIn()
    {
        fadeOverlay.CrossFadeAlpha(0, fadeDuration, true);
    }

    void FadeOut()
    {
        fadeOverlay.CrossFadeAlpha(1, fadeDuration, true);
    }

    void ShowLoadingVisuals()
    {
        loadingIcon.gameObject.SetActive(true);
        loadingDoneIcon.gameObject.SetActive(false);

        progressBar.fillAmount = 0f;
        loadingText.text = "Loading....";
    }

    void ShowCompletionVisuals()
    {
        loadingIcon.gameObject.SetActive(false);
        loadingDoneIcon.gameObject.SetActive(true);

        progressBar.fillAmount = 1f;
        loadingText.text = "Ready";
    }

}