public abstract class CardTemplate {

    int HP;
    int ST;

    public abstract void BattleStartEffect();
    public abstract void BattleEndEffect();
    public abstract void FieldEffect();
    public abstract void TurnEffect();
}
