using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject item;
    public GameObject uniqueItem;
    public GameObject player;
    public List<Sprite> weaponsSprites;
    public List<Sprite> armorSprites;
    public List<Sprite> consumableSprites;
    public List<UniqueItem> uniquesList;
    public float uniqueChances = 0.25f;
    public List<Item> itemsCreatedList;
    private Player playerScript;
    private int playerLvl;
    private bool unique;
    private Rigidbody itemRB;
    private Item itemStats;
    private Item uniqueItemStats;
    private int maxStat;
    private int mediumStat;
    private int minStat;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<Player>();
        maxStat = 100;
        mediumStat = 60;
        minStat = 30;
        itemRB = item.GetComponent<Rigidbody>();
        itemStats = item.GetComponent<Item>();
        uniqueItemStats = uniqueItem.GetComponent<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        playerLvl = playerScript.level;
    }


    private void OnMouseDown()
    {
        Item itemCreated=CreateItem();
        itemsCreatedList.Add(itemCreated);
    }

    public Item CreateItem()
    {
        if ((Random.Range(0f, 1f)) <= uniqueChances)
        {
            unique = true;
        }
        else
        {
            unique = false;
        }

        if (unique)
        {
            Instantiate(uniqueItem, transform.position, transform.rotation);
            itemRB.AddForce(Vector3.up * 2f);
            SetUniqueItem(uniqueItemStats);
            unique = false;
            return uniqueItemStats;
        }
        else
        {
            Instantiate(item, transform.position, transform.rotation);
            itemRB.AddForce(Vector3.up * 2f);
            SetItemState(itemStats);
            return itemStats;
        }

    }

    public void SetItemState(Item item)
    {
        int stat=0;
        int stat1 = 0;
        int stat2 = 0;
        int rndImgArmor = Random.Range(0, armorSprites.Count);
        int rndImgWeapon = Random.Range(0, weaponsSprites.Count);
        int rndImgConsumable = Random.Range(0, consumableSprites.Count);
        int rndType = Random.Range(0, (int)Item.Type.Last);
        int rndSubType;

        if (playerLvl<=10)
        {
            stat = Random.Range(0,minStat);
            stat1 = Random.Range(0, minStat);
            stat2 = Random.Range(0, minStat);
        }
        else if (playerLvl>10&&playerLvl<=20)
        {
            stat = Random.Range(minStat, mediumStat);
            stat1 = Random.Range(minStat, mediumStat);
            stat2 = Random.Range(minStat, mediumStat);
        }
        else if (playerLvl>20)
        {
            stat = Random.Range(mediumStat, maxStat);
            stat1 = Random.Range(mediumStat, maxStat);
            stat2 = Random.Range(mediumStat, maxStat);
        }

        if (rndType==(int)Item.Type.Armor)
        {
            rndSubType = Random.Range(4, (int)Item.SubType.Last);
            item.image = armorSprites[rndImgArmor];
            item.itemName = "Armor " + Random.Range(0, maxStat);
            item.type = (Item.Type)rndType;
            item.subType = (Item.SubType)rndSubType;
            item.weight = stat;
            item.durability = stat1;
            item.defense = stat2;
            item.attack = 0;
        }
        else if (rndType == (int)Item.Type.Weapon)
        {
            rndSubType = Random.Range(1, 4);
            item.image = weaponsSprites[rndImgWeapon];
            item.itemName = "Weapon " + Random.Range(0, maxStat);
            item.type = (Item.Type)rndType;
            item.subType = (Item.SubType)rndSubType;
            item.weight = stat;
            item.durability = stat1;
            item.attack = stat2;
            item.defense = 0;
        }
        else if(rndType == (int)Item.Type.Consumable)
        {
            rndSubType = (int)Item.SubType.None;
            item.image = consumableSprites[rndImgConsumable];
            item.itemName = "Item " + Random.Range(0, maxStat);
            item.type = (Item.Type)rndType;
            item.subType = (Item.SubType)rndSubType;
            item.weight = stat;
            item.durability = stat2;
            item.attack = 0;
            item.defense = 0;
        }
        
    }

    public void SetUniqueItem(Item item)
    {
        int rnd = Random.Range(0, uniquesList.Count);

        item.type = uniquesList[rnd].type;
        item.subType= uniquesList[rnd].subType;
        item.image = uniquesList[rnd].image;
        item.itemName = uniquesList[rnd].itemName;
        item.weight = uniquesList[rnd].weight;
        item.durability = uniquesList[rnd].durability;
        item.attack = uniquesList[rnd].attack;
        item.defense = uniquesList[rnd].defense;
    }
}
