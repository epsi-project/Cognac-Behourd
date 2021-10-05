using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cognac_Behourd.Class.Builders
{
    public class PersonneBuilder
    {
        private static Random random = new Random();

        private Arme arme = new Arme();
        private Armure armure = new Armure();
        private string prenom = string.Empty;
        private string nom = string.Empty;
        private DateTime dateAdhesion = DateTime.Now;
        private DateTime dateDeNaissance = DateTime.Now.AddYears(-25);
        private float poids = 0f;

        public PersonneBuilder()
        {
            
        }

        public PersonneBuilder SetNomPrenom(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;

            return this;
        }

        public PersonneBuilder SetRandomNomPrenom()
        {
            nom = RandomString(5);
            prenom = RandomString(5);

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
            this.arme = arme;
            return this;
        }
        public PersonneBuilder SetArmure(Armure armure)
        {
            this.armure = armure;
            return this;
        }

        public PersonneBuilder SetDateAdhesion(DateTime date)
        {
            dateAdhesion = date;
            return this;
        }

        public PersonneBuilder SetPoids(float poids)
        {
            this.poids = poids;
            return this;
        }
        public PersonneBuilder SetDateNaissance(DateTime dateTime)
        {
            dateDeNaissance = dateTime;
            return this;
        }

        public Personne Build()
        {
            return new Personne(arme, armure, prenom, nom, dateAdhesion, poids, dateDeNaissance);
        }

        public List<Personne> Build(int number)
        {
            return Enumerable.Range(0, number).Select(_ => Build()).ToList();
        }

    }
}
