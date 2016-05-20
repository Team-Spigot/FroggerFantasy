using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace TeamSpigot
{
    public class OpenningDia : MonoBehaviour
    {
        int timeInFrames;
        int skip;
        bool skippable = true;
        Text displayText;
        Text skipText;

        public GameObject yesButt;
        public GameObject noButt;


        bool naming;

        bool nameReady = false;
        bool nameQuestion = false;
        string nameInput = "New Name";
        public string playerName;

        bool playerClass;
        public bool setUpActive;

        void Awake()
        {
            PlayerPrefs.DeleteKey("Won");

            displayText = GameObject.Find("Prologue").GetComponent<Text>();
            GameObject.Find("Prologue").GetComponent<Text>().text = "";

            skipText = GameObject.Find("Skip Text").GetComponent<Text>();
            GameObject.Find("Skip Text").GetComponent<Text>().text = "press space to skip...";
        }

        void Update()
        {
            Prologue();

            //Debug.Log("name: " + playerName);

            //Debug.Log("nameReady: " + nameReady);

        }

        void Prologue()
        {
            timeInFrames = Time.frameCount + skip;

            if (Input.GetKeyDown(KeyCode.Space) && skippable)
            {
                skip = 644 - Time.frameCount;
            }

            #region start text
            if (timeInFrames == 60)
            {
                displayText.text = "H";
            }
            if (timeInFrames == 75)
            {
                displayText.text = "He";
            }
            if (timeInFrames == 90)
            {
                displayText.text = "Hel";
            }
            if (timeInFrames == 105)
            {
                displayText.text = "Hell";
            }
            if (timeInFrames == 120)
            {
                displayText.text = "Hello";
            }
            if (timeInFrames == 135)
            {
                displayText.text = "Hello ";
            }
            if (timeInFrames == 150)
            {
                displayText.text = "Hello W";
            }
            if (timeInFrames == 165)
            {
                displayText.text = "Hello Wo";
            }
            if (timeInFrames == 180)
            {
                displayText.text = "Hello Wor";
            }
            if (timeInFrames == 195)
            {
                displayText.text = "Hello Worl";
            }
            if (timeInFrames == 210)
            {
                displayText.text = "Hello World";
            }
            if (timeInFrames == 225)
            {
                displayText.text = "Hello World.";
            }
            if (timeInFrames == 240)
            {
                displayText.text = "Hello World..";
            }
            if (timeInFrames == 255)
            {
                displayText.text = "Hello World...";
            }
            if (timeInFrames == 315)
            {
                displayText.text = "[deleted]";
            }
            if (timeInFrames == 375)
            {
                displayText.text = "";
            }
            if (timeInFrames == 390)
            {
                displayText.text = "W";
            }
            if (timeInFrames == 405)
            {
                displayText.text = "Wh";
            }
            if (timeInFrames == 420)
            {
                displayText.text = "Wha";
            }
            if (timeInFrames == 435)
            {
                displayText.text = "What";
            }
            if (timeInFrames == 450)
            {
                displayText.text = "What ";
            }
            if (timeInFrames == 465)
            {
                displayText.text = "What I";
            }
            if (timeInFrames == 480)
            {
                displayText.text = "What Is";
            }
            if (timeInFrames == 495)
            {
                displayText.text = "What Is ";
            }
            if (timeInFrames == 510)
            {
                displayText.text = "What Is Y";
            }
            if (timeInFrames == 525)
            {
                displayText.text = "What Is Yo";
            }
            if (timeInFrames == 540)
            {
                displayText.text = "What Is You";
            }
            if (timeInFrames == 555)
            {
                displayText.text = "What Is Your";
            }
            if (timeInFrames == 570)
            {
                displayText.text = "What Is Your ";
            }
            if (timeInFrames == 585)
            {
                displayText.text = "What Is Your N";
            }
            if (timeInFrames == 600)
            {
                displayText.text = "What Is Your Na";
            }
            if (timeInFrames == 615)
            {
                displayText.text = "What Is Your Nam";
            }
            if (timeInFrames == 630)
            {
                displayText.text = "What Is Your Name";
            }
            #endregion

            #region nameReady times
            if (timeInFrames > 645 && timeInFrames < 650)
            {
                nameReady = true;
            }
            if (timeInFrames < 645)
            {
                nameReady = false;
            }
            #endregion

            //Debug.Log(timeInFrames);
        }

        void OnGUI()
        {
            #region name set up
            if (nameReady)
            {
                displayText.text = "What Is Your Name?";
                skipText.text = "";
                GUI.SetNextControlName("name");
                nameInput = GUI.TextField(new Rect(335, 300, 200, 20), nameInput, 9);
                playerName = nameInput;
                skippable = false;
            }

            Event e = Event.current;


            if (GUI.GetNameOfFocusedControl() == "name" && e.keyCode == KeyCode.Return)
            {
                nameQuestion = true;
            }


            if (nameQuestion)
            {
                displayText.text = "So your name is " + PlayerPrefs.GetString("Text Field", playerName) + "? Is that the name you want?";

                nameReady = false;

                yesButt.SetActive(true);
                noButt.SetActive(true);
            }

            #endregion

            #region choice (old code)

            /*if (startChoice)
            {
                GUI.SetNextControlName("choice");
                choice = GUI.TextField(new Rect(335, 300, 200, 20), choice, 3);
            }

            // if yes
            if ((GUI.GetNameOfFocusedControl() == "choice" && choice == "yes" && e.keyCode == KeyCode.Return && !nameReady) || (GUI.GetNameOfFocusedControl() == "choice" && e.keyCode == KeyCode.Return && choice == "Yes" && !nameReady))
            {
                ChoiceYes = true;
                naming = false;
            }

            // if no
            //        if ((GUI.GetNameOfFocusedControl() == "choice" && choice == "no" && e.keyCode == KeyCode.Return) || (GUI.GetNameOfFocusedControl() == "choice" && e.keyCode == KeyCode.Return && choice == "No"))
            if ((GUI.GetNameOfFocusedControl() == "choice" && choice == "no") || (GUI.GetNameOfFocusedControl() == "choice" && e.keyCode == KeyCode.Return && choice == "No"))
            {
                Debug.Log("NONONONNONONNOONNONNONONONONONONO");
                choice = "";
                ChoiceNo = true;
                startChoice = false;
            }
            // if ass
            if (GUI.GetNameOfFocusedControl() == "choice" && choice == "ass" && e.keyCode == KeyCode.Return && !nameReady || GUI.GetNameOfFocusedControl() == "choice" && e.keyCode == KeyCode.Return && choice == "Ass" && !nameReady)
            {
                ChoiceAss = true;
                naming = false;
            }*/

            #endregion

            if (playerClass)
            {
                displayText.text = "What classes you want in yo party dawg?";
                setUpActive = true;
            }
        }

        public void YesButtonPressed()
        {
            nameQuestion = false;
            playerClass = true;
            yesButt.SetActive(false);
            noButt.SetActive(false);
        }

        public void NoButtonPressed()
        {
            nameQuestion = false;
            nameReady = true;
            yesButt.SetActive(false);
            noButt.SetActive(false);
        }
    }
}
