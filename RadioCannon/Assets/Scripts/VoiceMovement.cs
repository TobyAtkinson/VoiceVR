using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class VoiceMovement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    [SerializeField]
    private GameObject artilleryGroup;

    [SerializeField]
    private GameObject artilerryBarrelGroup;

    [SerializeField]
    private GameObject whereToHit;

    [SerializeField]
    private GameObject explosion;

    private int horizontal = 0;

    private int vertical = 0;

    private Vector3 whereToBe;

    private float time = 0;


    public GameObject[] barrelGroups;

    public GameObject wave2;

    public GameObject[] muzzleFlashes;

    public AudioSource[] sounds;

    [SerializeField]
    private int menuSteps = 0;

    [SerializeField]
    private GameObject[] menuObjects;

    [SerializeField]
    private Text[] menuTexts;


    private float LeftCommand = 1.0f;
    public Text[] leftTexts;

    private float rightCommand = 1.0f;
    public Text[] rightTexts;

    private float upCommand = 1.0f;
    public Text[] upTexts;

    private float downCommand = 1.0f;
    public Text[] downTexts;

    private float fireCommand = 1.0f;
    public Text[] fireTexts;

    public int tanksLeft = 0;

    public int wave = 0;

    public GameObject[] tankGroups;


    private void Start()
    {
        whereToBe = artilleryGroup.transform.position;
        //actions.Add("right", MoveRight);
        //actions.Add("left", MoveLeft);
        //actions.Add("power up", PowerUp);
        //actions.Add("power down", PowerDown);
       // actions.Add("fire", CannonFire);
        //actions.Add("spawn wave", SpawnWave);

        //left
        actions.Add("left", Left);
        actions.Add("apple", Apple);
        actions.Add("butter", Butter);
        actions.Add("charlie", Charlie);

        // right
        actions.Add("right", Right);
        actions.Add("duff", Duff);
        actions.Add("edward", Edward);
        actions.Add("freddy", Freddy);

        // up
        actions.Add("up", Up);
        actions.Add("harry", Harry);
        actions.Add("ink", Ink);
        actions.Add("johnnie", Johnnie);

        //down
        actions.Add("down", Down);
        actions.Add("king", King);
        actions.Add("london", London);
        actions.Add("monkey", Monkey);

        //fire
        actions.Add("fire", Fire);
        actions.Add("nuts", Nuts);
        actions.Add("orange", Orange);
        actions.Add("robert", Robert);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }


    public void TankDown()
    {
        tanksLeft--;
        if(tanksLeft == 0)
        {
            if(wave == 1)
            {
                // spawn wave 2
                tanksLeft = 3;
                wave = 2;
                tankGroups[1].SetActive(false);
                tankGroups[2].SetActive(true);
                menuTexts[5].text = "Wave 2 \n How to make enemy retreat: Ignore red tanks, Take down 3 Faster Yellow Tanks \n You will lose if:  2 or more tanks reach front line";
            }
            else if (wave == 2)
            {
                wave = 3;
                // spawn wave 2
                //tankGroups[2].SetActive(true);
                tankGroups[2].SetActive(false);
                menuTexts[5].text = "Wave 3 \n How to make enemy retreat: something, \n You will lose if: something";
            }
        }
    }


    //left 
    IEnumerator LeftDelay(int numb)
    {
        yield return new WaitForSeconds(0.5f);
        if(numb == 1)
        {
            leftTexts[1].color = new Color32(250, 109, 53, 255);
            leftTexts[1].text = "Charlie";
            leftTexts[2].color = new Color32(250, 109, 53, 255);
            leftTexts[2].text = "Apple";
            leftTexts[3].color = new Color32(250, 109, 53, 255);
            LeftCommand = 2.0f;
        }
        else if(numb == 2)
        {
            leftTexts[1].color = new Color32(250, 109, 53, 255);
            leftTexts[1].text = "Butter";
            leftTexts[2].color = new Color32(250, 109, 53, 255);
            leftTexts[2].text = "Charlie";
            leftTexts[3].color = new Color32(250, 109, 53, 255);
            LeftCommand = 3.0f;
        }
        else if (numb == 3)
        {
            leftTexts[1].color = new Color32(250, 109, 53, 255);
            leftTexts[1].text = "Apple";
            leftTexts[2].color = new Color32(250, 109, 53, 255);
            leftTexts[2].text = "Butter";
            leftTexts[3].color = new Color32(250, 109, 53, 255);
            LeftCommand = 1.0f;
        }
        MoveLeft();
    }
    private void Left()
    {
        if (LeftCommand == 1.2f)
        {
            LeftCommand = 1.3f;
            leftTexts[3].color = Color.green;
            StartCoroutine(LeftDelay(1));
        }
        if (LeftCommand == 2.2f)
        {
            LeftCommand = 2.3f;
            leftTexts[3].color = Color.green;
            StartCoroutine(LeftDelay(2));
        }
        if (LeftCommand == 3.2f)
        {
            LeftCommand = 3.3f;
            leftTexts[3].color = Color.green;
            StartCoroutine(LeftDelay(3));
        }
    }
    private void Apple()
    {
        if(menuSteps == 0)
        {
            menuTexts[0].color = Color.green;
            menuSteps = 1;
        }
        else if(menuSteps == 5)
        {
            if(LeftCommand == 1.0f)
            {
                LeftCommand = 1.1f;
                leftTexts[1].color = Color.green;
            }
            if (LeftCommand == 2.1f)
            {
                LeftCommand = 2.2f;
                leftTexts[2].color = Color.green;
            }
        }
    }
    private void Butter()
    {
        if (menuSteps == 1)
        {
            menuTexts[1].color = Color.green;
            StartCoroutine(Delay1());
        }
        else if (menuSteps == 5)
        {
            if (LeftCommand == 1.1f)
            {
                LeftCommand = 1.2f;
                leftTexts[2].color = Color.green;
            }
            if (LeftCommand == 3.0f)
            {
                LeftCommand = 3.1f;
                leftTexts[1].color = Color.green;
            }
        }
    }
    private void Charlie()
    {
        if (menuSteps == 2)
        {
            menuTexts[2].color = Color.green;
            menuSteps = 3;
        }
        else if (menuSteps == 5)
        {
            if (LeftCommand == 2.0f)
            {
                LeftCommand = 2.1f;
                leftTexts[1].color = Color.green;
            }
            if (LeftCommand == 3.1f)
            {
                LeftCommand = 3.2f;
                leftTexts[2].color = Color.green;
            }
        }
    }

    // right
    IEnumerator RightDelay(int numb)
    {
        yield return new WaitForSeconds(0.5f);
        if (numb == 1)
        {
            rightTexts[1].color = new Color32(250, 109, 53, 255);
            rightTexts[1].text = "Freddy";
            rightTexts[2].color = new Color32(250, 109, 53, 255);
            rightTexts[2].text = "Duff";
            rightTexts[3].color = new Color32(250, 109, 53, 255);
            rightCommand = 2.0f;
        }
        else if (numb == 2)
        {
            rightTexts[1].color = new Color32(250, 109, 53, 255);
            rightTexts[1].text = "Edward";
            rightTexts[2].color = new Color32(250, 109, 53, 255);
            rightTexts[2].text = "Freddy";
            rightTexts[3].color = new Color32(250, 109, 53, 255);
            rightCommand = 3.0f;
        }
        else if (numb == 3)
        {
            rightTexts[1].color = new Color32(250, 109, 53, 255);
            rightTexts[1].text = "Duff";
            rightTexts[2].color = new Color32(250, 109, 53, 255);
            rightTexts[2].text = "Edward";
            rightTexts[3].color = new Color32(250, 109, 53, 255);
            rightCommand = 1.0f;
        }
        MoveRight();
    }
    private void Right()
    {
        if (rightCommand == 1.2f)
        {
            rightCommand = 1.3f;
            rightTexts[3].color = Color.green;
            StartCoroutine(RightDelay(1));
        }
        if (rightCommand == 2.2f)
        {
            rightCommand = 2.3f;
            rightTexts[3].color = Color.green;
            StartCoroutine(RightDelay(2));
        }
        if (rightCommand == 3.2f)
        {
            rightCommand = 3.3f;
            rightTexts[3].color = Color.green;
            StartCoroutine(RightDelay(3));
        }
    }
    private void Duff()
    {
        if (menuSteps == 3)
        {
            menuTexts[3].color = Color.green;
            menuSteps = 4;
        }
        else if (menuSteps == 5)
        {
            if (rightCommand == 1.0f)
            {
                rightCommand = 1.1f;
                rightTexts[1].color = Color.green;
            }
            if (rightCommand == 2.1f)
            {
                rightCommand = 2.2f;
                rightTexts[2].color = Color.green;
            }
        }
    }
    private void Edward()
    {
        if (rightCommand == 1.1f)
        {
            rightCommand = 1.2f;
            rightTexts[2].color = Color.green;
        }
        if (rightCommand == 3.0f)
        {
            rightCommand = 3.1f;
            rightTexts[1].color = Color.green;
        }
    }
    private void Freddy()
    {
        if (menuSteps == 4)
        {
            menuTexts[4].color = Color.green;
            StartCoroutine(Delay2());
        }
        else if (menuSteps == 5)
        {
            if (rightCommand == 2.0f)
            {
                rightCommand = 2.1f;
                rightTexts[1].color = Color.green;
            }
            if (rightCommand == 3.1f)
            {
                rightCommand = 3.2f;
                rightTexts[2].color = Color.green;
            }
        }
    }

    // up
    IEnumerator UpDelay(int numb)
    {
        yield return new WaitForSeconds(0.5f);
        if (numb == 1)
        {
            upTexts[1].color = new Color32(250, 109, 53, 255);
            upTexts[1].text = "Johnnie";
            upTexts[2].color = new Color32(250, 109, 53, 255);
            upTexts[2].text = "Harry";
            upTexts[3].color = new Color32(250, 109, 53, 255);
            upCommand = 2.0f;
        }
        else if (numb == 2)
        {
            upTexts[1].color = new Color32(250, 109, 53, 255);
            upTexts[1].text = "Ink";
            upTexts[2].color = new Color32(250, 109, 53, 255);
            upTexts[2].text = "Johnnie";
            upTexts[3].color = new Color32(250, 109, 53, 255);
            upCommand = 3.0f;
        }
        else if (numb == 3)
        {
            upTexts[1].color = new Color32(250, 109, 53, 255);
            upTexts[1].text = "Harry";
            upTexts[2].color = new Color32(250, 109, 53, 255);
            upTexts[2].text = "Ink";
            upTexts[3].color = new Color32(250, 109, 53, 255);
            upCommand = 1.0f;
        }
        PowerUp();
    }
    private void Up()
    {
        if (upCommand == 1.2f)
        {
            upCommand = 1.3f;
            upTexts[3].color = Color.green;
            StartCoroutine(UpDelay(1));
        }
        if (upCommand == 2.2f)
        {
            upCommand = 2.3f;
            upTexts[3].color = Color.green;
            StartCoroutine(UpDelay(2));
        }
        if (upCommand == 3.2f)
        {
            upCommand = 3.3f;
            upTexts[3].color = Color.green;
            StartCoroutine(UpDelay(3));
        }
    }
    private void Harry()
    {
        if (upCommand == 1.0f)
        {
            upCommand = 1.1f;
            upTexts[1].color = Color.green;
        }
        if (upCommand == 2.1f)
        {
            upCommand = 2.2f;
            upTexts[2].color = Color.green;
        }
    }
    private void Ink()
    {
        if (upCommand == 1.1f)
        {
            upCommand = 1.2f;
            upTexts[2].color = Color.green;
        }
        if (upCommand == 3.0f)
        {
            upCommand = 3.1f;
            upTexts[1].color = Color.green;
        }
    }

    private void Johnnie()
    {
        if (upCommand == 2.0f)
        {
            upCommand = 2.1f;
            upTexts[1].color = Color.green;
        }
        if (upCommand == 3.1f)
        {
            upCommand = 3.2f;
            upTexts[2].color = Color.green;
        }
    }

    //down
    IEnumerator DownDelay(int numb)
    {
        yield return new WaitForSeconds(0.5f);
        if (numb == 1)
        {
            downTexts[1].color = new Color32(250, 109, 53, 255);
            downTexts[1].text = "Monkey";
            downTexts[2].color = new Color32(250, 109, 53, 255);
            downTexts[2].text = "King";
            downTexts[3].color = new Color32(250, 109, 53, 255);
            downCommand = 2.0f;
        }
        else if (numb == 2)
        {
            downTexts[1].color = new Color32(250, 109, 53, 255);
            downTexts[1].text = "London";
            downTexts[2].color = new Color32(250, 109, 53, 255);
            downTexts[2].text = "Monkey";
            downTexts[3].color = new Color32(250, 109, 53, 255);
            downCommand = 3.0f;
        }
        else if (numb == 3)
        {
            downTexts[1].color = new Color32(250, 109, 53, 255);
            downTexts[1].text = "King";
            downTexts[2].color = new Color32(250, 109, 53, 255);
            downTexts[2].text = "London";
            downTexts[3].color = new Color32(250, 109, 53, 255);
            downCommand = 1.0f;
        }
        PowerDown();
    }
    private void Down()
    {
        if (downCommand == 1.2f)
        {
            downCommand = 1.3f;
            downTexts[3].color = Color.green;
            StartCoroutine(DownDelay(1));
        }
        if (downCommand == 2.2f)
        {
            downCommand = 2.3f;
            downTexts[3].color = Color.green;
            StartCoroutine(DownDelay(2));
        }
        if (downCommand == 3.2f)
        {
            downCommand = 3.3f;
            downTexts[3].color = Color.green;
            StartCoroutine(DownDelay(3));
        }
    }
    private void King()
    {
        if (downCommand == 1.0f)
        {
            downCommand = 1.1f;
            downTexts[1].color = Color.green;
        }
        if (downCommand == 2.1f)
        {
            downCommand = 2.2f;
            downTexts[2].color = Color.green;
        }
    }
    private void London()
    {
        if (downCommand == 1.1f)
        {
            downCommand = 1.2f;
            downTexts[2].color = Color.green;
        }
        if (downCommand == 3.0f)
        {
            downCommand = 3.1f;
            downTexts[1].color = Color.green;
        }
    }
    private void Monkey()
    {
        if (downCommand == 2.0f)
        {
            downCommand = 2.1f;
            downTexts[1].color = Color.green;
        }
        if (downCommand == 3.1f)
        {
            downCommand = 3.2f;
            downTexts[2].color = Color.green;
        }
    }

    // fire
    IEnumerator FireDelay(int numb)
    {
        yield return new WaitForSeconds(0.5f);
        if (numb == 1)
        {
            fireTexts[1].color = new Color32(250, 109, 53, 255);
            fireTexts[1].text = "Robert";
            fireTexts[2].color = new Color32(250, 109, 53, 255);
            fireTexts[2].text = "Nuts";
            fireTexts[3].color = new Color32(250, 109, 53, 255);
            fireCommand = 2.0f;
        }
        else if (numb == 2)
        {
            fireTexts[1].color = new Color32(250, 109, 53, 255);
            fireTexts[1].text = "Orange";
            fireTexts[2].color = new Color32(250, 109, 53, 255);
            fireTexts[2].text = "Robert";
            fireTexts[3].color = new Color32(250, 109, 53, 255);
            fireCommand = 3.0f;
        }
        else if (numb == 3)
        {
            fireTexts[1].color = new Color32(250, 109, 53, 255);
            fireTexts[1].text = "Nuts";
            fireTexts[2].color = new Color32(250, 109, 53, 255);
            fireTexts[2].text = "Orange";
            fireTexts[3].color = new Color32(250, 109, 53, 255);
            fireCommand = 1.0f;
        }
        CannonFire();
    }
    private void Fire()
    {
        if (fireCommand == 1.2f)
        {
            fireCommand = 1.3f;
            fireTexts[3].color = Color.green;
            StartCoroutine(FireDelay(1));
        }
        if (fireCommand == 2.2f)
        {
            fireCommand = 2.3f;
            fireTexts[3].color = Color.green;
            StartCoroutine(FireDelay(2));
        }
        if (fireCommand == 3.2f)
        {
            fireCommand = 3.3f;
            fireTexts[3].color = Color.green;
            StartCoroutine(FireDelay(3));
        }
    }
    private void Nuts()
    {
        if (fireCommand == 1.0f)
        {
            fireCommand = 1.1f;
            fireTexts[1].color = Color.green;
        }
        if (fireCommand == 2.1f)
        {
            fireCommand = 2.2f;
            fireTexts[2].color = Color.green;
        }
    }
    private void Orange()
    {
        if (fireCommand == 1.1f)
        {
            fireCommand = 1.2f;
            fireTexts[2].color = Color.green;
        }
        if (fireCommand == 3.0f)
        {
            fireCommand = 3.1f;
            fireTexts[1].color = Color.green;
        }
    }
    private void Robert()
    {
        if (fireCommand == 2.0f)
        {
            fireCommand = 2.1f;
            fireTexts[1].color = Color.green;
        }
        if (fireCommand == 3.1f)
        {
            fireCommand = 3.2f;
            fireTexts[2].color = Color.green;
        }
    }



    IEnumerator Delay1()
    {
        yield return new WaitForSeconds(0.5f);
        menuSteps = 2;
        menuObjects[2].SetActive(true);
        menuObjects[3].SetActive(true);
        menuObjects[0].SetActive(false);
        menuObjects[1].SetActive(false);
        
    }

    IEnumerator Delay2()
    {
        yield return new WaitForSeconds(0.5f);
        menuSteps = 5;
        //menuObjects[4].SetActive(true);
        menuObjects[5].SetActive(true);
        //menuObjects[2].transform.position = new Vector3(139.9f, 2.303f, 839.748f);
        menuObjects[3].SetActive(false);


        // Game Start

        // ambience
        tankGroups[0].SetActive(true);

        // tanks 1
        tankGroups[1].SetActive(true);

        tanksLeft = 3;
        wave = 1;
    }


    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        //Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Update()
    {
        artilleryGroup.transform.position = Vector3.Lerp(artilleryGroup.transform.position, whereToBe, 0.6f * Time.deltaTime);
    }



    private void MoveRight()
    {
        if (horizontal == 0)
        {
            whereToBe.x = 20.69f;
            whereToHit.transform.position = new Vector3(26f, whereToHit.transform.position.y, whereToHit.transform.position.z);
            horizontal = 1;
            //this.transform.position = new Vector3(whereToBe.x, this.transform.position.y , this.transform.position.z);
            //time = 5;
        }
        else if(horizontal == -1)
        {
            whereToBe.x = 0f;
            whereToHit.transform.position = new Vector3(0f, whereToHit.transform.position.y, whereToHit.transform.position.z);
            horizontal = 0;
            //this.transform.position = new Vector3(whereToBe.x, this.transform.position.y, this.transform.position.z);
            //time = 5;
        }
    }

    private void MoveLeft()
    {
        if (horizontal == 1)
        {
            whereToBe.x = 0f;
            whereToHit.transform.position = new Vector3(0f, whereToHit.transform.position.y, whereToHit.transform.position.z);
            horizontal = 0;
            //this.transform.position = new Vector3(whereToBe.x, this.transform.position.y, this.transform.position.z);
            //time = 5;
        }
        else if (horizontal == 0)
        {
            whereToBe.x = -20.69f;
            whereToHit.transform.position = new Vector3(-26f, whereToHit.transform.position.y, whereToHit.transform.position.z);
            horizontal = -1;
            //this.transform.position = new Vector3(whereToBe.x, this.transform.position.y , this.transform.position.z);
            //time = 5;
        }
    }

    private void PowerUp()
    {
        if(vertical == 0)
        {
            vertical = 1;
            whereToHit.transform.position = new Vector3(whereToHit.transform.position.x, whereToHit.transform.position.y, 261f);
            barrelGroups[1].SetActive(false);
            barrelGroups[2].SetActive(true);
        }
        else if (vertical == -1)
        {
            vertical = 0;
            whereToHit.transform.position = new Vector3(whereToHit.transform.position.x, whereToHit.transform.position.y, 225f);
            barrelGroups[0].SetActive(false);
            barrelGroups[1].SetActive(true);
        }

    }

    private void PowerDown()
    {
        if (vertical == 0)
        {
            vertical = -1;
            whereToHit.transform.position = new Vector3(whereToHit.transform.position.x, whereToHit.transform.position.y, 191f);
            barrelGroups[1].SetActive(false);
            barrelGroups[0].SetActive(true);
        }
        else if (vertical == 1)
        {
            vertical = 0;
            whereToHit.transform.position = new Vector3(whereToHit.transform.position.x, whereToHit.transform.position.y, 225f);
            barrelGroups[2].SetActive(false);
            barrelGroups[1].SetActive(true);
        }
    }

    private void CannonFire()
    {
        StartCoroutine(FireDelay());
    }

    IEnumerator FireDelay()
    {


        if (vertical == -1)
        {
            muzzleFlashes[0].SetActive(true);
            sounds[0].Play();
        }
        else if (vertical == 0)
        {
            muzzleFlashes[1].SetActive(true);
            sounds[0].Play();
        }
        else
        {
            muzzleFlashes[2].SetActive(true);
            sounds[0].Play();
        }
        yield return new WaitForSeconds(0.4f);
        muzzleFlashes[2].SetActive(false);
        muzzleFlashes[1].SetActive(false);
        muzzleFlashes[0].SetActive(false);
        yield return new WaitForSeconds(0.4f);
        Instantiate(explosion, whereToHit.transform.position, Quaternion.identity);
    }






    /*
    private void Forward()
    {
        transform.Translate(1, 0, 0);
    }

    private void Back()
    {
        transform.Translate(-1, 0, 0);
    }

    private void Up()
    {
        transform.Translate(0, 1, 0);
    }

    private void Down()
    {
        transform.Translate(0, -1, 0);
    }
    */
}
