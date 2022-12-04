using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POMC
{
    public class Character
    {
        public double _strength { get; set; }
        public double _dexterity { get; set; }
        public double _luck { get; set; }
        public double _constitution { get; set; }
        public double _intelligence { get; set; }
        public double Strength 
        {
            get 
            {
                return _strength;
            }
            set
            {
                _strength = value;
                this.Attack = _strength * 1;
            }
        }
        public double Dexterity
        {
            get
            {
                return _dexterity;
            }
            set
            {
                _dexterity = value;
            }
        }
        public double Luck
        {
            get
            {
                return _luck;
            }
            set
            {
                _luck = value;
            }
        }
        public double Constitution
        {
            get
            {
                return _constitution;
            }
            set
            {
                _constitution = value;
                this.Health = _constitution * 5;
            }
        }
        public double Intelligence
        {
            get
            {
                return _intelligence;
            }
            set
            {
                _intelligence = value;
                this.MAttack = _intelligence * 2;
                this.Mana = _intelligence * 7;
            }
        }
        public int _level { get; set; }
        public double _expirience { get; set; }
        public int Level
        {
            get
            {
                return this._level;
            }
            set
            {
                if (value > 0)
                {
                    this._level = value;
                }
                if(_level > 0 && _level < 6)
                {
                    this.Points += GivenPoints[this.Level];
                }
            }
        }

        public double Expirience
        {
            get
            {
                return this._expirience;
            }
            set
            {
                this._expirience = value;
                while (this._expirience >= NeededExp[this.Level])
                {
                    this._expirience -= NeededExp[this.Level];
                    this.Level += 1;
                }
            }
        }
        public double Attack { get; set; }
        public double Health { get; set; }
        public double MAttack { get; set; }
        public double Mana { get; set; }
        public double _penetration { get; set; }
        public double _crit { get; set; }
        public double _evassion { get; set; }
        public double Penetration
        {
            get
            {
                return _penetration;
            }
            set
            {
                if (value >= 0)
                {
                    _penetration = value;
                    return;
                }
                this._penetration = 0;
            }
        }
        public double Crit
        {
            get
            {
                return _crit;
            }
            set
            {
                if (value >= 0)
                {
                    _crit = value;
                    return;
                }
                this._crit = 0;
            }
        }
        public double Evassion
        {
            get
            {
                return _evassion;
            }
            set
            {
                if(value >= 0)
                {
                    _evassion = value;
                    return;
                }
                this._evassion = 0;
            }
        }
        public int Points { get; set; }

        public void Hit()
        {

        }

        public void Heal()
        {

        }

        public Character()
        {
            Strength = 1;
            Dexterity = 1;
            Luck = 1;
            Constitution = 1;
            Intelligence = 1;
            Level = 1;
            Expirience = 0;
            Attack = this.Strength * 1;
            Health = this.Constitution * 5;
            MAttack = this.Intelligence * 2;
            Mana = this.Intelligence * 7;
            Points = 15;
            Penetration = 0;
            Crit = 0;
            Evassion = 0;
        }

        public Character(double strength, double dexterity, double luck, double constitution, double intelligence, int level, int expirience)
        {
            Strength = strength;
            Dexterity = dexterity;
            Luck = luck;
            Constitution = constitution;
            Intelligence = intelligence;
            Level = 1;
            Expirience = 0;
            Attack = this.Strength * 1;
            Health = this.Constitution * 5;
            MAttack = this.Intelligence * 2;
            Mana = this.Intelligence * 7;
            Points = 15;
            Penetration = 0;
            Crit = 0;
            Evassion = 0;
            Level = level;
            Expirience = expirience;
        }

        public static Character Character1;

        public static Character Character2;

        Dictionary<int, int> NeededExp = new Dictionary<int, int>()
        {
            { 1, 100},
            { 2, 300},
            { 3, 900},
            { 4, 1800},
            { 5, 3000}
        };

        Dictionary<int, int> GivenPoints = new Dictionary<int, int>()
        {
            { 1, 2},
            { 2, 2},
            { 3, 3},
            { 4, 2},
            { 5, 5}
        };
    }
}
