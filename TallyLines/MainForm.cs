// <copyright file="MainForm.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace TallyLines
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The line characters.
        /// </summary>
        int lineCharacters = 20;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TallyLines.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the process tally button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnProcessTallyButtonClick(object sender, EventArgs e)
        {
            // TODO Set result based on a list of X characters from current lines in text box [May be improved, including readability-wise]
            var result = this.displayTextBox.Lines.Where(x => !this.removeBlankLinesToolStripMenuItem.Checked || !string.IsNullOrEmpty(x)).Select(x => (this.trimLinesToolStripMenuItem.Checked ? x.Trim() : x)).Select(x => x.Length > lineCharacters ? x.Substring(0, lineCharacters) : x).ToList<string>()
            .GroupBy(item => item)
            .Select(item => new
            {
                Text = item.Key,
                Count = item.Count()
            })
            .OrderByDescending(item => item.Count)
            .ThenBy(item => item.Text);

            // Tally processing
            this.displayTextBox.Text = string.Join(Environment.NewLine, result.Select(item => string.Format("There {0} of {1}", item.Count > 1 ? $"are {item.Count}" : "is 1", item.Text)));
        }

        /// <summary>
        /// Handles the new tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNewToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Clear text box
            this.displayTextBox.Clear();

            // Focus text box
            this.displayTextBox.Focus();
        }

        /// <summary>
        /// Handles the open tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Reset file name
            this.textFileOpenFileDialog.FileName = string.Empty;

            // Show open file dialog
            if (this.textFileOpenFileDialog.ShowDialog() == DialogResult.OK && this.textFileOpenFileDialog.FileName.Length > 0)
            {
                // Read file to text box
                this.displayTextBox.Lines = File.ReadLines(this.textFileOpenFileDialog.FileName).ToArray();
            }
        }

        /// <summary>
        /// Handles the set first characters20 tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSetFirstCharacters20ToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Try to parse integer from user input
            if (int.TryParse(Interaction.InputBox("Set new first characters value:", "Characters", this.lineCharacters.ToString()), out int parsedInt) && parsedInt > 0)
            {
                // Set to parsed integer
                this.lineCharacters = parsedInt;

                // Update text
                this.setFirstCharacters20ToolStripMenuItem.Text = $"&Set first characters ({parsedInt})";
            }
        }

        /// <summary>
        /// Handles the options tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOptionsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set tool strip menu item
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;

            // Toggle checked
            toolStripMenuItem.Checked = !toolStripMenuItem.Checked;

            // Set topmost by check box
            this.TopMost = this.alwaysOnTopToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the free releases public domainis tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFreeReleasesPublicDomainisToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open our site
            Process.Start("https://publicdomain.is");
        }

        /// <summary>
        /// Handles the original thread donation codercom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open original thread
            Process.Start("https://www.donationcoder.com/forum/index.php?topic=53339.0");
        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open GitHub repository
            Process.Start("https://github.com/publicdomain/tally-lines");
        }

        /// <summary>
        /// Handles the about tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the display text box text changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnDisplayTextBoxTextChanged(object sender, EventArgs e)
        {
            // Update items
            this.itemsToolStripStatusLabel.Text = this.displayTextBox.Lines.Count().ToString();
        }

        /// <summary>
        /// Handles the exit tool strip menu item1 click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItem1Click(object sender, EventArgs e)
        {
            // TODO Add code
        }
    }
}
