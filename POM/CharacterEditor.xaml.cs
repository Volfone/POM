using POMC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POM
{
    /// <summary>
    /// Логика взаимодействия для CharacterEditor.xaml
    /// </summary>
    public partial class CharacterEditor : Window
    {
        string currentStat = "";
        public static Character SelectedCharacter;
        public static int index;
        public CharacterEditor()
        {
            InitializeComponent();
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = (sender as Button).Name;
                currentStat = "" + name[0] + name[1] + name[2];
                int value = int.Parse(TotalPointsTB.Text);

                switch (currentStat)
                {
                    case "Str":
                        if (int.Parse(TotalPointsTB.Text) - 1 < 0)
                        {
                            return;
                        }
                        StrMinV.Text = ((int.Parse(StrMinV.Text) + 1).ToString());
                        TotalPointsTB.Text = (int.Parse(TotalPointsTB.Text) - 1).ToString();
                        break;
                    case "Dex":
                        if (int.Parse(TotalPointsTB.Text) - 1 < 0)
                        {
                            return;
                        }
                        DexMinV.Text = ((int.Parse(DexMinV.Text) + 1).ToString());
                        TotalPointsTB.Text = (int.Parse(TotalPointsTB.Text) - 1).ToString();
                        break;
                    case "Luc":
                        if (int.Parse(TotalPointsTB.Text) - 1 < 0)
                        {
                            return;
                        }
                        LucMinV.Text = ((int.Parse(LucMinV.Text) + 1).ToString());
                        TotalPointsTB.Text = (int.Parse(TotalPointsTB.Text) - 1).ToString();
                        break;
                    case "Con":
                        if (int.Parse(TotalPointsTB.Text) - 1 < 0)
                        {
                            return;
                        }
                        ConMinV.Text = ((int.Parse(ConMinV.Text) + 1).ToString());
                        TotalPointsTB.Text = (int.Parse(TotalPointsTB.Text) - 1).ToString();
                        break;
                    case "Int":
                        if (int.Parse(TotalPointsTB.Text) - 1 < 0)
                        {
                            return;
                        }
                        IntMinV.Text = ((int.Parse(IntMinV.Text) + 1).ToString());
                        TotalPointsTB.Text = (int.Parse(TotalPointsTB.Text) - 1).ToString();
                        break;
                    default: break;
                }
            }
            catch (NullReferenceException) { }
        }

        private void ApplyBtn_Click(object sender, RoutedEventArgs e)
        {
            SelectedCharacter.Strength = int.Parse(StrMinV.Text);
            SelectedCharacter.Dexterity = int.Parse(DexMinV.Text);
            SelectedCharacter.Luck = int.Parse(LucMinV.Text);
            SelectedCharacter.Constitution = int.Parse(ConMinV.Text);
            SelectedCharacter.Intelligence = int.Parse(IntMinV.Text);
            SelectedCharacter.Points = int.Parse(TotalPointsTB.Text);
            if (index == 1)
            {
                Character.Character1 = SelectedCharacter;
                this.DialogResult = true;
            }
            else if(index == 2)
            {
                Character.Character2 = SelectedCharacter;
                this.DialogResult = true;
            }
            else
            {
                return;
            }
        }
    }
}
