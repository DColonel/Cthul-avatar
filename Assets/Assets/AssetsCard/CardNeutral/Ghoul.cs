public class Ghoul : CardTemplate {

    int HP = 40; int ST = 30;

    public override void BattleStartEffect() {
    }

    public override void BattleEndEffect() {
        HP = 40;
    }

    public override void FieldEffect() {
    }

    public override void TurnEffect() {
    }
}