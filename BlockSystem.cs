// System required for [Serializable] attribute.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSystem : MonoBehaviour
{

    // Array we expose to inspector / editor, use this instead of the old arrays to define block types.
    [SerializeField]
    private BlockType[] allBlockTypes;

    // Array to store all blocks created in Awake()
    [HideInInspector]
    public Block[] allBlocks;

    private void Awake()
    {
        // Initialise allBlocks array.
        allBlocks = new Block[allBlockTypes.Length];

        // For loops to populate main allBlocks array.
        for (int i = 0; i < allBlockTypes.Length; i++)
        {
            // Instead of referencing multiple arrays, we just create a new BlockType object and get values from that.
            BlockType newBlockType = allBlockTypes[i];
            allBlocks[i] = new Block(i, newBlockType.blockName, newBlockType.blockType, newBlockType.blockSprite, newBlockType.blockIsSolid);
            Debug.Log("Solid block: allBlocks[" + i + "] = " + newBlockType.blockName);
        }
    }

    private void Update()
    {
        // this will spawn 1 of each block into map on t key.  A better way to do this would be if it is in the first minute of game/start of game, then add 5 of each block or something
        if (Input.GetKeyDown("t"))
        {
            for (int i = 0; i < allBlocks.Length; i++)
            {
                GameObject newPickup = new GameObject(allBlocks[i].blockName, typeof(SpriteRenderer));
                newPickup.transform.localScale = new Vector3(0.8f, 0.8f, 1);
                newPickup.GetComponent<SpriteRenderer>().sprite = allBlocks[i].blockSprite;
                newPickup.AddComponent<BoxCollider2D>();
                newPickup.AddComponent<Rigidbody2D>();
                newPickup.tag = "Pickup";
                newPickup.transform.position = Vector2.zero + (Vector2.up * (i + 4));
            }

        }
    }
}

// We still use the Block class to store the final Block type data.
public class Block
{
    public int blockID;
    public string blockName;
    public string blockType;
    public Sprite blockSprite;
    public bool isSolid;
    public int amtInInv;

    public Block(int id, string myName, string myType, Sprite mySprite, bool amISolid)
    {
        blockID = id;
        blockName = myName;
        blockType = myType;
        blockSprite = mySprite;
        isSolid = amISolid;
        amtInInv = 0;
    }
}

// Custom struct for Block type.
[Serializable]
public struct BlockType
{
    // Main, differing variables for each block type.
    public string blockName;
    public string blockType;
    public Sprite blockSprite;
    public bool blockIsSolid;
    
}