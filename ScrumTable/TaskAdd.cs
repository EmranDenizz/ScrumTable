using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ScrumTable
{
    public partial class TaskAdd : Form
    {
        private readonly Story _story;
        private readonly Form1 _form1;

        public TaskAdd()
        {
            InitializeComponent();
        }

        public TaskAdd(Story story, Form1 form1)
        {
            InitializeComponent();
            _story = story;
            _form1 = form1;
            comboBox1.DataSource = Enum.GetValues(typeof(Status));
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                label5.Text = "All fields are necessary";
                return;
            }

            Status status;
            Enum.TryParse<Status>(comboBox1.SelectedValue.ToString(), out status);

            var task = new Task()
            {
                Name = textBox1.Text,
                Status = status,
                Assignee = textBox2.Text,
                DueDate = dateTimePicker1.Value
            };

            _story.Tasks.Add(task);
            _form1.UpdateTable();
            _form1.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
