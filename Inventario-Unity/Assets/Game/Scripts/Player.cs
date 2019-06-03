using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject inv;
    Inventory inventory;
    GameObject canvas;
    private bool openInventory;
    public int level;
    public float rayDistance;
    void Start()
    {
        openInventory = false;
        rayDistance = 200f;
        inventory = inv.GetComponent<Inventory>();
        canvas = GameObject.Find("Canvas");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            openInventory = !openInventory;
        }

        if (openInventory)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Grab();
        }
    }

    public void Grab()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Item"))
            {
                if (inventory.AddItem(hit.collider.gameObject.GetComponent<Item>()))
                {
                    hit.collider.gameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("Inventory full");
                }
            }
        }
    }

    public void Drop(GameObject item)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (inventory.RemoveItem(hit.collider.gameObject.GetComponent<Item>()))
            {
                Debug.Log("Item removed from inventory successfully");
            }
            else
            {
                Debug.Log("Your inventory is empty");
            }
        }
    }
}
