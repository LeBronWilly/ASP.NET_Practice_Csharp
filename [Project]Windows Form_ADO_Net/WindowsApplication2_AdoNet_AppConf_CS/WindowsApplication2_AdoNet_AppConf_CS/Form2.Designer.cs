namespace WindowsApplication2_AdoNet_AppConf_CS
{
    partial class Form2
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Button1 = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.testDataSet = new WindowsApplication2_AdoNet_AppConf_CS.testDataSet();
            this.testBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.testTableAdapter = new WindowsApplication2_AdoNet_AppConf_CS.testDataSetTableAdapters.testTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testtimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.summaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hitnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailnoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.approvedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(195, 219);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 16;
            this.Button1.Text = "Button1";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(7, 79);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(263, 134);
            this.TextBox1.TabIndex = 15;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label3.Location = new System.Drawing.Point(4, 48);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(276, 16);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "（需要「加入參考」==>System.Configuration）";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label2.Location = new System.Drawing.Point(4, 32);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(193, 16);
            this.Label2.TabIndex = 13;
            this.Label2.Text = "連結字串，寫在App.Config檔裡面";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Label1.Location = new System.Drawing.Point(5, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(267, 20);
            this.Label1.TabIndex = 12;
            this.Label1.Text = "ADO.NET (DataReader) 跨平台使用";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.testtimeDataGridViewTextBoxColumn,
            this.classDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.summaryDataGridViewTextBoxColumn,
            this.articleDataGridViewTextBoxColumn,
            this.authorDataGridViewTextBoxColumn,
            this.hitnoDataGridViewTextBoxColumn,
            this.getnoDataGridViewTextBoxColumn,
            this.emailnoDataGridViewTextBoxColumn,
            this.approvedDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.testBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(7, 256);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(263, 150);
            this.dataGridView1.TabIndex = 17;
            // 
            // testDataSet
            // 
            this.testDataSet.DataSetName = "testDataSet";
            this.testDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // testBindingSource
            // 
            this.testBindingSource.DataMember = "test";
            this.testBindingSource.DataSource = this.testDataSet;
            // 
            // testTableAdapter
            // 
            this.testTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // testtimeDataGridViewTextBoxColumn
            // 
            this.testtimeDataGridViewTextBoxColumn.DataPropertyName = "test_time";
            this.testtimeDataGridViewTextBoxColumn.HeaderText = "test_time";
            this.testtimeDataGridViewTextBoxColumn.Name = "testtimeDataGridViewTextBoxColumn";
            // 
            // classDataGridViewTextBoxColumn
            // 
            this.classDataGridViewTextBoxColumn.DataPropertyName = "class";
            this.classDataGridViewTextBoxColumn.HeaderText = "class";
            this.classDataGridViewTextBoxColumn.Name = "classDataGridViewTextBoxColumn";
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // summaryDataGridViewTextBoxColumn
            // 
            this.summaryDataGridViewTextBoxColumn.DataPropertyName = "summary";
            this.summaryDataGridViewTextBoxColumn.HeaderText = "summary";
            this.summaryDataGridViewTextBoxColumn.Name = "summaryDataGridViewTextBoxColumn";
            // 
            // articleDataGridViewTextBoxColumn
            // 
            this.articleDataGridViewTextBoxColumn.DataPropertyName = "article";
            this.articleDataGridViewTextBoxColumn.HeaderText = "article";
            this.articleDataGridViewTextBoxColumn.Name = "articleDataGridViewTextBoxColumn";
            // 
            // authorDataGridViewTextBoxColumn
            // 
            this.authorDataGridViewTextBoxColumn.DataPropertyName = "author";
            this.authorDataGridViewTextBoxColumn.HeaderText = "author";
            this.authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            // 
            // hitnoDataGridViewTextBoxColumn
            // 
            this.hitnoDataGridViewTextBoxColumn.DataPropertyName = "hit_no";
            this.hitnoDataGridViewTextBoxColumn.HeaderText = "hit_no";
            this.hitnoDataGridViewTextBoxColumn.Name = "hitnoDataGridViewTextBoxColumn";
            // 
            // getnoDataGridViewTextBoxColumn
            // 
            this.getnoDataGridViewTextBoxColumn.DataPropertyName = "get_no";
            this.getnoDataGridViewTextBoxColumn.HeaderText = "get_no";
            this.getnoDataGridViewTextBoxColumn.Name = "getnoDataGridViewTextBoxColumn";
            // 
            // emailnoDataGridViewTextBoxColumn
            // 
            this.emailnoDataGridViewTextBoxColumn.DataPropertyName = "email_no";
            this.emailnoDataGridViewTextBoxColumn.HeaderText = "email_no";
            this.emailnoDataGridViewTextBoxColumn.Name = "emailnoDataGridViewTextBoxColumn";
            // 
            // approvedDataGridViewTextBoxColumn
            // 
            this.approvedDataGridViewTextBoxColumn.DataPropertyName = "approved";
            this.approvedDataGridViewTextBoxColumn.HeaderText = "approved";
            this.approvedDataGridViewTextBoxColumn.Name = "approvedDataGridViewTextBoxColumn";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 419);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Name = "Form2";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private testDataSet testDataSet;
        private System.Windows.Forms.BindingSource testBindingSource;
        private testDataSetTableAdapters.testTableAdapter testTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn testtimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn summaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn articleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hitnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn getnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailnoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn approvedDataGridViewTextBoxColumn;
    }
}

