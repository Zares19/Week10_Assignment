using System;
using System.Collections.Generic;

namespace week10_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameover = false;
            List<Fighter> fighters = new List<Fighter>();
            fighters.Add(new Player(20));
            fighters.Add(new Enemy(15));

            fighters[0].opponent = fighters[1];
            fighters[1].opponent = fighters[0];


            while (!gameover)
            {
                foreach (Fighter f in fighters)
                {
                    if (f.Dead())
                    {
                        gameover = true;
                    }
                    else
                    {
                        f.PrintHealth();
                        f.TakeAction();
                    }
                }
             
            }
        }
        abstract class Fighter
        {
            int Health;
           public Fighter opponent;

            public Fighter(int Hp)
            {
                Health = Hp;
            }

            public int health
            {
                get { return Health; }
                set { Health = value; }
            }

            public void PrintHealth()
            {
                Console.WriteLine("Hp: " + Health);
            }

            public bool Dead()
            {
                if (Health <= 0)
                {
                    Console.WriteLine("Congragulations! You defeated the enemy!");
                    return true;
                }
                return false;
            }

            public virtual void TakeAction()
            {
                Console.WriteLine("Your sword did 3 damage");
            }
            public abstract void TakeDamage(int v);

        }

        class Enemy : Fighter
        {
            public Enemy(int Hp) : base(Hp)
            {
                health = Hp;
            }

            public void Name()
            {
                Console.WriteLine("Goblin");
            }

            public override void TakeAction()
            {
                Console.WriteLine("They claw at you for 4 damage");
                opponent.TakeDamage(4);

            }

            public override void TakeDamage(int amount)
            {
                health -= amount;
            }
        }

        class Player : Fighter
        {
            public Player(int Hp) : base(Hp)
            {
                health = Hp;
            }

            public void Name()
            {
                Console.WriteLine("Knight");
            }

            public override void TakeDamage(int amount) 
            {
                health -= amount;
            }

            public override void TakeAction()
            {
                int choice = 0;

                Console.WriteLine("Type 1 to attack, type 2 to use potion");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    AttackEnemy();
                }
                else
                {
                    Potion();
                }

            }

            public void AttackEnemy()
            {
                Console.WriteLine("Your sword does 3 damage");
                opponent.TakeDamage(3);
            }

            public void Potion()
            {
                Console.WriteLine("You heal 5 Hp.");
                health += 5;
            }
        }
    }
}

