using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognac_Behourd.Class.Builders
{
    public class PersonneBuilder
    {
        private static Random random = new Random();

        public Arme Arme { get; set; } = new Arme();
        public Armure Armure { get; set; } = new Armure();
        public string Prenom { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public DateTime DateAdhesion { get; set; } = DateTime.Now;
        public float Poids { get; set; } = 0f;

        public PersonneBuilder()
        {
            
        }

        public PersonneBuilder SetNomPrenom(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;

            return this;
        }

        public PersonneBuilder SetRandomNomPrenom()
        {
            Nom = RandomString(5);
            Prenom = RandomString(5);

            return this;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public PersonneBuilder SetArme(Arme arme)
        {
            Arme = arme;
            return this;
        }
        public PersonneBuilder SetArmure(Armure armure)
        {
            Armure = armure;
            return this;
        }

        public PersonneBuilder SetDateAdhesion(DateTime date)
        {
            DateAdhesion = date;
            return this;
        }

        public PersonneBuilder SetPoids(float poids)
        {
            Poids = poids;
            return this;
        }
        public PersonneBuilder SetDateNaissance(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Personne Build()
        {
            return new Personne(Arme, Armure, Prenom, Nom, DateAdhesion, Poids);
        }

        public List<Personne> Build(int number)
        {
            return Enumerable.Range(0, number).Select(_ => Build()).ToList();
        }

    }
}
