using NUnit.Framework;
using Tales_of_laponian_front.Characters.Classes;
using Tales_of_laponian_front.IA_enemy;
namespace TEST
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Assassin_no_Test()
        {
            Dummy dummy = new Dummy(1000, 0, 0, 0, 0, 0, 1, 0);
            Assassin assassin = new Assassin(100, 20, 0, 10, 5, 5, 2, 0);

            //Poison_slash [TESTE]
            Assert.AreEqual(assassin.Poison_slash(dummy), 956);
            
            dummy.gain_HP(999);

            //Stealth [TESTE]
            assassin.Stealth();
            Assert.AreEqual(assassin.atkbasic(dummy, 0),980);
            
            dummy.gain_HP(999);

            //Studds [TESTE]
            Assert.AreEqual(assassin.Studds(dummy), 953);

            dummy.gain_HP(999);

            //Stab [TESTE]
            Assert.AreEqual(assassin.Stab(1, dummy), 924);
        }
        [Test]
        public void Swordsman_no_Test()
        {
            Dummy dummy = new Dummy(1000, 0, 0, 0, 0, 0, 1, 0);
            Swordsman swordsman = new Swordsman(150, 20, 0, 15, 5, 10, 2, 0);

            //Fatal_Slash [TESTE]
            Assert.AreEqual(swordsman.Fatal_Slash(dummy), 956);

            dummy.gain_HP(999);

            //Bleeding_Strike [TESTE]
            Assert.AreEqual(swordsman.Bleeding_Strike(dummy), 980);

            dummy.gain_HP(999);

            //Blink_Slash
            Assert.AreEqual(swordsman.Blink_Slash(dummy), 953);

        }
        [Test]
        public void Mage_no_Test()
        {
            Dummy dummy = new Dummy(1000, 0, 0, 0, 0, 0, 1, 0);
            Mage mago = new Mage(75, 0, 100, 2, 4, 15, 2, 0);

            //Fire_shot [TESTE]
            Assert.AreEqual(mago.Fire_shot(dummy), 956);

            dummy.gain_HP(999);

            //Eruption [TESTE]
            Assert.AreEqual(mago.Eruption(dummy), 980);

            dummy.gain_HP(999);

            Assert.AreEqual(mago.Fireball(dummy), 953);

        }
        [Test]
        public void Necromancer_no_Test()
        {
            Dummy dummy = new Dummy(1000, 0, 0, 0, 100, 0, 1, 0);
            Necromancer necro = new Necromancer(80, 0, 150, 2, 6, 12, 2, 0);

            //Life_consumption [TESTE]
            Assert.AreEqual(necro.Life_consumption(dummy), 956);

            dummy.gain_HP(999);

            //Execute [TESTE]
            Assert.AreEqual(necro.Execute(dummy), 980);

            dummy.gain_HP(999);

            Assert.AreEqual(necro.Enfeeblement(dummy), 953);

        }
        [Test]
        public void Berserk_no_Test()
        {
            Dummy dummy = new Dummy(1000, 0, 0, 0, 0, 0, 1, 0);
            Berserker bersek = new Berserker(200, 0, 100, 4, 15, 4, 2, 0);

            //Rage [TESTE]
            bersek.Rage();
            bersek.take_dmg(9999999999999999999);
            Assert.AreEqual(bersek.HP, 200);

            dummy.gain_HP(999);

            //Tremor [TESTE]
            Assert.AreEqual(bersek.Tremor(dummy), 980);

            dummy.gain_HP(999);

            //Undying_Rage [TESTE]
            Assert.AreEqual(bersek.Undying_Rage(dummy), 953);

            dummy.gain_HP(999);
            bersek.take_dmg(100);
            //Great_Punch [TESTE]
            Assert.AreEqual(bersek.Great_Punch(dummy), 721);
        }
    }
}