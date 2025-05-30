using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Arvore_Patricia_forms
{
    public partial class Form1 : Form
    {
        private PatriciaTrie tree = new PatriciaTrie();
        private TextBox txtEntrada;
        private Button btnInserir, btnBuscar, btnRemover;
        private Panel panelDesenho;
        private PatriciaTrie.Node nodeEncontrado = null;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Árvore PATRICIA - Demonstração";
            this.Width = 900;
            this.Height = 700;

            txtEntrada = new TextBox() { Location = new Point(10, 10), Width = 300 };
            btnInserir = new Button() { Text = "Inserir", Location = new Point(320, 10) };
            btnBuscar = new Button() { Text = "Buscar", Location = new Point(400, 10) };
            btnRemover = new Button() { Text = "Remover", Location = new Point(480, 10) };

            btnInserir.Click += BtnInserir_Click;
            btnBuscar.Click += BtnBuscar_Click;
            btnRemover.Click += BtnRemover_Click;

            panelDesenho = new Panel()
            {
                Location = new Point(10, 50),
                Width = this.ClientSize.Width - 20,
                Height = this.ClientSize.Height - 60,
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true
            };
            panelDesenho.Paint += PanelDesenho_Paint;

            this.Controls.Add(txtEntrada);
            this.Controls.Add(btnInserir);
            this.Controls.Add(btnBuscar);
            this.Controls.Add(btnRemover);
            this.Controls.Add(panelDesenho);
        }

        private void BtnInserir_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEntrada.Text))
            {
                tree.Insert(txtEntrada.Text);
                nodeEncontrado = null;
                panelDesenho.Invalidate();
                txtEntrada.Clear();
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEntrada.Text))
            {
                nodeEncontrado = tree.SearchNode(txtEntrada.Text);
                if (nodeEncontrado == null)
                    MessageBox.Show("Palavra não encontrada", "Busca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelDesenho.Invalidate();
            }
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEntrada.Text))
            {
                bool removido = tree.Remove(txtEntrada.Text);
                if (removido)
                {
                    nodeEncontrado = null;
                    MessageBox.Show("Palavra removida com sucesso!", "Remover", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    panelDesenho.Invalidate();
                }
                else
                {
                    MessageBox.Show("Palavra não encontrada para remoção.", "Remover", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                txtEntrada.Clear();
            }
        }

        private void PanelDesenho_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (tree.Root != null)
            {
                HashSet<PatriciaTrie.Node> visitados = new HashSet<PatriciaTrie.Node>();
                DrawNode(g, tree.Root, panelDesenho.Width / 2, 30, panelDesenho.Width / 4, visitados);
            }
        }

        private void DrawNode(Graphics g, PatriciaTrie.Node node, int x, int y, int offset, HashSet<PatriciaTrie.Node> visitados)
        {
            if (node == null || visitados.Contains(node)) return;
            visitados.Add(node);

            string text = node.IsLeaf ? tree.FromBinary(node.Key) : $"Bit {node.BitIndex}";
            Font font = node.IsLeaf ? this.Font : new Font(this.Font.FontFamily, 8);
            Brush fillBrush = node.IsLeaf ? Brushes.LightBlue : Brushes.LightGray;

            if (node == nodeEncontrado)
                fillBrush = Brushes.LightGreen;

            Rectangle rect = new Rectangle(x - 30, y, 60, 30);
            g.FillRectangle(fillBrush, rect);
            g.DrawRectangle(Pens.Black, rect);
            g.DrawString(text, font, Brushes.Black, x - 28, y + 8);

            if (!node.IsLeaf)
            {
                if (node.Left != null && node.Left != node)
                {
                    g.DrawLine(Pens.Black, x, y + 30, x - offset, y + 80);
                    DrawNode(g, node.Left, x - offset, y + 80, offset / 2, visitados);
                }
                if (node.Right != null && node.Right != node)
                {
                    g.DrawLine(Pens.Black, x, y + 30, x + offset, y + 80);
                    DrawNode(g, node.Right, x + offset, y + 80, offset / 2, visitados);
                }
            }
        }
    }
}