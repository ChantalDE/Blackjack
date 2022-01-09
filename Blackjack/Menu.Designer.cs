
namespace Blackjack
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox_soft17 = new System.Windows.Forms.CheckBox();
            this.textBox_seed = new System.Windows.Forms.TextBox();
            this.label_seed = new System.Windows.Forms.Label();
            this.label_numberOfDecks = new System.Windows.Forms.Label();
            this.comboBox_numberOfDecks = new System.Windows.Forms.ComboBox();
            this.button_play = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox_soft17
            // 
            this.checkBox_soft17.AutoSize = true;
            this.checkBox_soft17.Location = new System.Drawing.Point(30, 30);
            this.checkBox_soft17.Name = "checkBox_soft17";
            this.checkBox_soft17.Size = new System.Drawing.Size(87, 24);
            this.checkBox_soft17.TabIndex = 0;
            this.checkBox_soft17.Text = "Soft 17";
            this.checkBox_soft17.UseVisualStyleBackColor = true;
            // 
            // textBox_seed
            // 
            this.textBox_seed.Location = new System.Drawing.Point(168, 84);
            this.textBox_seed.Name = "textBox_seed";
            this.textBox_seed.Size = new System.Drawing.Size(100, 26);
            this.textBox_seed.TabIndex = 1;
            this.textBox_seed.Text = "999";
            // 
            // label_seed
            // 
            this.label_seed.AutoSize = true;
            this.label_seed.Location = new System.Drawing.Point(30, 87);
            this.label_seed.Name = "label_seed";
            this.label_seed.Size = new System.Drawing.Size(47, 20);
            this.label_seed.TabIndex = 2;
            this.label_seed.Text = "Seed";
            // 
            // label_numberOfDecks
            // 
            this.label_numberOfDecks.AutoSize = true;
            this.label_numberOfDecks.Location = new System.Drawing.Point(30, 133);
            this.label_numberOfDecks.Name = "label_numberOfDecks";
            this.label_numberOfDecks.Size = new System.Drawing.Size(132, 20);
            this.label_numberOfDecks.TabIndex = 3;
            this.label_numberOfDecks.Text = "Number of Decks";
            // 
            // comboBox_numberOfDecks
            // 
            this.comboBox_numberOfDecks.FormattingEnabled = true;
            this.comboBox_numberOfDecks.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.comboBox_numberOfDecks.Location = new System.Drawing.Point(168, 130);
            this.comboBox_numberOfDecks.Name = "comboBox_numberOfDecks";
            this.comboBox_numberOfDecks.Size = new System.Drawing.Size(121, 28);
            this.comboBox_numberOfDecks.TabIndex = 4;
            this.comboBox_numberOfDecks.Text = "1";
            // 
            // button_play
            // 
            this.button_play.Location = new System.Drawing.Point(30, 188);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(260, 50);
            this.button_play.TabIndex = 5;
            this.button_play.Text = "PLAY";
            this.button_play.UseVisualStyleBackColor = true;
            this.button_play.Click += new System.EventHandler(this.button_play_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 269);
            this.Controls.Add(this.button_play);
            this.Controls.Add(this.comboBox_numberOfDecks);
            this.Controls.Add(this.label_numberOfDecks);
            this.Controls.Add(this.label_seed);
            this.Controls.Add(this.textBox_seed);
            this.Controls.Add(this.checkBox_soft17);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_soft17;
        private System.Windows.Forms.TextBox textBox_seed;
        private System.Windows.Forms.Label label_seed;
        private System.Windows.Forms.Label label_numberOfDecks;
        private System.Windows.Forms.ComboBox comboBox_numberOfDecks;
        private System.Windows.Forms.Button button_play;
    }
}