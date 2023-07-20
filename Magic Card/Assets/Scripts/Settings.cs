using UnityEngine;

public static class Settings
{
    public const int startingAmountOfRivalsHealth = 30;
    public const int startingAmountOfRivalsMana = 9;
    public const int maxAmountOfRivalsMana = 10;

    public const int startingNumberOfCards = 6;

    public const int maxNumberOfPlacedCards = 6;
    public const int maxNumberOfCardsInHand = 6;

    public const float cardStandartYPosition = -600f;
    public const float cardMouseEnterYPosition = -365f;

    public static Color cardSTierColor = new Color(246f, 224f, 0f);
    public static Color cardATierColor = new Color(95f, 246f, 0f);
    public static Color cardBTierColor = new Color(0f, 121f, 246f);
    public static Color cardCTierColor = new Color(246f, 0f, 246f);
    public static Color cardDTierColor = new Color(145f, 145f, 145f);
}