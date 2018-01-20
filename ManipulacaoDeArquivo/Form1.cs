﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManipulacaoDeArquivo
{
    public partial class Form1 : Form
    {
        private string pathArquivo;

        public Form1()
        {
            InitializeComponent();
            this.pathArquivo = "arquivo01.txt";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(pathArquivo)){
                Stream entrada = File.Open(pathArquivo, FileMode.Open);
                StreamReader sr = new StreamReader(entrada);

                // string linha = sr.ReadLine();

                // while (linha != null)
                // {
                // caixaDeTexto.Text += linha;
                // linha = sr.ReadLine();
                // }

                string conteudoArquivo = sr.ReadToEnd();
                caixaDeTexto.Text = conteudoArquivo;

                sr.Close();
                entrada.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Stream saida = File.Open(pathArquivo, FileMode.Create);
            StreamWriter sw = new StreamWriter(saida);
            sw.Write(caixaDeTexto.Text);

            sw.Close();
            saida.Close();
        }
    }
}
