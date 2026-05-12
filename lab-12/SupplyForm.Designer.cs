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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.supplyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshSupply = new System.Windows.Forms.ToolStripMenuItem();
            this.addSupply = new System.Windows.Forms.ToolStripMenuItem();
            this.updateSupply = new System.Windows.Forms.ToolStripMenuItem();
            this.removeSupply = new System.Windows.Forms.ToolStripMenuItem();
            this.totalSumCost = new System.Windows.Forms.Label();
            this.tabControlSupply.SuspendLayout();
            this.tabPageItem.SuspendLayout();
            this.itemContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemGrid)).BeginInit();
            this.tabPageSupplier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.suppliersGrid)).BeginInit();
            this.suppliersContextMenu.SuspendLayout();
            this.tabPageSupply.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplyGrid)).BeginInit();
            this.supplyContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSupply
            // 
            this.tabControlSupply.Controls.Add(this.tabPageItem);
            this.tabControlSupply.Controls.Add(this.tabPageSupplier);
            this.tabControlSupply.Controls.Add(this.tabPageSupply);
            this.tabControlSupply.Location = new System.Drawing.Point(4, 2);
            this.tabControlSupply.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlSupply.Name = "tabControlSupply";
            this.tabControlSupply.SelectedIndex = 0;
            this.tabControlSupply.Size = new System.Drawing.Size(864, 542);
            this.tabControlSupply.TabIndex = 0;
            // 
            // tabPageItem
            // 
            this.tabPageItem.ContextMenuStrip = this.itemContextMenu;
            this.tabPageItem.Controls.Add(this.itemGrid);
            this.tabPageItem.Location = new System.Drawing.Point(4, 25);
            this.tabPageItem.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageItem.Name = "tabPageItem";
            this.tabPageItem.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageItem.Size = new System.Drawing.Size(856, 513);
            this.tabPageItem.TabIndex = 0;
            this.tabPageItem.Text = "Товары";
            this.tabPageItem.UseVisualStyleBackColor = true;
            // 
            // itemContextMenu
            // 
            this.itemContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.itemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshItem,
            this.addItem,
            this.updateItem,
            this.removeItem});
            this.itemContextMenu.Name = "itemContextMenu";
            this.itemContextMenu.Size = new System.Drawing.Size(148, 100);
            // 
            // refreshItem
            // 
            this.refreshItem.Name = "refreshItem";
            this.refreshItem.Size = new System.Drawing.Size(147, 24);
            this.refreshItem.Text = "Обновить";
            this.refreshItem.Click += new System.EventHandler(this.refreshItem_Click);
            // 
            // addItem
            // 
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(147, 24);
            this.addItem.Text = "Добавить";
            this.addItem.Click += new System.EventHandler(this.addItem_Click);
            // 
            // updateItem
            // 
            this.updateItem.Name = "updateItem";
            this.updateItem.Size = new System.Drawing.Size(147, 24);
            this.updateItem.Text = "Изменить";
            this.updateItem.Click += new System.EventHandler(this.updateItem_Click);
            // 
            // removeItem
            // 
            this.removeItem.Name = "removeItem";
            this.removeItem.Size = new System.Drawing.Size(147, 24);
            this.removeItem.Text = "Удалить";
            this.removeItem.Click += new System.EventHandler(this.removeItem_Click);
            // 
            // itemGrid
            // 
            this.itemGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.itemGrid.Location = new System.Drawing.Point(-4, 0);
            this.itemGrid.Margin = new System.Windows.Forms.Padding(4);
            this.itemGrid.Name = "itemGrid";
            this.itemGrid.RowHeadersVisible = false;
            this.itemGrid.RowHeadersWidth = 51;
            this.itemGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.itemGrid.RowTemplate.Height = 24;
            this.itemGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.itemGrid.Size = new System.Drawing.Size(860, 515);
            this.itemGrid.TabIndex = 0;
            // 
            // tabPageSupplier
            // 
            this.tabPageSupplier.Controls.Add(this.suppliersGrid);
            this.tabPageSupplier.Location = new System.Drawing.Point(4, 25);
            this.tabPageSupplier.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSupplier.Name = "tabPageSupplier";
            this.tabPageSupplier.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageSupplier.Size = new System.Drawing.Size(856, 513);
            this.tabPageSupplier.TabIndex = 1;
            this.tabPageSupplier.Text = "Поставщики";
            this.tabPageSupplier.UseVisualStyleBackColor = true;
            // 
            // suppliersGrid
            // 
            this.suppliersGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suppliersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.suppliersGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.suppliersGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.suppliersGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.suppliersGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.suppliersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.suppliersGrid.ContextMenuStrip = this.suppliersContextMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.suppliersGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.suppliersGrid.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.suppliersGrid.Location = new System.Drawing.Point(0, 0);
            this.suppliersGrid.Margin = new System.Windows.Forms.Padding(4);
            this.suppliersGrid.Name = "suppliersGrid";
            this.suppliersGrid.RowHeadersVisible = false;
            this.suppliersGrid.RowHeadersWidth = 51;
            this.suppliersGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.suppliersGrid.RowTemplate.Height = 24;
            this.suppliersGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.suppliersGrid.Size = new System.Drawing.Size(862, 517);
            this.suppliersGrid.TabIndex = 0;
            // 
            // suppliersContextMenu
            // 
            this.suppliersContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.suppliersContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshSupplier,
            this.addSupplier,
            this.updateSupplier,
            this.removeSupplier});
            this.suppliersContextMenu.Name = "suppliersContextMenu";
            this.suppliersContextMenu.Size = new System.Drawing.Size(148, 100);
            // 
            // refreshSupplier
            // 
            this.refreshSupplier.Name = "refreshSupplier";
            this.refreshSupplier.Size = new System.Drawing.Size(147, 24);
            this.refreshSupplier.Text = "Обновить";
            this.refreshSupplier.Click += new System.EventHandler(this.refreshSupplier_Click);
            // 
            // addSupplier
            // 
            this.addSupplier.Name = "addSupplier";
            this.addSupplier.Size = new System.Drawing.Size(147, 24);
            this.addSupplier.Text = "Добавить";
            this.addSupplier.Click += new System.EventHandler(this.addSupplier_Click);
            // 
            // updateSupplier
            // 
            this.updateSupplier.Name = "updateSupplier";
            this.updateSupplier.Size = new System.Drawing.Size(147, 24);
            this.updateSupplier.Text = "Изменить";
            this.updateSupplier.Click += new System.EventHandler(this.updateSupplier_Click);
            // 
            // removeSupplier
            // 
            this.removeSupplier.Name = "removeSupplier";
            this.removeSupplier.Size = new System.Drawing.Size(147, 24);
            this.removeSupplier.Text = "Удалить";
            this.removeSupplier.Click += new System.EventHandler(this.removeSupplier_Click);
            // 
            // tabPageSupply
            // 
            this.tabPageSupply.Controls.Add(this.totalSumCost);
            this.tabPageSupply.Controls.Add(this.supplyGrid);
            this.tabPageSupply.Location = new System.Drawing.Point(4, 25);
            this.tabPageSupply.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSupply.Name = "tabPageSupply";
            this.tabPageSupply.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageSupply.Size = new System.Drawing.Size(856, 513);
            this.tabPageSupply.TabIndex = 2;
            this.tabPageSupply.Text = "Поставки";
            this.tabPageSupply.UseVisualStyleBackColor = true;
            // 
            // supplyGrid
            // 
            this.supplyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.supplyGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.supplyGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.supplyGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.supplyGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.supplyGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.supplyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplyGrid.ContextMenuStrip = this.supplyContextMenu;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.supplyGrid.DefaultCellStyle = dataGridViewCellStyle8;
            this.supplyGrid.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.supplyGrid.Location = new System.Drawing.Point(0, 0);
            this.supplyGrid.Margin = new System.Windows.Forms.Padding(4);
            this.supplyGrid.Name = "supplyGrid";
            this.supplyGrid.RowHeadersVisible = false;
            this.supplyGrid.RowHeadersWidth = 51;
            this.supplyGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.supplyGrid.RowTemplate.Height = 24;
            this.supplyGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.supplyGrid.Size = new System.Drawing.Size(860, 514);
            this.supplyGrid.TabIndex = 0;
            // 
            // supplyContextMenu
            // 
            this.supplyContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.supplyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshSupply,
            this.addSupply,
            this.updateSupply,
            this.removeSupply});
            this.supplyContextMenu.Name = "supplyContextMenu";
            this.supplyContextMenu.Size = new System.Drawing.Size(148, 100);
            // 
            // refreshSupply
            // 
            this.refreshSupply.Name = "refreshSupply";
            this.refreshSupply.Size = new System.Drawing.Size(147, 24);
            this.refreshSupply.Text = "Обновить";
            this.refreshSupply.Click += new System.EventHandler(this.refreshSupply_Click);
            // 
            // addSupply
            // 
            this.addSupply.Name = "addSupply";
            this.addSupply.Size = new System.Drawing.Size(147, 24);
            this.addSupply.Text = "Добавить";
            this.addSupply.Click += new System.EventHandler(this.addSupply_Click);
            // 
            // updateSupply
            // 
            this.updateSupply.Name = "updateSupply";
            this.updateSupply.Size = new System.Drawing.Size(147, 24);
            this.updateSupply.Text = "Изменить";
            this.updateSupply.Click += new System.EventHandler(this.updateSupply_Click);
            // 
            // removeSupply
            // 
            this.removeSupply.Name = "removeSupply";
            this.removeSupply.Size = new System.Drawing.Size(147, 24);
            this.removeSupply.Text = "Удалить";
            this.removeSupply.Click += new System.EventHandler(this.removeSupply_Click);
            // 
            // totalSumCost
            // 
            this.totalSumCost.AutoSize = true;
            this.totalSumCost.Location = new System.Drawing.Point(705, 189);
            this.totalSumCost.Name = "totalSumCost";
            this.totalSumCost.Size = new System.Drawing.Size(87, 16);
            this.totalSumCost.TabIndex = 1;
            this.totalSumCost.Text = "Неизвестно";
            // 
            // SupplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(871, 546);
            this.Controls.Add(this.tabControlSupply);
            this.Margin = new System.Windows.Forms.Padding(4);
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
            this.tabPageSupply.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplyGrid)).EndInit();
            this.supplyContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip supplyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem refreshSupply;
        private System.Windows.Forms.ToolStripMenuItem addSupply;
        private System.Windows.Forms.ToolStripMenuItem updateSupply;
        private System.Windows.Forms.ToolStripMenuItem removeSupply;
        private System.Windows.Forms.Label totalSumCost;
    }
}

