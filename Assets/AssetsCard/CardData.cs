using Unity.VisualScripting;
using UnityEngine;
using static CardData;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]

public class CardData : ScriptableObject {

    public enum CardType {
        Creature,Sorcery,Item
    }

    public string cardName;
    public CardType cardType;
    public Sprite artworkCard;
    public Sprite artworkField;
    public int cost;

    public int HP;
    public int ST;
}
