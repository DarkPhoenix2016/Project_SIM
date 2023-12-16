namespace Project_SIM.Views.user
{
    partial class priceVarients
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
            this.listViewPriceVariations = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.variationName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listViewPriceVariations
            // 
            this.listViewPriceVariations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.itemName,
            this.variationName,
            this.price});
            this.listViewPriceVariations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPriceVariations.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewPriceVariations.HideSelection = false;
            this.listViewPriceVariations.Location = new System.Drawing.Point(3, 64);
            this.listViewPriceVariations.Name = "listViewPriceVariations";
            this.listViewPriceVariations.Size = new System.Drawing.Size(1115, 591);
            this.listViewPriceVariations.TabIndex = 0;
            this.listViewPriceVariations.UseCompatibleStateImageBehavior = false;
            this.listViewPriceVariations.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "ID";
            this.id.Width = 38;
            // 
            // itemName
            // 
            this.itemName.Text = "Product";
            this.itemName.Width = 283;
            // 
            // variationName
            // 
            this.variationName.Text = "Variation Name";
            this.variationName.Width = 173;
            // 
            // price
            // 
            this.price.Text = "Price";
            this.price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.price.Width = 225;
            // 
            // priceVarients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 658);
            this.Controls.Add(this.listViewPriceVariations);
            this.Name = "priceVarients";
            this.Text = "Price Varients";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader itemName;
        private System.Windows.Forms.ColumnHeader variationName;
        private System.Windows.Forms.ColumnHeader price;
        public System.Windows.Forms.ListView listViewPriceVariations;
    }
}