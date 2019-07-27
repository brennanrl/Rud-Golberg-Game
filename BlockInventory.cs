using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockInventory : MonoBehaviour
{
    [SerializeField]
    private Image invIcon;
    [SerializeField]
    private Text invText;

    private BlockSystem blockSys;
    private BuildSystem buildSys;

    private int selectedBlockID = 0;

    private void Awake()
    {
        blockSys = GetComponent<BlockSystem>();
        buildSys = GetComponent<BuildSystem>();

        ToggleInv(false);
    }

    public void ToggleInv(bool invUp)
    {
        if (invUp)
        {
            invIcon.gameObject.SetActive(true);
            UpdateGUI();
        }
        else
        {
            invIcon.gameObject.SetActive(false);
        }                                              
    }

    public bool CheckInvEmpty()
    {
        bool isEmpty = true;

        for (int i = 0; i < blockSys.allBlocks.Length; i++)
        {
            if (blockSys.allBlocks[i].amtInInv > 0)
            {
                isEmpty = false;
            }
        }

        return isEmpty;
    }

    public void AddToInv(string blockName, int amtToAdd)
    {
        for (int i = 0; i < blockSys.allBlocks.Length; i++)
        {
            if (blockSys.allBlocks[i] != null)
            {
                if (blockSys.allBlocks[i].blockName == blockName)
                {
                    blockSys.allBlocks[i].amtInInv += amtToAdd;
                    UpdateGUI();
                    return;

                }
            }
        }
    }

    public int SelectHeldBlock(float dir)
    {
        if (dir > 0)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }

        selectedBlockID += Mathf.RoundToInt(dir);

        if (selectedBlockID >= blockSys.allBlocks.Length)
        {
            selectedBlockID = 0;
        }
        else if (selectedBlockID < 0)
        {
            selectedBlockID = blockSys.allBlocks.Length - 1;
        }

        if (blockSys.allBlocks[selectedBlockID].amtInInv == 0)
        {
            return -1;
        }
        else
        {
            return selectedBlockID;
        }
    }

    public void UpdateGUI()
    {
        if (invIcon.gameObject.activeInHierarchy)
        {
            invIcon.sprite = buildSys.currentBlock.blockSprite;
            invText.text = buildSys.currentBlock.blockName + " x " + blockSys.allBlocks[buildSys.currentBlockID].amtInInv;

        }
    }
}
