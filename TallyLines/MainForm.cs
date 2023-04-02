// <copyright file="MainForm.cs" company="PublicDomain.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

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
            // Set result based on a list of X characters from current lines in text box
            var result = this.displayTextBox.Lines.Select(x => x.Length > lineCharacters ? x.Substring(0, lineCharacters) : x).ToList<string>()
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
            // TODO Add code
        }

        /// <summary>
        /// Handles the open tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOpenToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the set first characters20 tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSetFirstCharacters20ToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the options tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOptionsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the free releases public domainis tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFreeReleasesPublicDomainisToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the original thread donation codercom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // TODO Add code
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
