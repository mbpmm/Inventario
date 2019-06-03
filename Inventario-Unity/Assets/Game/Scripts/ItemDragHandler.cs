using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject grid;
    Vector3 initialLPos;
    Vector3 initialPos;
    private RectTransform gridLay;
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(gridLay);
    }

    // Start is called before the first frame update
    void Awake()
    {
        initialPos = transform.position;
        gridLay = grid.GetComponent<RectTransform>();
        Debug.Log(initialPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
