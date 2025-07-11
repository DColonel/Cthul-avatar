using System;

public class Test2 : CardTemplate {

    int HP = 60; int ST = 0;

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
