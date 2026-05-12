namespace lab_12
{
    partial class AddSupplyForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblVolume = new System.Windows.Forms.Label();
            this.cmbItems = new System.Windows.Forms.ComboBox();
            this.cmbSuppliers = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.numVolume = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblItem
            // 
            this.lblItem.Location = new System.Drawing.Point(16, 11);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(133, 23);
            this.lblItem.TabIndex = 9;
            this.lblItem.Text = "Выберите товар:";
            // 
            // lblSupplier
            // 
            this.lblSupplier.Location = new System.Drawing.Point(16, 73);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(133, 23);
            this.lblSupplier.TabIndex = 7;
            this.lblSupplier.Text = "Поставщик:";
            // 
            // lblDate
            // 
            this.lblDate.Location = new System.Drawing.Point(16, 134);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(133, 23);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Дата поставки:";
            // 
            // lblVolume
            // 
            this.lblVolume.Location = new System.Drawing.Point(16, 196);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(133, 23);
            this.lblVolume.TabIndex = 3;
            this.lblVolume.Text = "Объем поставки:";
            // 
            // cmbItems
            // 
            this.cmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItems.Location = new System.Drawing.Point(20, 32);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Size = new System.Drawing.Size(313, 24);
            this.cmbItems.TabIndex = 8;
            // 
            // cmbSuppliers
            // 
            this.cmbSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuppliers.Location = new System.Drawing.Point(20, 94);
            this.cmbSuppliers.Name = "cmbSuppliers";
            this.cmbSuppliers.Size = new System.Drawing.Size(313, 24);
            this.cmbSuppliers.TabIndex = 6;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(20, 155);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(313, 22);
            this.dtpDate.TabIndex = 4;
            // 
            // numVolume
            // 
            this.numVolume.Location = new System.Drawing.Point(20, 217);
            this.numVolume.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numVolume.Name = "numVolume";
            this.numVolume.Size = new System.Drawing.Size(313, 22);
            this.numVolume.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(127, 265);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(235, 265);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddSupplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.numVolume);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbSuppliers);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.cmbItems);
            this.Controls.Add(this.lblItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSupplyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить поставку";
            ((System.ComponentModel.ISupportInitialize)(this.numVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.ComboBox cmbItems;
        private System.Windows.Forms.ComboBox cmbSuppliers;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.NumericUpDown numVolume;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}