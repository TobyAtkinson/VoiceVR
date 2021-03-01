using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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

    private void Start()
    {
        whereToBe = artilleryGroup.transform.position;
        actions.Add("right", MoveRight);
        actions.Add("left", MoveLeft);
        actions.Add("power up", PowerUp);
        actions.Add("power down", PowerDown);
        actions.Add("fire", Fire);

        actions.Add("spawn wave", SpawnWave);


        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }
    
    private void RecognizedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Update()
    {
        artilleryGroup.transform.position = Vector3.Lerp(artilleryGroup.transform.position, whereToBe, 0.6f * Time.deltaTime);
    }

    private void SpawnWave()
    {
        wave2.SetActive(true);
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

    private void Fire()
    {
        StartCoroutine(FireDelay());
    }

    IEnumerator FireDelay()
    {
        if(vertical == -1)
        {
            muzzleFlashes[0].SetActive(true);
        }
        else if (vertical == 0)
        {
            muzzleFlashes[1].SetActive(true);
        }
        else
        {
            muzzleFlashes[2].SetActive(true);
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
