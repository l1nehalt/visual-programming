namespace lab_12
{
    partial class SupplyForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlSupply = new System.Windows.Forms.TabControl();
            this.tabPageItem = new System.Windows.Forms.TabPage();
            this.itemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemGrid = new System.Windows.Forms.DataGridView();
            this.tabPageSupplier = new System.Windows.Forms.TabPage();
            this.suppliersGrid = new System.Windows.Forms.DataGridView();
            this.suppliersContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.addSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.updateSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSupplier = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageSupply = new System.Windows.Forms.TabPage();
            this.supplyGrid = new System.Windows.Forms.DataGridView();
            this.tabControlSupply.SuspendLayout();
            this.tabPageItem.SuspendLayout();
            this.itemContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).BeginInit();
            this.tabPageSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersGrid)).BeginInit();
            this.suppliersContextMenu.SuspendLayout();
            this.tabPageSupply.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlSupply
            // 
            this.tabControlSupply.Controls.Add(this.tabPageItem);
            this.tabControlSupply.Controls.Add(this.tabPageSupplier);
            this.tabControlSupply.Controls.Add(this.tabPageSupply);
            this.tabControlSupply.Location = new System.Drawing.Point(3, 2);
            this.tabControlSupply.Name = "tabControlSupply";
            this.tabControlSupply.SelectedIndex = 0;
            this.tabControlSupply.Size = new System.Drawing.Size(796, 446);
            this.tabControlSupply.TabIndex = 0;
            // 
            // tabPageItem
            // 
            this.tabPageItem.ContextMenuStrip = this.itemContextMenu;
            this.tabPageItem.Controls.Add(this.itemGrid);
            this.tabPageItem.Location = new System.Drawing.Point(4, 22);
            this.tabPageItem.Name = "tabPageItem";
            this.tabPageItem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItem.Size = new System.Drawing.Size(788, 420);
            this.tabPageItem.TabIndex = 0;
            this.tabPageItem.Text = "Товары";
            this.tabPageItem.UseVisualStyleBackColor = true;
            // 
            // itemContextMenu
            // 
            this.itemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshItem,
            this.addItem,
            this.updateItem,
            this.removeItem});
            this.itemContextMenu.Name = "itemContextMenu";
            this.itemContextMenu.Size = new System.Drawing.Size(129, 92);
            // 
            // refreshItem
            // 
            this.refreshItem.Name = "refreshItem";
            this.refreshItem.Size = new System.Drawing.Size(128, 22);
            this.refreshItem.Text = "Обновить";
            this.refreshItem.Click += new System.EventHandler(this.refreshItem_Click);
            // 
            // addItem
            // 
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(128, 22);
            this.addItem.Text = "Добавить";
            this.addItem.Click += new System.EventHandler(this.addItem_Click);
            // 
            // updateItem
            // 
            this.updateItem.Name = "updateItem";
            this.updateItem.Size = new System.Drawing.Size(128, 22);
            this.updateItem.Text = "Изменить";
            this.updateItem.Click += new System.EventHandler(this.updateItem_Click);
            // 
            // removeItem
            // 
            this.removeItem.Name = "removeItem";
            this.removeItem.Size = new System.Drawing.Size(128, 22);
            this.removeItem.Text = "Удалить";
            this.removeItem.Click += new System.EventHandler(this.removeItem_Click);
            // 
            // itemGrid
            // 
            this.itemGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.itemGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.itemGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.itemGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemGrid.ContextMenuStrip = this.itemContextMenu;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.itemGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.itemGrid.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.itemGrid.Location = new System.Drawing.Point(6, 0);
            this.itemGrid.Name = "itemGrid";
            this.itemGrid.RowHeadersVisible = false;
            this.itemGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.itemGrid.RowTemplate.Height = 24;
            this.itemGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.itemGrid.Size = new System.Drawing.Size(788, 420);
            this.itemGrid.TabIndex = 0;
            // 
            // tabPageSupplier
            // 
            this.tabPageSupplier.Controls.Add(this.suppliersGrid);
            this.tabPageSupplier.Location = new System.Drawing.Point(4, 22);
            this.tabPageSupplier.Name = "tabPageSupplier";
            this.tabPageSupplier.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSupplier.Size = new System.Drawing.Size(788, 420);
            this.tabPageSupplier.TabIndex = 1;
            this.tabPageSupplier.Text = "Поставщики";
            this.tabPageSupplier.UseVisualStyleBackColor = true;
            // 
            // suppliersGrid
            // 
            this.suppliersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suppliersGrid.ContextMenuStrip = this.suppliersContextMenu;
            this.suppliersGrid.Location = new System.Drawing.Point(0, 0);
            this.suppliersGrid.Name = "suppliersGrid";
            this.suppliersGrid.Size = new System.Drawing.Size(788, 420);
            this.suppliersGrid.TabIndex = 0;
            // 
            // suppliersContextMenu
            // 
            this.suppliersContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshSupplier,
            this.addSupplier,
            this.updateSupplier,
            this.removeSupplier});
            this.suppliersContextMenu.Name = "suppliersContextMenu";
            this.suppliersContextMenu.Size = new System.Drawing.Size(181, 114);
            // 
            // refreshSupplier
            // 
            this.refreshSupplier.Name = "refreshSupplier";
            this.refreshSupplier.Size = new System.Drawing.Size(128, 22);
            this.refreshSupplier.Text = "Обновить";
            this.refreshSupplier.Click += new System.EventHandler(this.refreshSupplier_Click);
            // 
            // addSupplier
            // 
            this.addSupplier.Name = "addSupplier";
            this.addSupplier.Size = new System.Drawing.Size(180, 22);
            this.addSupplier.Text = "Добавить";
            this.addSupplier.Click += new System.EventHandler(this.addSupplier_Click);
            // 
            // updateSupplier
            // 
            this.updateSupplier.Name = "updateSupplier";
            this.updateSupplier.Size = new System.Drawing.Size(180, 22);
            this.updateSupplier.Text = "Изменить";
            this.updateSupplier.Click += new System.EventHandler(this.updateSupplier_Click);
            // 
            // removeSupplier
            // 
            this.removeSupplier.Name = "removeSupplier";
            this.removeSupplier.Size = new System.Drawing.Size(180, 22);
            this.removeSupplier.Text = "Удалить";
            this.removeSupplier.Click += new System.EventHandler(this.removeSupplier_Click);
            // 
            // tabPageSupply
            // 
            this.tabPageSupply.Controls.Add(this.supplyGrid);
            this.tabPageSupply.Location = new System.Drawing.Point(4, 22);
            this.tabPageSupply.Name = "tabPageSupply";
            this.tabPageSupply.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSupply.Size = new System.Drawing.Size(788, 420);
            this.tabPageSupply.TabIndex = 2;
            this.tabPageSupply.Text = "Поставки";
            this.tabPageSupply.UseVisualStyleBackColor = true;
            // 
            // supplyGrid
            // 
            this.supplyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplyGrid.Location = new System.Drawing.Point(0, 0);
            this.supplyGrid.Name = "supplyGrid";
            this.supplyGrid.Size = new System.Drawing.Size(788, 420);
            this.supplyGrid.TabIndex = 0;
            // 
            // SupplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlSupply);
            this.Name = "SupplyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поставки";
            this.tabControlSupply.ResumeLayout(false);
            this.tabPageItem.ResumeLayout(false);
            this.itemContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).EndInit();
            this.tabPageSupplier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.suppliersGrid)).EndInit();
            this.suppliersContextMenu.ResumeLayout(false);
            this.tabPageSupply.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.supplyGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSupply;
        private System.Windows.Forms.TabPage tabPageItem;
        private System.Windows.Forms.TabPage tabPageSupplier;
        private System.Windows.Forms.TabPage tabPageSupply;
        private System.Windows.Forms.DataGridView itemGrid;
        private System.Windows.Forms.ContextMenuStrip itemContextMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshItem;
        private System.Windows.Forms.ToolStripMenuItem addItem;
        private System.Windows.Forms.ToolStripMenuItem updateItem;
        private System.Windows.Forms.ToolStripMenuItem removeItem;
        private System.Windows.Forms.DataGridView suppliersGrid;
        private System.Windows.Forms.DataGridView supplyGrid;
        private System.Windows.Forms.ContextMenuStrip suppliersContextMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshSupplier;
        private System.Windows.Forms.ToolStripMenuItem addSupplier;
        private System.Windows.Forms.ToolStripMenuItem updateSupplier;
        private System.Windows.Forms.ToolStripMenuItem removeSupplier;
    }
}

