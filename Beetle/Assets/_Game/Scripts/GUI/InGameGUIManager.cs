using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameGUIManager : MonoBehaviour
{
    [SerializeField] private CraftingMenuUI craftingMenuUi;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            ToggleCraftingMenu();
        }
    }

    public void ToggleCraftingMenu()
    {
        craftingMenuUi.gameObject.SetActive(!craftingMenuUi.gameObject.activeSelf);
    }
}
