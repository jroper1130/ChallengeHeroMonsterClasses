using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //instances of class used to make characters
            //hero
            Character hero = new Character();
            hero.Name = "Hero";
            hero.Health = 35;
            hero.DamageMax = 20;
            hero.AttackBonus = false;
            //monster
            Character monster = new Character();
            monster.Name = "Monster";
            monster.Health = 40;
            monster.DamageMax = 20;
            monster.AttackBonus = true;

            //battle
            Dice dice = new Dice();
            //bonus
            if (hero.AttackBonus)
            {
                monster.Defend(hero.Attack(dice));
            }
            if (monster.AttackBonus)
            {
                hero.Defend(monster.Attack(dice));
            }
            //repeat fight until one of or both characters health is less than 0
            while (hero.Health > 0 && monster.Health > 0)
            {
                monster.Defend(hero.Attack(dice));
                hero.Defend(monster.Attack(dice));

                print(hero);
                print(monster);
            }
            displayResult(hero, monster);
           
        }
        // helper method to print out victor
        private void displayResult(Character opponent1, Character opponent2)
        {
            if (opponent1.Health <= 0 && opponent2.Health <= 0)
                Label1.Text += String.Format("<p>Both {} and {} died!",
                    opponent1.Name, opponent2.Name);
            else if (opponent1.Health <= 0)
                Label1.Text += String.Format("<p>{0} defeated {1}</p>",
                    opponent2.Name, opponent1.Name);
            else
                Label1.Text = String.Format("<p>{0} defeated {1}</p>",
                    opponent1.Name, opponent2.Name);

        }
        //helper method to print stats per battle
        private void print(Character character)
        {
            Label1.Text += String.Format("<p>Name: {0} - Health: {1} - DamageMax: {2}" +
                " - AttackBonus {3}</p>", character.Name, character.Health,
                character.DamageMax, character.AttackBonus.ToString());
        }
    }
    //dice role class
    class Dice
    {
        public int Sides { get; set; }
       Random random = new Random();
        public int Roll()
        {
            return random.Next(this.Sides);
        }
    }

    //character class
    class Character
    {
        //character properties
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMax { get; set; }
        public bool AttackBonus { get; set; }
        //atk method
        public int Attack(Dice dice)
        {
            dice.Sides = this.DamageMax;
            return dice.Roll();
        }
        //defense method
        public void Defend(int damage)
        {
            this.Health -= damage;
        }

    }
}