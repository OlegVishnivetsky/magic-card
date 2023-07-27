using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardSortingDropdownController : MonoBehaviour
{
    [Header("DROPDOWN COMPONENTS")]
    [SerializeField] private TMP_Dropdown sortTypeDropdown;
    [SerializeField] private TMP_Dropdown sortingOrderTypeDropdown;

    [Header("SORT PARAMETERS")]
    [SerializeField] private SortType sortType;
    [SerializeField] private SortingOrderType sortingOrderType;

    [Header("OTHER COMPONENTS")]
    [SerializeField] private EditDeckCardsZone editDeckCardsZone;

    private void Start()
    {
        SetUpDowpdownMenus();

        sortTypeDropdown.onValueChanged.AddListener(SortTypeDropdown_OnValueChanged);
        sortingOrderTypeDropdown.onValueChanged.AddListener(SortingOrderTypeDropdown_OnValueChanged);
    }

    private void SetUpDowpdownMenus()
    {
        sortTypeDropdown.ClearOptions();
        sortTypeDropdown.AddOptions(new List<string>() { "By Manacost", "By Rarity" });
        sortTypeDropdown.value = (int)sortType;

        sortingOrderTypeDropdown.ClearOptions();
        sortingOrderTypeDropdown.AddOptions(new List<string>() { "Descending", "Ascending" });
        sortingOrderTypeDropdown.value = (int)sortingOrderType;
    }

    private void SortTypeDropdown_OnValueChanged(int value)
    {
        editDeckCardsZone.SetSortTypeAndUpdateCardsSort((SortType)value);
    }

    private void SortingOrderTypeDropdown_OnValueChanged(int value)
    {
        editDeckCardsZone.SetSortingOrderAndUpdateCardsSort((SortingOrderType)value);
    }
}