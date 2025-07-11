using System;

public class Test3 : CardTemplate {

    int HP = 20; int ST = 50;

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
