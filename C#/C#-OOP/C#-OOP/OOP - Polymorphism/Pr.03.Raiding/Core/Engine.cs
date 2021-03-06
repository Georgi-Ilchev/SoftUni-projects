﻿using Pr._03.Raiding.Core;
using Pr._03.Raiding.Heroes;
using Pr._03.Raiding.IO;
using Pr._03.Raiding.IO.Contracts;
using System;
using System.Collections.Generic;

namespace Pr._03.Raiding.Core
{
    public class Engine : IEngine
    {
        public IReader reader;
        public IWriter writer;
        public List<BaseHero> heroes;
        public Engine()
        {
            heroes = new List<BaseHero>();
        }

        public void Run()
        {
            var reader = new ConsoleReader();
            var lineCount = int.Parse(reader.Read());


            while (lineCount != this.heroes.Count)
            {
                var name = reader.Read();
                var spec = reader.Read();
                var createHero = new CreateHero();
                try
                {
                    var hero = createHero.Create(name, spec);
                    this.heroes.Add(hero);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
            }

            var bossPower = int.Parse(reader.Read());
            var raidResult = BossFight(bossPower);
            var writer = new ConsoleWriter();
            writer.Write(raidResult);
        }
        public string BossFight(int bossPower)
        {
            var writer = new ConsoleWriter();
            var raidPower = 0;
            foreach (var hero in this.heroes)
            {
                writer.Write(hero.CastAbility());
                raidPower += hero.Power;
            }
            var result = bossPower <= raidPower ? "Victory!" : "Defeat...";
            return result;
        }
    }
}
