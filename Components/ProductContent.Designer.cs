namespace FinalProject.Components
{
    partial class ProductContent
    {
        private System.ComponentModel.IContainer components = null;

        private Panel rightPanel;
        private Panel panelProductInfo;
        private Panel panelEdit;
        private Panel panel2;
        private DataGridView gridViewProducts;
        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private TextBox textBoxPrice;
        private TextBox textBoxStockQuantity;
        private ComboBox comboBoxCategory;
        private TextBox textBoxEditName;
        private TextBox textBoxEditDescription;
        private TextBox textBoxEditPrice;
        private TextBox textBoxEditStockQuantity;
        private ComboBox comboBoxEditCategory;
        private Button buttonAddProduct;
        private Button buttonSaveEdit;
        private Button buttonSelectImage;
        private Button buttonEditSelectImage; // Thêm nút chọn hình ảnh để chỉnh sửa
        private PictureBox pictureBoxSelectedImage;
        private PictureBox pictureBoxEditSelectedImage; // Thêm PictureBox để hiển thị hình ảnh khi chỉnh sửa
        private Label labelName;
        private Label labelDescription;
        private Label labelPrice;
        private Label labelStockQuantity;
        private Label labelCategory;
        private Label labelEditName;
        private Label labelEditDescription;
        private Label labelEditPrice;
        private Label labelEditStockQuantity;
        private Label labelEditCategory;
        private Label labelEditProduct;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            rightPanel = new Panel();
            panel1 = new Panel();
            pictureBoxSelectedImage = new PictureBox();
            buttonSelectImage = new Button();
            labelName = new Label();
            textBoxName = new TextBox();
            labelDescription = new Label();
            textBoxDescription = new TextBox();
            labelPrice = new Label();
            textBoxPrice = new TextBox();
            labelStockQuantity = new Label();
            textBoxStockQuantity = new TextBox();
            labelCategory = new Label();
            comboBoxCategory = new ComboBox();
            panel3 = new Panel();
            buttonAddProduct = new Button();
            panelEdit = new Panel();
            panel2 = new Panel();
            pictureBoxEditSelectedImage = new PictureBox(); // Khởi tạo PictureBox cho chỉnh sửa
            buttonEditSelectImage = new Button(); // Khởi tạo nút chọn hình ảnh cho chỉnh sửa
            labelEditProduct = new Label();
            labelEditName = new Label();
            textBoxEditName = new TextBox();
            labelEditDescription = new Label();
            textBoxEditDescription = new TextBox();
            labelEditPrice = new Label();
            textBoxEditPrice = new TextBox();
            labelEditStockQuantity = new Label();
            textBoxEditStockQuantity = new TextBox();
            labelEditCategory = new Label();
            comboBoxEditCategory = new ComboBox();
            buttonSaveEdit = new Button();
            panelProductInfo = new Panel();
            gridViewProducts = new DataGridView();
            rightPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelectedImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEditSelectedImage).BeginInit();
            panel3.SuspendLayout();
            panelEdit.SuspendLayout();
            panel2.SuspendLayout();
            panelProductInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // rightPanel
            // 
            rightPanel.BackColor = SystemColors.Control;
            rightPanel.Controls.Add(panel1);
            rightPanel.Dock = DockStyle.Right;
            rightPanel.Location = new Point(991, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(380, 671);
            rightPanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(pictureBoxSelectedImage);
            panel1.Controls.Add(buttonSelectImage);
            panel1.Controls.Add(labelName);
            panel1.Controls.Add(textBoxName);
            panel1.Controls.Add(labelDescription);
            panel1.Controls.Add(textBoxDescription);
            panel1.Controls.Add(labelPrice);
            panel1.Controls.Add(textBoxPrice);
            panel1.Controls.Add(labelStockQuantity);
            panel1.Controls.Add(textBoxStockQuantity);
            panel1.Controls.Add(labelCategory);
            panel1.Controls.Add(comboBoxCategory);
            panel1.Controls.Add(panel3);
            panel1.Location = new Point(15, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 634);
            panel1.TabIndex = 0;
            // 
            // pictureBoxSelectedImage
            // 
            pictureBoxSelectedImage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxSelectedImage.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxSelectedImage.Location = new Point(17, 355);
            pictureBoxSelectedImage.Name = "pictureBoxSelectedImage";
            pictureBoxSelectedImage.Size = new Size(316, 120);
            pictureBoxSelectedImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxSelectedImage.TabIndex = 2;
            pictureBoxSelectedImage.TabStop = false;
            // 
            // buttonSelectImage
            // 
            buttonSelectImage.BackColor = Color.LightGray;
            buttonSelectImage.FlatStyle = FlatStyle.Flat;
            buttonSelectImage.Location = new Point(17, 295);
            buttonSelectImage.Name = "buttonSelectImage";
            buttonSelectImage.Size = new Size(316, 47);
            buttonSelectImage.TabIndex = 1;
            buttonSelectImage.Text = "Select Image";
            buttonSelectImage.UseVisualStyleBackColor = false;
            buttonSelectImage.Click += ButtonSelectImage_Click;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(17, 18);
            labelName.Name = "labelName";
            labelName.Size = new Size(39, 15);
            labelName.TabIndex = 3;
            labelName.Text = "Name";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(17, 36);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(316, 23);
            textBoxName.TabIndex = 2;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(17, 74);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(67, 15);
            labelDescription.TabIndex = 5;
            labelDescription.Text = "Description";
            // 
            // textBoxDescription
            // 
            textBoxDescription.Location = new Point(17, 92);
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(316, 23);
            textBoxDescription.TabIndex = 4;
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(17, 130);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(33, 15);
            labelPrice.TabIndex = 7;
            labelPrice.Text = "Price";
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(17, 148);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(316, 23);
            textBoxPrice.TabIndex = 6;
            // 
            // labelStockQuantity
            // 
            labelStockQuantity.AutoSize = true;
            labelStockQuantity.Location = new Point(17, 186);
            labelStockQuantity.Name = "labelStockQuantity";
            labelStockQuantity.Size = new Size(85, 15);
            labelStockQuantity.TabIndex = 9;
            labelStockQuantity.Text = "Stock Quantity";
            // 
            // textBoxStockQuantity
            // 
            textBoxStockQuantity.Location = new Point(17, 204);
            textBoxStockQuantity.Name = "textBoxStockQuantity";
            textBoxStockQuantity.Size = new Size(316, 23);
            textBoxStockQuantity.TabIndex = 8;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new Point(17, 242);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(55, 15);
            labelCategory.TabIndex = 11;
            labelCategory.Text = "Category";
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.Location = new Point(17, 260);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(316, 23);
            comboBoxCategory.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(buttonAddProduct);
            panel3.Location = new Point(17, 538);
            panel3.Name = "panel3";
            panel3.Size = new Size(316, 47);
            panel3.TabIndex = 1;
            // 
            // buttonAddProduct
            // 
            buttonAddProduct.BackColor = Color.LightGray;
            buttonAddProduct.FlatStyle = FlatStyle.Flat;
            buttonAddProduct.Location = new Point(0, 0);
            buttonAddProduct.Name = "buttonAddProduct";
            buttonAddProduct.Size = new Size(316, 47);
            buttonAddProduct.TabIndex = 0;
            buttonAddProduct.Text = "Add";
            buttonAddProduct.UseVisualStyleBackColor = false;
            buttonAddProduct.Click += ButtonAddProduct_Click;
            // 
            // panelEdit
            // 
            panelEdit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panelEdit.BackColor = SystemColors.Control;
            panelEdit.Controls.Add(panel2);
            panelEdit.Location = new Point(576, 0);
            panelEdit.Name = "panelEdit";
            panelEdit.Size = new Size(380, 671);
            panelEdit.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.White;
            panel2.Controls.Add(pictureBoxEditSelectedImage); // Thêm PictureBox cho chỉnh sửa
            panel2.Controls.Add(buttonEditSelectImage); // Thêm nút chọn hình ảnh cho chỉnh sửa
            panel2.Controls.Add(labelEditProduct);
            panel2.Controls.Add(labelEditName);
            panel2.Controls.Add(textBoxEditName);
            panel2.Controls.Add(labelEditDescription);
            panel2.Controls.Add(textBoxEditDescription);
            panel2.Controls.Add(labelEditPrice);
            panel2.Controls.Add(textBoxEditPrice);
            panel2.Controls.Add(labelEditStockQuantity);
            panel2.Controls.Add(textBoxEditStockQuantity);
            panel2.Controls.Add(labelEditCategory);
            panel2.Controls.Add(comboBoxEditCategory);
            panel2.Controls.Add(buttonSaveEdit);
            panel2.Location = new Point(17, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(350, 634);
            panel2.TabIndex = 0;
            // 
            // pictureBoxEditSelectedImage
            // 
            pictureBoxEditSelectedImage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxEditSelectedImage.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxEditSelectedImage.Location = new Point(17, 355);
            pictureBoxEditSelectedImage.Name = "pictureBoxEditSelectedImage";
            pictureBoxEditSelectedImage.Size = new Size(316, 120);
            pictureBoxEditSelectedImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxEditSelectedImage.TabIndex = 2;
            pictureBoxEditSelectedImage.TabStop = false;
            // 
            // buttonEditSelectImage
            // 
            buttonEditSelectImage.BackColor = Color.LightGray;
            buttonEditSelectImage.FlatStyle = FlatStyle.Flat;
            buttonEditSelectImage.Location = new Point(17, 295);
            buttonEditSelectImage.Name = "buttonEditSelectImage";
            buttonEditSelectImage.Size = new Size(316, 47);
            buttonEditSelectImage.TabIndex = 1;
            buttonEditSelectImage.Text = "Select Image";
            buttonEditSelectImage.UseVisualStyleBackColor = false;
            buttonEditSelectImage.Click += ButtonEditSelectImage_Click;
            // 
            // labelEditProduct
            // 
            labelEditProduct.AutoSize = true;
            labelEditProduct.Location = new Point(17, 18);
            labelEditProduct.Name = "labelEditProduct";
            labelEditProduct.Size = new Size(72, 15);
            labelEditProduct.TabIndex = 11;
            labelEditProduct.Text = "Edit Product";
            // 
            // labelEditName
            // 
            labelEditName.AutoSize = true;
            labelEditName.Location = new Point(17, 50);
            labelEditName.Name = "labelEditName";
            labelEditName.Size = new Size(39, 15);
            labelEditName.TabIndex = 3;
            labelEditName.Text = "Name";
            // 
            // textBoxEditName
            // 
            textBoxEditName.Location = new Point(17, 68);
            textBoxEditName.Name = "textBoxEditName";
            textBoxEditName.Size = new Size(310, 23);
            textBoxEditName.TabIndex = 2;
            // 
            // labelEditDescription
            // 
            labelEditDescription.AutoSize = true;
            labelEditDescription.Location = new Point(17, 110);
            labelEditDescription.Name = "labelEditDescription";
            labelEditDescription.Size = new Size(67, 15);
            labelEditDescription.TabIndex = 5;
            labelEditDescription.Text = "Description";
            // 
            // textBoxEditDescription
            // 
            textBoxEditDescription.Location = new Point(17, 128);
            textBoxEditDescription.Name = "textBoxEditDescription";
            textBoxEditDescription.Size = new Size(310, 23);
            textBoxEditDescription.TabIndex = 4;
            // 
            // labelEditPrice
            // 
            labelEditPrice.AutoSize = true;
            labelEditPrice.Location = new Point(17, 170);
            labelEditPrice.Name = "labelEditPrice";
            labelEditPrice.Size = new Size(33, 15);
            labelEditPrice.TabIndex = 7;
            labelEditPrice.Text = "Price";
            // 
            // textBoxEditPrice
            // 
            textBoxEditPrice.Location = new Point(17, 188);
            textBoxEditPrice.Name = "textBoxEditPrice";
            textBoxEditPrice.Size = new Size(310, 23);
            textBoxEditPrice.TabIndex = 6;
            // 
            // labelEditStockQuantity
            // 
            labelEditStockQuantity.AutoSize = true;
            labelEditStockQuantity.Location = new Point(17, 230);
            labelEditStockQuantity.Name = "labelEditStockQuantity";
            labelEditStockQuantity.Size = new Size(85, 15);
            labelEditStockQuantity.TabIndex = 9;
            labelEditStockQuantity.Text = "Stock Quantity";
            // 
            // textBoxEditStockQuantity
            // 
            textBoxEditStockQuantity.Location = new Point(17, 248);
            textBoxEditStockQuantity.Name = "textBoxEditStockQuantity";
            textBoxEditStockQuantity.Size = new Size(310, 23);
            textBoxEditStockQuantity.TabIndex = 8;
            // 
            // labelEditCategory
            // 
            labelEditCategory.AutoSize = true;
            labelEditCategory.Location = new Point(17, 290);
            labelEditCategory.Name = "labelEditCategory";
            labelEditCategory.Size = new Size(55, 15);
            labelEditCategory.TabIndex = 11;
            labelEditCategory.Text = "Category";
            // 
            // comboBoxEditCategory
            // 
            comboBoxEditCategory.Location = new Point(17, 308);
            comboBoxEditCategory.Name = "comboBoxEditCategory";
            comboBoxEditCategory.Size = new Size(310, 23);
            comboBoxEditCategory.TabIndex = 10;
            // 
            // buttonSaveEdit
            // 
            buttonSaveEdit.BackColor = Color.LightGray;
            buttonSaveEdit.FlatStyle = FlatStyle.Flat;
            buttonSaveEdit.Location = new Point(17, 538);
            buttonSaveEdit.Name = "buttonSaveEdit";
            buttonSaveEdit.Size = new Size(310, 47);
            buttonSaveEdit.TabIndex = 0;
            buttonSaveEdit.Text = "Save";
            buttonSaveEdit.UseVisualStyleBackColor = false;
            buttonSaveEdit.Click += ButtonSaveEdit_Click;
            // 
            // panelProductInfo
            // 
            panelProductInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelProductInfo.BackColor = SystemColors.Control;
            panelProductInfo.Controls.Add(gridViewProducts);
            panelProductInfo.Location = new Point(0, 0);
            panelProductInfo.Name = "panelProductInfo";
            panelProductInfo.Size = new Size(560, 671);
            panelProductInfo.TabIndex = 0;
            // 
            // gridViewProducts
            // 
            gridViewProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gridViewProducts.BackgroundColor = Color.White;
            gridViewProducts.BorderStyle = BorderStyle.None;
            gridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridViewProducts.Location = new Point(15, 16);
            gridViewProducts.Name = "gridViewProducts";
            gridViewProducts.Size = new Size(530, 629);
            gridViewProducts.TabIndex = 0;
            gridViewProducts.CellClick += GridViewProducts_CellClick;
            gridViewProducts.CellContentClick += GridViewProducts_CellContentClick;
            // 
            // ProductContent
            // 
            Controls.Add(panelEdit);
            Controls.Add(panelProductInfo);
            Controls.Add(rightPanel);
            Name = "ProductContent";
            Size = new Size(1371, 671);
            rightPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxSelectedImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxEditSelectedImage).EndInit();
            panel3.ResumeLayout(false);
            panelEdit.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panelProductInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridViewProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel panel3;
    }
}
