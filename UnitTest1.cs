using NUnit.Framework;
using Tales_of_laponian_front.Characters.Classes;
using Tales_of_laponian_front.IA_enemy;
namespace TEST
{
    public class Tests
    {
        [Test]
        public void Assassin_no_attack()
        {
            Assassin a = new Assassin(200, 100, 100, 6, 4, 4, 1, 789);
            Dummy d = new Dummy(1000, 0, 0, 0, 0, 0,0,0);

            a.Poison_slash(d);
            Assert.AreEqual(d.HP,964);
        }
    }
}