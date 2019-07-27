using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using System;
using System.Threading;

public class FinalScore : MonoBehaviour
{
    public int score = 0;
    private PlayerMove pMove;
    private Countdown ctdn;
    public Text fScore;
    private BlockSystem blocksyst;
    public int numberBlocks = 0;
    public GameObject[] arrayBlock;
    public GameObject[] arrayTeleport;
    public GameObject[] arrayBlow;
    

    private void Awake ()
    {
        pMove = GetComponent<PlayerMove>();
        ctdn = GetComponent<Countdown>();
        blocksyst = GetComponent<BlockSystem>();
    }

    void Update ()
    {
        arrayBlock = GameObject.FindGameObjectsWithTag("PlacedBlock");
        arrayTeleport = GameObject.FindGameObjectsWithTag("Teleport");
        arrayBlow = GameObject.FindGameObjectsWithTag("Blow");
        numberBlocks = (3 * arrayBlock.Length) + (10 * arrayBlow.Length);
        score = ctdn.timeLeft + numberBlocks;
        fScore.text = ("Score: " + "" + score);
        
    }
}
