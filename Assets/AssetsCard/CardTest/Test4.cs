using System;

public class Test4 : CardTemplate {

    int HP = 40; int ST = 40;

    public override void BattleStartEffect() {
        Random rand = new Random();
        HP = rand.Next(10, 70);
        ST = rand.Next(10, 70);
    }

    public override void BattleEndEffect() {
    }

    public override void FieldEffect() {
    }

    public override void TurnEffect() {
    }
}
