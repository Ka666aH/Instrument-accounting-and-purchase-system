namespace Система_учёта_и_приобретения_инструмента
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tOOLACCOUNTINGDataSet = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSet();
            this.toolGroups1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolGroups1TableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.ToolGroups1TableAdapter();
            this.groupIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startRangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolGroups1Nomenclature1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nomenclature1TableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.Nomenclature1TableAdapter();
            this.nomenclatureNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.designationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuttingMaterialDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.normativeDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usageFlagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minStockLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tOOLACCOUNTINGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolGroups1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolGroups1Nomenclature1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.groupIDDataGridViewTextBoxColumn,
            this.groupNameDataGridViewTextBoxColumn,
            this.startRangeDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.toolGroups1BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(24, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(390, 142);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomenclatureNumberDataGridViewTextBoxColumn,
            this.groupIDDataGridViewTextBoxColumn1,
            this.nameDataGridViewTextBoxColumn,
            this.designationDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.typeSizeDataGridViewTextBoxColumn,
            this.cuttingMaterialDataGridViewTextBoxColumn,
            this.normativeDocDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.usageFlagDataGridViewTextBoxColumn,
            this.minStockLevelDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.toolGroups1Nomenclature1BindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(24, 232);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(390, 142);
            this.dataGridView2.TabIndex = 1;
            // 
            // tOOLACCOUNTINGDataSet
            // 
            this.tOOLACCOUNTINGDataSet.DataSetName = "TOOLACCOUNTINGDataSet";
            this.tOOLACCOUNTINGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolGroups1BindingSource
            // 
            this.toolGroups1BindingSource.DataMember = "ToolGroups1";
            this.toolGroups1BindingSource.DataSource = this.tOOLACCOUNTINGDataSet;
            // 
            // toolGroups1TableAdapter
            // 
            this.toolGroups1TableAdapter.ClearBeforeFill = true;
            // 
            // groupIDDataGridViewTextBoxColumn
            // 
            this.groupIDDataGridViewTextBoxColumn.DataPropertyName = "GroupID";
            this.groupIDDataGridViewTextBoxColumn.HeaderText = "GroupID";
            this.groupIDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.groupIDDataGridViewTextBoxColumn.Name = "groupIDDataGridViewTextBoxColumn";
            this.groupIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.groupIDDataGridViewTextBoxColumn.Width = 125;
            // 
            // groupNameDataGridViewTextBoxColumn
            // 
            this.groupNameDataGridViewTextBoxColumn.DataPropertyName = "GroupName";
            this.groupNameDataGridViewTextBoxColumn.HeaderText = "GroupName";
            this.groupNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
            this.groupNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // startRangeDataGridViewTextBoxColumn
            // 
            this.startRangeDataGridViewTextBoxColumn.DataPropertyName = "StartRange";
            this.startRangeDataGridViewTextBoxColumn.HeaderText = "StartRange";
            this.startRangeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.startRangeDataGridViewTextBoxColumn.Name = "startRangeDataGridViewTextBoxColumn";
            this.startRangeDataGridViewTextBoxColumn.Width = 125;
            // 
            // toolGroups1Nomenclature1BindingSource
            // 
            this.toolGroups1Nomenclature1BindingSource.DataMember = "ToolGroups1_Nomenclature1";
            this.toolGroups1Nomenclature1BindingSource.DataSource = this.toolGroups1BindingSource;
            // 
            // nomenclature1TableAdapter
            // 
            this.nomenclature1TableAdapter.ClearBeforeFill = true;
            // 
            // nomenclatureNumberDataGridViewTextBoxColumn
            // 
            this.nomenclatureNumberDataGridViewTextBoxColumn.DataPropertyName = "NomenclatureNumber";
            this.nomenclatureNumberDataGridViewTextBoxColumn.HeaderText = "NomenclatureNumber";
            this.nomenclatureNumberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nomenclatureNumberDataGridViewTextBoxColumn.Name = "nomenclatureNumberDataGridViewTextBoxColumn";
            this.nomenclatureNumberDataGridViewTextBoxColumn.Width = 125;
            // 
            // groupIDDataGridViewTextBoxColumn1
            // 
            this.groupIDDataGridViewTextBoxColumn1.DataPropertyName = "GroupID";
            this.groupIDDataGridViewTextBoxColumn1.HeaderText = "GroupID";
            this.groupIDDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.groupIDDataGridViewTextBoxColumn1.Name = "groupIDDataGridViewTextBoxColumn1";
            this.groupIDDataGridViewTextBoxColumn1.Width = 125;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // designationDataGridViewTextBoxColumn
            // 
            this.designationDataGridViewTextBoxColumn.DataPropertyName = "Designation";
            this.designationDataGridViewTextBoxColumn.HeaderText = "Designation";
            this.designationDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.designationDataGridViewTextBoxColumn.Name = "designationDataGridViewTextBoxColumn";
            this.designationDataGridViewTextBoxColumn.Width = 125;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 125;
            // 
            // typeSizeDataGridViewTextBoxColumn
            // 
            this.typeSizeDataGridViewTextBoxColumn.DataPropertyName = "TypeSize";
            this.typeSizeDataGridViewTextBoxColumn.HeaderText = "TypeSize";
            this.typeSizeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.typeSizeDataGridViewTextBoxColumn.Name = "typeSizeDataGridViewTextBoxColumn";
            this.typeSizeDataGridViewTextBoxColumn.Width = 125;
            // 
            // cuttingMaterialDataGridViewTextBoxColumn
            // 
            this.cuttingMaterialDataGridViewTextBoxColumn.DataPropertyName = "CuttingMaterial";
            this.cuttingMaterialDataGridViewTextBoxColumn.HeaderText = "CuttingMaterial";
            this.cuttingMaterialDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.cuttingMaterialDataGridViewTextBoxColumn.Name = "cuttingMaterialDataGridViewTextBoxColumn";
            this.cuttingMaterialDataGridViewTextBoxColumn.Width = 125;
            // 
            // normativeDocDataGridViewTextBoxColumn
            // 
            this.normativeDocDataGridViewTextBoxColumn.DataPropertyName = "NormativeDoc";
            this.normativeDocDataGridViewTextBoxColumn.HeaderText = "NormativeDoc";
            this.normativeDocDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.normativeDocDataGridViewTextBoxColumn.Name = "normativeDocDataGridViewTextBoxColumn";
            this.normativeDocDataGridViewTextBoxColumn.Width = 125;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.Width = 125;
            // 
            // usageFlagDataGridViewTextBoxColumn
            // 
            this.usageFlagDataGridViewTextBoxColumn.DataPropertyName = "UsageFlag";
            this.usageFlagDataGridViewTextBoxColumn.HeaderText = "UsageFlag";
            this.usageFlagDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.usageFlagDataGridViewTextBoxColumn.Name = "usageFlagDataGridViewTextBoxColumn";
            this.usageFlagDataGridViewTextBoxColumn.Width = 125;
            // 
            // minStockLevelDataGridViewTextBoxColumn
            // 
            this.minStockLevelDataGridViewTextBoxColumn.DataPropertyName = "MinStockLevel";
            this.minStockLevelDataGridViewTextBoxColumn.HeaderText = "MinStockLevel";
            this.minStockLevelDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.minStockLevelDataGridViewTextBoxColumn.Name = "minStockLevelDataGridViewTextBoxColumn";
            this.minStockLevelDataGridViewTextBoxColumn.Width = 125;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            this.fullNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fullNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tOOLACCOUNTINGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolGroups1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toolGroups1Nomenclature1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private TOOLACCOUNTINGDataSet tOOLACCOUNTINGDataSet;
        private System.Windows.Forms.BindingSource toolGroups1BindingSource;
        private TOOLACCOUNTINGDataSetTableAdapters.ToolGroups1TableAdapter toolGroups1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startRangeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource toolGroups1Nomenclature1BindingSource;
        private TOOLACCOUNTINGDataSetTableAdapters.Nomenclature1TableAdapter nomenclature1TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomenclatureNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn designationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuttingMaterialDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn normativeDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usageFlagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minStockLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
    }
}