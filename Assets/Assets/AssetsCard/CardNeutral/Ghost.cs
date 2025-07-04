using System;

public class Ghost : CardTemplate {

    int HP = 30; int ST = 20;

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