using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    GameObject theButton;
    GameObject secondButton;
    [SerializeField] GameObject[] allbutton;
    public GameObject panel;
    public GameObject pool;
    public GameObject win_menu;
    public GameObject lose_menu;
    public Sprite base_sprite;
    public AudioSource win_voice;
    public AudioSource destroy_voice;
    public AudioSource newrecord_voice;
    int zeroValue = 0;
    bool isClicked;
    bool makeIt = true;
    public float time;
    int target_number = 15;
    int present_number = 0;
    int totalMakeNumber;
    int makingNumber;

    public TextMeshProUGUI time_screen;
    public TextMeshProUGUI endgame_time;

    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        totalMakeNumber = pool.transform.childCount;
        StartCoroutine(MakeitRandomly());
    }
    void Update()
    {
        time += Time.deltaTime;
        time_screen.text = Mathf.FloorToInt(time).ToString();
        timeCheck();
    }

    public void TakeObject(GameObject firstbutton)
    {

        theButton = firstbutton;
        theButton.GetComponent<Image>().sprite = theButton.GetComponentInChildren<SpriteRenderer>().sprite;
        theButton.GetComponent<Image>().raycastTarget = false;
    }

    public void Check(int buttonValue)
    {

        if (zeroValue == 0)
        {
            zeroValue = buttonValue;
            secondButton = theButton;


        }
        else
        {
            StartCoroutine(SecondCheck(buttonValue));
        }
    }

    IEnumerator SecondCheck(int buttonValue)
    {
        isClicked = false;
        ClickCheck();
        yield return new WaitForSeconds(1f);

        if (buttonValue == zeroValue)
        {
            present_number++;
            destroy_voice.Play();
            End_game();
            theButton.GetComponent<Image>().enabled = false;
            secondButton.GetComponent<Image>().enabled = false;
            theButton.GetComponent<Button>().enabled = false;
            secondButton.GetComponent<Button>().enabled = false;
            zeroValue = 0;
            secondButton = null;
            isClicked = true;
            ClickCheck();

        }
        else
        {
            theButton.GetComponent<Image>().sprite = base_sprite;
            secondButton.GetComponent<Image>().sprite = base_sprite;
            zeroValue = 0;
            secondButton = null;
            isClicked = true;
            ClickCheck();

        }


    }

    void ClickCheck()
    {
        if (isClicked == true)
        {
            foreach (var item in allbutton)
            {
                if (item != null)

                    item.GetComponent<Image>().raycastTarget = true;
            }
        }
        else
        {
            foreach (var item in allbutton)
            {
                if (item != null)

                    item.GetComponent<Image>().raycastTarget = false;
            }
        }



    }
    void timeCheck()
    {
        if (time > 120)
        {
            lose_menu.SetActive(true);
        }
    }


    void End_game()
    {
        if (present_number == target_number)
        {
            destroy_voice.Stop();
            win_voice.Play();
            win_menu.SetActive(true);
            if (PlayerPrefs.HasKey("highest"))
            {

                if (time < PlayerPrefs.GetFloat("highest"))
                {

                    endgame_time.text = " NEW RECORD    " + Mathf.FloorToInt(time).ToString();
                    win_voice.Pause();
                    newrecord_voice.Play();
                    PlayerPrefs.SetFloat("highest", time);
                    //PlayerPrefs.DeleteAll();

                }
                else
                {


                    endgame_time.text = " SCORE    " + Mathf.FloorToInt(time).ToString();
                    //PlayerPrefs.SetFloat("highest", time);
                    //PlayerPrefs.DeleteAll();

                }


            }
            else
            {
                PlayerPrefs.SetFloat("highest", time);
                endgame_time.text = " SCORE    " + Mathf.FloorToInt(time).ToString();
            }

        }

    }

    IEnumerator MakeitRandomly()
    {
        yield return new WaitForSeconds(0.1f);
        while (makeIt)
        {

            int rndm = Random.Range(0, pool.transform.childCount - 1);

            if (pool.transform.GetChild(rndm).gameObject != null)
            {
                pool.transform.GetChild(rndm).transform.SetParent(panel.transform);

                panel.transform.GetChild(makingNumber).transform.localScale = new Vector3(1, 1, 0);

                makingNumber++;

                if (makingNumber == totalMakeNumber)
                {
                    makeIt = false;
                }


            }

        }
    }

    public void main_menu()
    {
        SceneManager.LoadScene(0);
    }


}
