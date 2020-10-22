using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TouroperatorSystem
{
    public partial class Help : Form
    {
        public Color orange = Color.LightSalmon;
        public Color blue = Color.CornflowerBlue;
        public Color white = Color.White;
        public Color black = Color.Black;
        public Color trans = Color.Transparent;
        public Color red = Color.MistyRose;
        Functions f = new Functions();
        public bool PanelMouseDown { get; set; }
        public Point PanelMouseDownLocation { get; set; }
        public Help()
        {
            InitializeComponent();
        }
        private void PanelForm_MouseDown(object sender, MouseEventArgs e)
        {
            PanelMouseDown = true;
            PanelMouseDownLocation = new Point(e.X, e.Y);
        }
        private void PanelForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (PanelMouseDown)
            {
                this.Location = new Point(this.Location.X - PanelMouseDownLocation.X + e.X, this.Location.Y - PanelMouseDownLocation.Y + e.Y);
            }
        }
        private void PanelForm_MouseUp(object sender, MouseEventArgs e)
        {
            PanelMouseDown = false;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            Close.BackColor = orange;
            Close.ForeColor = black;
        }
        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            Close.BackColor = trans;
            Close.ForeColor = white;
        }
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void TreeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {

        }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void TreeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
            int Count = 0;
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                Count++;
                if (treeView1.Nodes[i].IsExpanded)
                {
                    for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                    {
                        Count++;
                        if (treeView1.Nodes[i].Nodes[j].IsExpanded)
                        {
                            Count += treeView1.Nodes[i].Nodes[j].Nodes.Count;
                        }
                    }
                }
            }
            treeView1.Size = new Size(treeView1.Size.Width, Math.Min( 37 * Count,1300));
            panel4.Location = new Point(panel4.Location.X, treeView1.Size.Height + 100);
            Size = new Size(Size.Width, treeView1.Size.Height + 320);
            No.Location = new Point(No.Location.X, treeView1.Size.Height + 230);
        }

        private void TreeView1_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            int Count = 0;
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                Count++;
                if (treeView1.Nodes[i].IsExpanded)
                {
                    for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                    {
                        Count++;
                        if (treeView1.Nodes[i].Nodes[j].IsExpanded)
                        {
                            Count += treeView1.Nodes[i].Nodes[j].Nodes.Count;
                        }
                    }
                }
            }
            treeView1.Size = new Size(treeView1.Size.Width, Math.Min(37 * Count, 1300));
            panel4.Location = new Point(panel4.Location.X, treeView1.Size.Height + 100);
            Size = new Size(Size.Width, treeView1.Size.Height + 320);
            No.Location = new Point(No.Location.X, treeView1.Size.Height + 230);
        }

        private void No_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Help_Load(object sender, EventArgs e)
        {

        }
    }
}
