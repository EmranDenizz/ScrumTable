using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace ScrumTable
{
    public partial class StoryAdd : Form
    {
        private readonly Form1 _parentForm;
        private Random _random = new Random();

        public StoryAdd(Form1 parentForm)
        {
            _parentForm = parentForm;
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label3.Text = "All fields are necessary";
                return;
            }

            _parentForm.Stories.Add(new Story()
            {
                Tasks = new List<Task>(),
                Name = textBox1.Text,
                Description = textBox2.Text,
                BackgroundColor = Color.FromArgb(_random.Next(256), _random.Next(256), _random.Next(256))
            });

            _parentForm.UpdateTable();
            _parentForm.Refresh();
        }
    }
}