using System;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    private List<StoreItem> itemList;

    void Start()
    {
        DisplayAllItems();
    }

    private void DisplayAllItems()
    {
        // TODO
    }
}
