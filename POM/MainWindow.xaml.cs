using POMC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string currentStat = "";
        int turn = 1;
        public MainWindow()
        {
            InitializeComponent();
            Character.Character1 = new Character();
            Character.Character2 = new Character();
            UpdateInfo();
        }
        public void UpdateInfo()
        {
            Character.Character1.Crit = ((Character.Character1.Luck - Character.Character2.Luck * 0.5) * 0.1);
            Character.Character2.Crit = ((Character.Character2.Luck - Character.Character1.Luck * 0.5) * 0.1);
            Character.Character1.Evassion = ((Character.Character1.Dexterity - Character.Character2.Dexterity) * 0.1);
            Character.Character2.Evassion = ((Character.Character2.Dexterity - Character.Character1.Dexterity) * 0.1);
            Character.Character1.Penetration = ((Character.Character1.Strength - Character.Character2.Strength) * 0.05);
            Character.Character2.Penetration = ((Character.Character2.Strength - Character.Character1.Strength) * 0.05);
            Attack1.Text = Character.Character1.Attack.ToString();
            Health1.Text = Character.Character1.Health.ToString();
            MAttack1.Text = Character.Character1.MAttack.ToString();
            Mana1.Text = Character.Character1.Mana.ToString();
            Crit1.Text = Math.Ceiling(Character.Character1.Crit).ToString() + "%";
            Pen1.Text = Math.Ceiling(Character.Character1.Penetration).ToString() + "%";
            Ev1.Text = Math.Ceiling(Character.Character1.Evassion).ToString() + "%";
            Attack2.Text = Character.Character2.Attack.ToString();
            Health2.Text = Character.Character2.Health.ToString();
            MAttack2.Text = Character.Character2.MAttack.ToString();
            Mana2.Text = Character.Character2.Mana.ToString();
            Crit2.Text = Math.Ceiling(Character.Character2.Crit).ToString() + "%";
            Pen2.Text = Math.Ceiling(Character.Character2.Penetration).ToString() + "%";
            Ev2.Text = Math.Ceiling(Character.Character2.Evassion).ToString() + "%";
            Exp1.Text = Character.Character1.Expirience.ToString();
            Exp2.Text = Character.Character2.Expirience.ToString();
            Level1.Text = Character.Character1.Level.ToString();
            Level2.Text = Character.Character2.Level.ToString();
            if (turn == 1)
            {
                TurnTB.Text = "Character1 turn";
            }
            if (turn == 2)
            {
                TurnTB.Text = "Character2 turn";
            }
            if (Health1Bar.Value == 0)
            {
                TurnTB.Text = $"Character2 Won.\n";
            }
            if (Health2Bar.Value == 0)
            {
                TurnTB.Text = $"Character1 Won.\n";
            }
        }

        private void Character1RedBtn_Click(object sender, RoutedEventArgs e)
        {
            CharacterEditor characterEditor = new CharacterEditor();
            CharacterEditor.SelectedCharacter = Character.Character1;
            CharacterEditor.index = 1;
            characterEditor.StrMinV.Text = Character.Character1.Strength.ToString();
            characterEditor.DexMinV.Text = Character.Character1.Dexterity.ToString();
            characterEditor.LucMinV.Text = Character.Character1.Luck.ToString();
            characterEditor.ConMinV.Text = Character.Character1.Constitution.ToString();
            characterEditor.IntMinV.Text = Character.Character1.Intelligence.ToString();
            characterEditor.TotalPointsTB.Text = Character.Character1.Points.ToString();
            if (characterEditor.ShowDialog().Value)
            {
                Character.Character1 = CharacterEditor.SelectedCharacter;
                CharacterEditor.index = 0;
            }
            UpdateInfo();
        }

        private void Character2RedBtn_Click(object sender, RoutedEventArgs e)
        {
            CharacterEditor characterEditor = new CharacterEditor();
            CharacterEditor.SelectedCharacter = Character.Character2;
            CharacterEditor.index = 2;
            characterEditor.StrMinV.Text = Character.Character2.Strength.ToString();
            characterEditor.DexMinV.Text = Character.Character2.Dexterity.ToString();
            characterEditor.LucMinV.Text = Character.Character2.Luck.ToString();
            characterEditor.ConMinV.Text = Character.Character2.Constitution.ToString();
            characterEditor.IntMinV.Text = Character.Character2.Intelligence.ToString();
            characterEditor.TotalPointsTB.Text = Character.Character2.Points.ToString();
            if (characterEditor.ShowDialog().Value)
            {
                Character.Character2 = CharacterEditor.SelectedCharacter;
                CharacterEditor.index = 0;
            }
            UpdateInfo();
        }

        private void FightBtn_Click(object sender, RoutedEventArgs e)
        {
            Health1Bar.Visibility = Visibility.Visible;
            Health2Bar.Visibility = Visibility.Visible;
            Health1TB.Visibility = Visibility.Visible;
            Health2TB.Visibility = Visibility.Visible;
            HP1.Visibility = Visibility.Visible;
            HP2.Visibility = Visibility.Visible;
            ManaBar1.Visibility = Visibility.Visible;
            ManaBar2.Visibility = Visibility.Visible;
            Mana1TB.Visibility = Visibility.Visible;
            Mana2TB.Visibility = Visibility.Visible;
            MP1.Visibility = Visibility.Visible;
            MP2.Visibility = Visibility.Visible;
            if (Character.Character1.Intelligence > 5)
            {
                HealBtn1.Visibility = Visibility.Visible;
            }
            if (Character.Character2.Intelligence > 5)
            {
                HealBtn2.Visibility = Visibility.Visible;
            }
            MagicCB1.Visibility = Visibility.Visible;
            MagicCB2.Visibility = Visibility.Visible;
            ACB1.Visibility = Visibility.Visible;
            ACB2.Visibility = Visibility.Visible;
            AttackC1.Visibility = Visibility.Visible;
            AttackC2.Visibility = Visibility.Visible;
            DCB1.Visibility = Visibility.Visible;
            DCB2.Visibility = Visibility.Visible;
            DefenseChoice1.Visibility = Visibility.Visible;
            DefenseChoice2.Visibility = Visibility.Visible;
            TurnBtn.Visibility = Visibility.Visible;
            EndBtn.Visibility = Visibility.Visible;
            TurnTB.Visibility = Visibility.Visible;
            FightBtn.Visibility = Visibility.Hidden;
            Logs.Text = "";
            Character1RedBtn.Visibility = Visibility.Hidden;
            Character2RedBtn.Visibility = Visibility.Hidden;
            Health1Bar.Maximum = Character.Character1.Health;
            Health1Bar.Value = Character.Character1.Health;
            Health1TB.Text = Character.Character1.Health + "/" + Health1Bar.Value;
            Health2Bar.Maximum = Character.Character2.Health;
            Health2Bar.Value = Character.Character2.Health;
            Health2TB.Text = Character.Character2.Health + "/" + Health2Bar.Value;
            ManaBar1.Maximum = Character.Character1.Mana;
            ManaBar1.Value = Character.Character1.Mana;
            Mana1TB.Text = Character.Character1.Mana + "/" + ManaBar1.Value;
            ManaBar2.Maximum = Character.Character2.Mana;
            ManaBar2.Value = Character.Character2.Mana;
            Mana2TB.Text = Character.Character2.Mana + "/" + ManaBar2.Value;
        }

        private void TurnBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateInfo();
            Random random = new Random();
            double CurrentHealth = 0;
            try
            {
                if (Health1Bar.Value <= 0 || Health2Bar.Value <= 0)
                {
                    return;
                }
                if (turn == 1)
                {
                    turn = 2;
                    CurrentHealth = Health2Bar.Value;
                    if (random.Next(0, 101) < Character.Character2.Evassion)
                    {
                        Logs.Text += "Character2 evaded attack\n";
                        return;
                    }
                    if (random.Next(0, 101) < Character.Character1.Crit)
                    {
                        if (MagicCB1.IsChecked == true && ManaBar1.Value - 5 >= 0)
                        {
                            ManaBar1.Value -= 5;
                            Mana1TB.Text = Character.Character1.Mana + "/" + ManaBar1.Value;
                            if (ACB1.SelectedItem.ToString() == DCB2.SelectedItem.ToString() && random.Next(0, 101) < Character.Character1.Penetration)
                            {
                                Logs.Text += $"Character1 penetrated Character2 block and ";
                            }
                            else if (ACB1.SelectedItem.ToString() == DCB2.SelectedItem.ToString())
                            {
                                Logs.Text += "Character2 blocked attack\n";
                                return;
                            }
                            if(Health2Bar.Value - Character.Character1.MAttack * 2 <= 0)
                            {
                                Logs.Text += $"Character1 crited and dealt {Health2Bar.Value} damage to Character2\n";
                                Logs.Text += $"Character1 Won.\n";
                                TurnTB.Text += $"Character1 Won.\n";
                                Health2Bar.Value -= Character.Character1.MAttack * 2;
                                Character.Character1.Expirience += (CurrentHealth - Health2Bar.Value) * 3 * Character.Character2.Level;
                                UpdateInfo();
                                return;
                            }
                            Logs.Text += $"Character1 crited and dealt {Character.Character1.MAttack * 2} damage to Character2\n";
                            Health2Bar.Value -= Character.Character1.MAttack * 2;
                            Health2TB.Text = Character.Character2.Health + "/" + Health2Bar.Value;
                            Character.Character1.Expirience += (CurrentHealth - Health2Bar.Value) * 3 * Character.Character2.Level;
                            UpdateInfo();
                            return;
                        }
                        else
                        {
                            if (ACB1.SelectedItem.ToString() == DCB2.SelectedItem.ToString() && random.Next(0, 101) < Character.Character1.Penetration)
                            {
                                Logs.Text += $"Character1 penetrated Character2 block and ";
                            }
                            else if (ACB1.SelectedItem.ToString() == DCB2.SelectedItem.ToString())
                            {
                                Logs.Text += "Character2 blocked attack\n";
                                return;
                            }
                            if (Health2Bar.Value - Character.Character1.Attack * 2 <= 0)
                            {
                                Logs.Text += $"Character1 crited and dealt {Health2Bar.Value} damage to Character2\n";
                                Logs.Text += $"Character1 Won.\n";
                                TurnTB.Text += $"Character1 Won.\n";
                                Health2Bar.Value -= Character.Character1.Attack * 2;
                                Health2TB.Text = Character.Character2.Health + "/" + Health2Bar.Value;
                                Character.Character1.Expirience += (CurrentHealth - Health2Bar.Value) * 3 * Character.Character2.Level;
                                UpdateInfo();
                                return;
                            }
                            Logs.Text += $"Character1 crited and dealt {Character.Character1.Attack * 2} damage to Character2\n";
                            Health2Bar.Value -= Character.Character1.Attack * 2;
                            Health2TB.Text = Character.Character2.Health + "/" + Health2Bar.Value;
                            Character.Character1.Expirience += (CurrentHealth - Health2Bar.Value) * 3 * Character.Character2.Level;
                            UpdateInfo();
                            return;
                        }
                    }
                    if (MagicCB1.IsChecked == true && ManaBar1.Value - 5 >= 0)
                    {
                        ManaBar1.Value -= 5;
                        Mana1TB.Text = Character.Character1.Mana + "/" + ManaBar1.Value;
                        if (ACB1.SelectedItem.ToString() == DCB2.SelectedItem.ToString() && random.Next(0, 101) < Character.Character1.Penetration)
                        {
                            Logs.Text += $"Character1 penetrated Character2 block and ";
                        }
                        else if (ACB1.SelectedItem.ToString() == DCB2.SelectedItem.ToString())
                        {
                            Logs.Text += "Character2 blocked attack\n";
                            return;
                        }
                        if (Health2Bar.Value - Character.Character1.MAttack <= 0)
                        {
                            Logs.Text += $"Character1 dealt {Health2Bar.Value} damage to Character2\n";
                            Logs.Text += $"Character1 Won.\n";
                            TurnTB.Text += $"Character1 Won.\n";
                            Health2Bar.Value -= Character.Character1.MAttack;
                            Health2TB.Text = Character.Character2.Health + "/" + Health2Bar.Value;
                            Character.Character1.Expirience += (CurrentHealth - Health2Bar.Value) * 3 * Character.Character2.Level;
                            UpdateInfo();
                            return;
                        }
                        Logs.Text += $"Character1 dealt {Character.Character1.MAttack} damage to Character2\n";
                        Health2Bar.Value -= Character.Character1.MAttack;
                        Health2TB.Text = Character.Character2.Health + "/" + Health2Bar.Value;
                        Character.Character1.Expirience += (CurrentHealth - Health2Bar.Value) * 3 * Character.Character2.Level;
                        UpdateInfo();
                    }
                    else
                    {
                        if (ACB1.SelectedItem.ToString() == DCB2.SelectedItem.ToString() && random.Next(0, 101) < Character.Character1.Penetration)
                        {
                            Logs.Text += $"Character1 penetrated Character2 block and ";
                        }
                        else if (ACB1.SelectedItem.ToString() == DCB2.SelectedItem.ToString())
                        {
                            Logs.Text += "Character2 blocked attack\n";
                            return;
                        }
                        if (Health2Bar.Value - Character.Character1.Attack <= 0)
                        {
                            Logs.Text += $"Character1 dealt {Health2Bar.Value} damage to Character2\n";
                            Logs.Text += $"Character1 Won.\n";
                            TurnTB.Text += $"Character1 Won.\n";
                            Health2Bar.Value -= Character.Character1.Attack;
                            Health2TB.Text = Character.Character2.Health + "/" + Health2Bar.Value;
                            Character.Character1.Expirience += (CurrentHealth - Health2Bar.Value) * 3 * Character.Character2.Level;
                            UpdateInfo();
                            return;
                        }
                        Logs.Text += $"Character1 dealt {Character.Character1.Attack} damage to Character2\n";
                        Health2Bar.Value -= Character.Character1.Attack;
                        Health2TB.Text = Character.Character2.Health + "/" + Health2Bar.Value;
                        Character.Character1.Expirience += (CurrentHealth - Health2Bar.Value) * 3 * Character.Character2.Level;
                        UpdateInfo();
                    }
                }
                else if (turn == 2)
                {
                    turn = 1;
                    CurrentHealth = Health1Bar.Value;
                    if (random.Next(0, 101) < Character.Character1.Evassion)
                    {
                        Logs.Text += "Character1 evaded attack\n";
                        return;
                    }
                    if (random.Next(0, 101) < Character.Character2.Crit)
                    {
                        if (MagicCB2.IsChecked == true && ManaBar2.Value - 5 >= 0)
                        {
                            ManaBar2.Value -= 5;
                            Mana2TB.Text = Character.Character2.Mana + "/" + ManaBar2.Value;
                            if (ACB2.SelectedItem.ToString() == DCB1.SelectedItem.ToString() && random.Next(0, 101) < Character.Character2.Penetration)
                            {
                                Logs.Text += $"Character2 penetrated Character1 block and ";
                            }
                            else if (ACB2.SelectedItem.ToString() == DCB1.SelectedItem.ToString())
                            {
                                Logs.Text += "Character1 blocked attack\n";
                                return;
                            }
                            if (Health1Bar.Value - Character.Character2.MAttack * 2 <= 0)
                            {
                                Logs.Text += $"Character2 crited and dealt {Health1Bar.Value} damage to Character1\n";
                                Logs.Text += $"Character2 Won.\n";
                                TurnTB.Text += $"Character2 Won.\n";
                                Health1Bar.Value -= Character.Character2.MAttack * 2;
                                Health1TB.Text = Character.Character1.Health + "/" + Health1Bar.Value;
                                Character.Character2.Expirience += (CurrentHealth - Health1Bar.Value) * 3 * Character.Character1.Level;
                                UpdateInfo();
                                return;
                            }
                            Logs.Text += $"Character2 crited and dealt {Character.Character2.MAttack * 2} damage to Character1\n";
                            Health1Bar.Value -= Character.Character2.MAttack * 2;
                            Health1TB.Text = Character.Character1.Health + "/" + Health1Bar.Value;
                            Character.Character2.Expirience += (CurrentHealth - Health1Bar.Value) * 3 * Character.Character1.Level;
                            UpdateInfo();
                            return;
                        }
                        else
                        {
                            if (ACB2.SelectedItem.ToString() == DCB1.SelectedItem.ToString() && random.Next(0, 101) < Character.Character2.Penetration)
                            {
                                Logs.Text += $"Character2 penetrated Character1 block and ";
                            }
                            else if (ACB2.SelectedItem.ToString() == DCB1.SelectedItem.ToString())
                            {
                                Logs.Text += "Character1 blocked attack\n";
                                return;
                            }
                            if (Health1Bar.Value - Character.Character2.Attack * 2 <= 0)
                            {
                                Logs.Text += $"Character2 crited and dealt {Health1Bar.Value} damage to Character1\n";
                                Logs.Text += $"Character2 Won.\n";
                                TurnTB.Text += $"Character2 Won.\n";
                                Health1Bar.Value -= Character.Character2.Attack * 2;
                                Health1TB.Text = Character.Character1.Health + "/" + Health1Bar.Value;
                                Character.Character2.Expirience += (CurrentHealth - Health1Bar.Value) * 3 * Character.Character1.Level;
                                UpdateInfo();
                                return;
                            }
                            Logs.Text += $"Character2 crited and dealt {Character.Character2.Attack * 2} damage to Character1\n";
                            Health1Bar.Value -= Character.Character2.Attack * 2;
                            Health1TB.Text = Character.Character1.Health + "/" + Health1Bar.Value;
                            Character.Character2.Expirience += (CurrentHealth - Health1Bar.Value) * 3 * Character.Character1.Level;
                            UpdateInfo();
                            return;
                        }
                    }
                    if (MagicCB2.IsChecked == true && ManaBar2.Value - 5 >= 0)
                    {
                        ManaBar2.Value -= 5;
                        Mana2TB.Text = Character.Character2.Mana + "/" + ManaBar2.Value;
                        if (ACB2.SelectedItem.ToString() == DCB1.SelectedItem.ToString() && random.Next(0, 101) < Character.Character2.Penetration)
                        {
                            Logs.Text += $"Character2 penetrated Character1 block and ";
                        }
                        else if (ACB2.SelectedItem.ToString() == DCB1.SelectedItem.ToString())
                        {
                            Logs.Text += "Character1 blocked attack\n";
                            return;
                        }
                        if (Health1Bar.Value - Character.Character2.MAttack <= 0)
                        {
                            Logs.Text += $"Character2 dealt {Health1Bar.Value} damage to Character1\n";
                            Logs.Text += $"Character2 Won.\n";
                            TurnTB.Text += $"Character2 Won.\n";
                            Health1Bar.Value -= Character.Character2.MAttack;
                            Health1TB.Text = Character.Character1.Health + "/" + Health1Bar.Value;
                            Character.Character2.Expirience += (CurrentHealth - Health1Bar.Value) * 3 * Character.Character1.Level;
                            UpdateInfo();
                            return;
                        }
                        Logs.Text += $"Character2 dealt {Character.Character2.MAttack} damage to Character1\n";
                        Health1Bar.Value -= Character.Character2.MAttack;
                        Health1TB.Text = Character.Character1.Health + "/" + Health1Bar.Value;
                        Character.Character2.Expirience += (CurrentHealth - Health1Bar.Value) * 3 * Character.Character1.Level;
                        UpdateInfo();
                    }
                    else
                    {
                        if (ACB2.SelectedItem.ToString() == DCB1.SelectedItem.ToString() && random.Next(0, 101) < Character.Character2.Penetration)
                        {
                            Logs.Text += $"Character2 penetrated Character1 block and ";
                        }
                        else if (ACB2.SelectedItem.ToString() == DCB1.SelectedItem.ToString())
                        {
                            Logs.Text += "Character1 blocked attack\n";
                            return;
                        }
                        if (Health1Bar.Value - Character.Character2.Attack <= 0)
                        {
                            Logs.Text += $"Character2 dealt {Health1Bar.Value} damage to Character1\n";
                            Logs.Text += $"Character2 Won.\n";
                            TurnTB.Text += $"Character2 Won.\n";
                            Health1Bar.Value -= Character.Character2.Attack;
                            Health1TB.Text = Character.Character1.Health + "/" + Health1Bar.Value;
                            Character.Character2.Expirience += (CurrentHealth - Health1Bar.Value) * 3 * Character.Character1.Level;
                            UpdateInfo();
                            return;
                        }
                        Logs.Text += $"Character2 dealt {Character.Character2.Attack} damage to Character1\n";
                        Health1Bar.Value -= Character.Character2.Attack;
                        Health1TB.Text = Character.Character1.Health + "/" + Health1Bar.Value;
                        Character.Character2.Expirience += (CurrentHealth - Health1Bar.Value) * 3 * Character.Character1.Level;
                        UpdateInfo();
                    }
                }
            }
            catch (NullReferenceException)
            {
                Logs.Text += "Choose all spots\n";
            }
        }

        private void HealBtn1_Click(object sender, RoutedEventArgs e)
        {
            if(ManaBar1.Value < 0.5 && turn != 1)
            {
                return;
            }
            while (Health1Bar.Value != Character.Character1.Health && ManaBar1.Value >= 0.5 && turn == 1)
            {
                Health1Bar.Value += 1;
                ManaBar1.Value -= 0.5;
            }
            turn = 2;
            Health1TB.Text = Character.Character1.Health + "/" + Health1Bar.Value;
            Mana1TB.Text = Character.Character1.Mana + "/" + ManaBar1.Value;
        }

        private void HealBtn2_Click(object sender, RoutedEventArgs e)
        {
            if (ManaBar2.Value < 0.5 && turn != 2)
            {
                return;
            }
            while (Health2Bar.Value != Character.Character2.Health && ManaBar2.Value >= 0.5 && turn == 2)
            {
                Health2Bar.Value += 1;
                ManaBar2.Value -= 0.5;
            }
            turn = 1;
            Health2TB.Text = Character.Character2.Health + "/" + Health2Bar.Value;
            Mana2TB.Text = Character.Character2.Mana + "/" + ManaBar2.Value;
        }

        private void EndBtn_Click(object sender, RoutedEventArgs e)
        {
            Health1Bar.Visibility = Visibility.Hidden;
            Health2Bar.Visibility = Visibility.Hidden;
            Health1TB.Visibility = Visibility.Hidden;
            Health2TB.Visibility = Visibility.Hidden;
            HP1.Visibility = Visibility.Hidden;
            HP2.Visibility = Visibility.Hidden;
            ManaBar1.Visibility = Visibility.Hidden;
            ManaBar2.Visibility = Visibility.Hidden;
            Mana1TB.Visibility = Visibility.Hidden;
            Mana2TB.Visibility = Visibility.Hidden;
            MP1.Visibility = Visibility.Hidden;
            MP2.Visibility = Visibility.Hidden;
            HealBtn1.Visibility = Visibility.Hidden;
            HealBtn2.Visibility = Visibility.Hidden;
            MagicCB1.Visibility = Visibility.Hidden;
            MagicCB2.Visibility = Visibility.Hidden;
            ACB1.Visibility = Visibility.Hidden;
            ACB2.Visibility = Visibility.Hidden;
            AttackC1.Visibility = Visibility.Hidden;
            AttackC2.Visibility = Visibility.Hidden;
            DCB1.Visibility = Visibility.Hidden;
            DCB2.Visibility = Visibility.Hidden;
            DefenseChoice1.Visibility = Visibility.Hidden;
            DefenseChoice2.Visibility = Visibility.Hidden;
            TurnBtn.Visibility = Visibility.Hidden;
            EndBtn.Visibility = Visibility.Hidden;
            FightBtn.Visibility = Visibility.Visible;
            Logs.Text = "";
            Character1RedBtn.Visibility = Visibility.Visible;
            Character2RedBtn.Visibility = Visibility.Visible;
            TurnTB.Visibility = Visibility.Hidden;
        }
    }
}
