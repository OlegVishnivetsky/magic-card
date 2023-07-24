using System;
using System.Collections.Generic;

public class SortHelper
{
    public void SortCardListBySortType(List<CardDetailsSO> cards, SortType sortType, SortingOrderType sortingOrderType)
    {
        switch (sortType)
        {
            case SortType.ByManaCost:
                SortAndDefineSortOrdering(cards, SortByManaCost(), sortingOrderType);
                break;

            case SortType.ByRarity:
                SortAndDefineSortOrdering(cards, SortByRarity(), sortingOrderType);
                break;
        }
    }

    private void SortAndDefineSortOrdering(List<CardDetailsSO> cards, Comparison<CardDetailsSO> comparison,
        SortingOrderType sortingOrderType)
    {
        if (sortingOrderType == SortingOrderType.Ascending)
        {
            cards.Sort(comparison);
        }
        else if (sortingOrderType == SortingOrderType.Descending)
        {
            cards.Sort(comparison);
            cards.Reverse();
        }
    }

    private static Comparison<CardDetailsSO> SortByManaCost()
    {
        return (card1, card2) => card1.manaCost.CompareTo(card2.manaCost);
    }

    private static Comparison<CardDetailsSO> SortByRarity()
    {
        return (card1, card2) => card1.cardTier.CompareTo(card2.cardTier);
    }
}