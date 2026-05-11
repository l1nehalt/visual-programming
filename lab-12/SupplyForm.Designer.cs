namespace lab_12
{
    partial class SupplyForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tabControlSupply = new TabControl();
            tabPageItem = new TabPage();
            itemContextMenu = new ContextMenuStrip(components);
            refreshItem = new ToolStripMenuItem();
            addItem = new ToolStripMenuItem();
            updateItem = new ToolStripMenuItem();
            removeItem = new ToolStripMenuItem();
            itemGrid = new DataGridView();
            tabPageSupplier = new TabPage();
            tabPageSupply = new TabPage();
            supplyGrid = new DataGridView();
            tabControlSupply.SuspendLayout();
            tabPageItem.SuspendLayout();
            itemContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)itemGrid).BeginInit();
            tabPageSupply.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)supplyGrid).BeginInit();
            SuspendLayout();
            // 
            // tabControlSupply
            // 
            tabControlSupply.Controls.Add(tabPageItem);
            tabControlSupply.Controls.Add(tabPageSupplier);
            tabControlSupply.Controls.Add(tabPageSupply);
            tabControlSupply.Location = new Point(2, 1);
            tabControlSupply.Name = "tabControlSupply";
            tabControlSupply.SelectedIndex = 0;
            tabControlSupply.Size = new Size(795, 447);
            tabControlSupply.TabIndex = 0;
            // 
            // tabPageItem
            // 
            tabPageItem.ContextMenuStrip = itemContextMenu;
            tabPageItem.Controls.Add(itemGrid);
            tabPageItem.Location = new Point(4, 24);
            tabPageItem.Name = "tabPageItem";
            tabPageItem.Padding = new Padding(3);
            tabPageItem.Size = new Size(787, 419);
            tabPageItem.TabIndex = 0;
            tabPageItem.Text = "Товары";
            tabPageItem.UseVisualStyleBackColor = true;
            // 
            // itemContextMenu
            // 
            itemContextMenu.Items.AddRange(new ToolStripItem[] { refreshItem, addItem, updateItem, removeItem });
            itemContextMenu.Name = "itemContextMenu";
            itemContextMenu.Size = new Size(129, 92);
            // 
            // refreshItem
            // 
            refreshItem.Name = "refreshItem";
            refreshItem.Size = new Size(128, 22);
            refreshItem.Text = "Обновить";
            refreshItem.Click += refreshItem_Click;
            // 
            // addItem
            // 
            addItem.Name = "addItem";
            addItem.Size = new Size(128, 22);
            addItem.Text = "Добавить";
            addItem.Click += addItem_Click;
            // 
            // updateItem
            // 
            updateItem.Name = "updateItem";
            updateItem.Size = new Size(128, 22);
            updateItem.Text = "Изменить";
            // 
            // removeItem
            // 
            removeItem.Name = "removeItem";
            removeItem.Size = new Size(128, 22);
            removeItem.Text = "Удалить";
            removeItem.Click += removeItem_Click;
            // 
            // itemGrid
            // 
            itemGrid.BackgroundColor = SystemColors.Window;
            itemGrid.BorderStyle = BorderStyle.None;
            itemGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            itemGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            itemGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            itemGrid.ContextMenuStrip = itemContextMenu;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            itemGrid.DefaultCellStyle = dataGridViewCellStyle2;
            itemGrid.Dock = DockStyle.Fill;
            itemGrid.GridColor = SystemColors.ActiveCaption;
            itemGrid.Location = new Point(3, 3);
            itemGrid.Name = "itemGrid";
            itemGrid.RowHeadersVisible = false;
            itemGrid.RowTemplate.Height = 24;
            itemGrid.Size = new Size(781, 413);
            itemGrid.TabIndex = 1;
            // 
            // tabPageSupplier
            // 
            tabPageSupplier.Location = new Point(4, 24);
            tabPageSupplier.Name = "tabPageSupplier";
            tabPageSupplier.Padding = new Padding(3);
            tabPageSupplier.Size = new Size(787, 419);
            tabPageSupplier.TabIndex = 1;
            tabPageSupplier.Text = "Поставщики";
            tabPageSupplier.UseVisualStyleBackColor = true;
            // 
            // tabPageSupply
            // 
            tabPageSupply.Controls.Add(supplyGrid);
            tabPageSupply.Location = new Point(4, 24);
            tabPageSupply.Name = "tabPageSupply";
            tabPageSupply.Padding = new Padding(3);
            tabPageSupply.Size = new Size(787, 419);
            tabPageSupply.TabIndex = 2;
            tabPageSupply.Text = "Поставки";
            tabPageSupply.UseVisualStyleBackColor = true;
            // 
            // supplyGrid
            // 
            supplyGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            supplyGrid.Dock = DockStyle.Fill;
            supplyGrid.GridColor = SystemColors.Window;
            supplyGrid.Location = new Point(3, 3);
            supplyGrid.Name = "supplyGrid";
            supplyGrid.Size = new Size(781, 413);
            supplyGrid.TabIndex = 0;
            // 
            // SupplyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControlSupply);
            Name = "SupplyForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Поставки";
            tabControlSupply.ResumeLayout(false);
            tabPageItem.ResumeLayout(false);
            itemContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)itemGrid).EndInit();
            tabPageSupply.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)supplyGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControlSupply;
        private TabPage tabPageItem;
        private TabPage tabPageSupplier;
        private TabPage tabPageSupply;
        private ContextMenuStrip itemContextMenu;
        private ToolStripMenuItem refreshItem;
        private ToolStripMenuItem addItem;
        private ToolStripMenuItem updateItem;
        private ToolStripMenuItem removeItem;
        private DataGridView itemGrid;
        private DataGridView supplyGrid;
    }
}
