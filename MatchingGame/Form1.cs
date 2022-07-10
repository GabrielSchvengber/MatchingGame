using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingGame
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;

        Label secondClicked = null;

        // Usando isso pra sairem fotos aleatóias
        Random random = new Random();

        List<string> icons = new List<string>() 
        { 
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };



        private void AssignIconsToSquares()
        {
            // pega todas as lebel e deixa-as de forma aleatória
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }



        public Form1()
        {
            InitializeComponent();

            AssignIconsToSquares();
        }



        private void label1_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
                return;

                Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                //quando apertado no preto ele revela a figura
                if (clickedLabel.ForeColor == Color.Black)
                    return;

            if (firstClicked == null)
            {
                 firstClicked = clickedLabel;
                 firstClicked.ForeColor = Color.Black;

                 return;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;


            CheckForWinner(); 


            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
                return;
            }       

            timer1.Start();
                    
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            // para o timer
            timer1.Stop();

            // esconde os botões
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            // reseta o primeiro e segundo click e faz o mesmo processo           
            firstClicked = null;
            secondClicked = null;

        }



        private void CheckForWinner()
        {           
            // veriica se todos os labels já estão completos corretamente
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }
            // caso o usuário tenha concluido o game
            // mostra uma mensagem de congratulações
            MessageBox.Show("Você completou todos os itens!", "Parabéns");
            Close();            
        }
    }
}
