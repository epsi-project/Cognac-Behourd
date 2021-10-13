using System;
using System.Collections.Generic;
using System.Linq;
using Cognac_Behourd.Class.Enumerations;

namespace Cognac_Behourd.Class.Builders
{
    public class PersonneBuilder
    {
        private static Random _random = new Random();

        private Arme _arme = new Arme("");
        private ArmureType _armureType = ArmureType.None;
        private string _prenom = string.Empty;
        private string _nom = string.Empty;
        private DateTime _dateAdhesion = DateTime.Now;
        private DateTime _dateDeNaissance = DateTime.Now.AddYears(-25);
        private float _poids;

        public PersonneBuilder SetNomPrenom(string nom, string prenom)
        {
            this._nom = nom;
            this._prenom = prenom;

            return this;
        }

        public PersonneBuilder SetRandomNomPrenom()
        {
            _nom = RandomString(5);
            _prenom = RandomString(5);

            return this;
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public PersonneBuilder SetArme(Arme arme)
        {
            this._arme = arme;
            return this;
        }
        public PersonneBuilder SetArmure(ArmureType armureType)
        {
            this._armureType = armureType;
            return this;
        }

        public PersonneBuilder SetDateAdhesion(DateTime date)
        {
            _dateAdhesion = date;
            return this;
        }

        public PersonneBuilder SetPoids(float poids)
        {
            this._poids = poids;
            return this;
        }
        public PersonneBuilder SetDateNaissance(DateTime dateTime)
        {
            _dateDeNaissance = dateTime;
            return this;
        }

        public Personne Build()
        {
            return new Personne(_arme, _armureType, _prenom, _nom, _dateAdhesion, _poids, _dateDeNaissance);
        }

        public List<Personne> Build(int number)
        {
            return Enumerable.Range(0, number).Select(_ => Build()).ToList();
        }

    }
}
