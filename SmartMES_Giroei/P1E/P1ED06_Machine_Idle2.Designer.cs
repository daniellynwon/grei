namespace SmartMES_Giroei
{
    partial class P1ED06_Machine_Idle2
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P1ED06_Machine_Idle2));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.비가동일자DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.라인번호DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비가동시간합DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPMachineIdleinfo2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetP1E = new SmartMES_Giroei.P1E.DataSetP1E();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.비가동일자DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.라인번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.설비번호DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.설비명DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.비가동시간DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sPMachineIdleinfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblGraphTitle = new System.Windows.Forms.Label();
            this.TotalChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lbLine1Machine5 = new System.Windows.Forms.Label();
            this.lbLine1Machine4 = new System.Windows.Forms.Label();
            this.lbLine1Machine3 = new System.Windows.Forms.Label();
            this.lbLine1Machine2 = new System.Windows.Forms.Label();
            this.lbLine1Machine1 = new System.Windows.Forms.Label();
            this.lbTotalIdleTime1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbTotalIdleTime2 = new System.Windows.Forms.Label();
            this.lbLine2Machine1 = new System.Windows.Forms.Label();
            this.lbLine2Machine2 = new System.Windows.Forms.Label();
            this.lbLine2Machine3 = new System.Windows.Forms.Label();
            this.lbLine2Machine4 = new System.Windows.Forms.Label();
            this.lbLine2Machine5 = new System.Windows.Forms.Label();
            this.tbTotalIdleTime1 = new System.Windows.Forms.TextBox();
            this.tbLine1Machine1 = new System.Windows.Forms.TextBox();
            this.tbLine1Machine2 = new System.Windows.Forms.TextBox();
            this.tbLine1Machine3 = new System.Windows.Forms.TextBox();
            this.tbLine1Machine4 = new System.Windows.Forms.TextBox();
            this.tbLine1Machine5 = new System.Windows.Forms.TextBox();
            this.tbTotalIdleTime2 = new System.Windows.Forms.TextBox();
            this.tbLine2Machine1 = new System.Windows.Forms.TextBox();
            this.tbLine2Machine2 = new System.Windows.Forms.TextBox();
            this.tbLine2Machine3 = new System.Windows.Forms.TextBox();
            this.tbLine2Machine4 = new System.Windows.Forms.TextBox();
            this.tbLine2Machine5 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.Line1Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.Line2Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSelectDate = new System.Windows.Forms.DateTimePicker();
            this.panSearch = new System.Windows.Forms.Panel();
            this.sP_Machine_IdleinfoTableAdapter = new SmartMES_Giroei.P1E.DataSetP1ETableAdapters.SP_Machine_IdleinfoTableAdapter();
            this.sP_Machine_Idleinfo2TableAdapter = new SmartMES_Giroei.P1E.DataSetP1ETableAdapters.SP_Machine_Idleinfo2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPMachineIdleinfo2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1E)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPMachineIdleinfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalChart)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Line1Chart)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Line2Chart)).BeginInit();
            this.panSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Text = "설비비가동 정보";
            // 
            // pbPrint
            // 
            this.pbPrint.Image = global::SmartMES_Giroei.Properties.Resources.out_B;
            this.pbPrint.Click += new System.EventHandler(this.pbPrint_Click);
            // 
            // pbSave
            // 
            this.pbSave.Image = ((System.Drawing.Image)(resources.GetObject("pbSave.Image")));
            this.pbSave.Click += new System.EventHandler(this.pbSave_Click);
            // 
            // pbDel
            // 
            this.pbDel.Enabled = false;
            this.pbDel.Image = global::SmartMES_Giroei.Properties.Resources.del_B;
            this.pbDel.Click += new System.EventHandler(this.pbDel_Click);
            // 
            // pbAdd
            // 
            this.pbAdd.Enabled = false;
            this.pbAdd.Image = global::SmartMES_Giroei.Properties.Resources.add_B;
            this.pbAdd.Click += new System.EventHandler(this.pbAdd_Click);
            // 
            // pbSearch
            // 
            this.pbSearch.Click += new System.EventHandler(this.pbSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.lblGraphTitle);
            this.panel1.Controls.Add(this.TotalChart);
            this.panel1.Location = new System.Drawing.Point(2, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1323, 327);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.비가동일자DataGridViewTextBoxColumn1,
            this.라인번호DataGridViewTextBoxColumn1,
            this.비가동시간합DataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.sPMachineIdleinfo2BindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(587, 146);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(395, 178);
            this.dataGridView2.TabIndex = 4;
            this.dataGridView2.Visible = false;
            // 
            // 비가동일자DataGridViewTextBoxColumn1
            // 
            this.비가동일자DataGridViewTextBoxColumn1.DataPropertyName = "비가동일자";
            this.비가동일자DataGridViewTextBoxColumn1.HeaderText = "비가동일자";
            this.비가동일자DataGridViewTextBoxColumn1.Name = "비가동일자DataGridViewTextBoxColumn1";
            // 
            // 라인번호DataGridViewTextBoxColumn1
            // 
            this.라인번호DataGridViewTextBoxColumn1.DataPropertyName = "라인번호";
            this.라인번호DataGridViewTextBoxColumn1.HeaderText = "라인번호";
            this.라인번호DataGridViewTextBoxColumn1.Name = "라인번호DataGridViewTextBoxColumn1";
            // 
            // 비가동시간합DataGridViewTextBoxColumn
            // 
            this.비가동시간합DataGridViewTextBoxColumn.DataPropertyName = "비가동시간합";
            this.비가동시간합DataGridViewTextBoxColumn.HeaderText = "비가동시간합";
            this.비가동시간합DataGridViewTextBoxColumn.Name = "비가동시간합DataGridViewTextBoxColumn";
            // 
            // sPMachineIdleinfo2BindingSource
            // 
            this.sPMachineIdleinfo2BindingSource.DataMember = "SP_Machine_Idleinfo2";
            this.sPMachineIdleinfo2BindingSource.DataSource = this.dataSetP1E;
            // 
            // dataSetP1E
            // 
            this.dataSetP1E.DataSetName = "DataSetP1E";
            this.dataSetP1E.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.비가동일자DataGridViewTextBoxColumn,
            this.라인번호DataGridViewTextBoxColumn,
            this.설비번호DataGridViewTextBoxColumn,
            this.설비명DataGridViewTextBoxColumn,
            this.비가동시간DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.sPMachineIdleinfoBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 146);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(577, 178);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.Visible = false;
            // 
            // 비가동일자DataGridViewTextBoxColumn
            // 
            this.비가동일자DataGridViewTextBoxColumn.DataPropertyName = "비가동일자";
            this.비가동일자DataGridViewTextBoxColumn.HeaderText = "비가동일자";
            this.비가동일자DataGridViewTextBoxColumn.Name = "비가동일자DataGridViewTextBoxColumn";
            this.비가동일자DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 라인번호DataGridViewTextBoxColumn
            // 
            this.라인번호DataGridViewTextBoxColumn.DataPropertyName = "라인번호";
            this.라인번호DataGridViewTextBoxColumn.HeaderText = "라인번호";
            this.라인번호DataGridViewTextBoxColumn.Name = "라인번호DataGridViewTextBoxColumn";
            this.라인번호DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 설비번호DataGridViewTextBoxColumn
            // 
            this.설비번호DataGridViewTextBoxColumn.DataPropertyName = "설비번호";
            this.설비번호DataGridViewTextBoxColumn.HeaderText = "설비번호";
            this.설비번호DataGridViewTextBoxColumn.Name = "설비번호DataGridViewTextBoxColumn";
            this.설비번호DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 설비명DataGridViewTextBoxColumn
            // 
            this.설비명DataGridViewTextBoxColumn.DataPropertyName = "설비명";
            this.설비명DataGridViewTextBoxColumn.HeaderText = "설비명";
            this.설비명DataGridViewTextBoxColumn.Name = "설비명DataGridViewTextBoxColumn";
            this.설비명DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 비가동시간DataGridViewTextBoxColumn
            // 
            this.비가동시간DataGridViewTextBoxColumn.DataPropertyName = "비가동시간";
            this.비가동시간DataGridViewTextBoxColumn.HeaderText = "비가동시간";
            this.비가동시간DataGridViewTextBoxColumn.Name = "비가동시간DataGridViewTextBoxColumn";
            this.비가동시간DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sPMachineIdleinfoBindingSource
            // 
            this.sPMachineIdleinfoBindingSource.DataMember = "SP_Machine_Idleinfo";
            this.sPMachineIdleinfoBindingSource.DataSource = this.dataSetP1E;
            // 
            // lblGraphTitle
            // 
            this.lblGraphTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lblGraphTitle.Location = new System.Drawing.Point(3, 0);
            this.lblGraphTitle.Name = "lblGraphTitle";
            this.lblGraphTitle.Size = new System.Drawing.Size(1317, 32);
            this.lblGraphTitle.TabIndex = 2;
            this.lblGraphTitle.Text = "일별 비가동 차트";
            this.lblGraphTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TotalChart
            // 
            chartArea1.Name = "ChartArea1";
            this.TotalChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.TotalChart.Legends.Add(legend1);
            this.TotalChart.Location = new System.Drawing.Point(2, 35);
            this.TotalChart.Name = "TotalChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "1번 생산라인";
            series1.SmartLabelStyle.IsMarkerOverlappingAllowed = true;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "2번 생산라인";
            this.TotalChart.Series.Add(series1);
            this.TotalChart.Series.Add(series2);
            this.TotalChart.Size = new System.Drawing.Size(1317, 289);
            this.TotalChart.TabIndex = 0;
            this.TotalChart.Text = "chart1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Controls.Add(this.lbLine1Machine5, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbLine1Machine4, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbLine1Machine3, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbLine1Machine2, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbLine1Machine1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbTotalIdleTime1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbTotalIdleTime2, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbLine2Machine1, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbLine2Machine2, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbLine2Machine3, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbLine2Machine4, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbLine2Machine5, 6, 2);
            this.tableLayoutPanel2.Controls.Add(this.tbTotalIdleTime1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbLine1Machine1, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbLine1Machine2, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbLine1Machine3, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbLine1Machine4, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbLine1Machine5, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.tbTotalIdleTime2, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbLine2Machine1, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbLine2Machine2, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbLine2Machine3, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbLine2Machine4, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.tbLine2Machine5, 6, 3);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 468);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1321, 148);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // lbLine1Machine5
            // 
            this.lbLine1Machine5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lbLine1Machine5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLine1Machine5.Location = new System.Drawing.Point(1131, 0);
            this.lbLine1Machine5.Name = "lbLine1Machine5";
            this.lbLine1Machine5.Size = new System.Drawing.Size(187, 37);
            this.lbLine1Machine5.TabIndex = 6;
            this.lbLine1Machine5.Text = "5번설비";
            this.lbLine1Machine5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLine1Machine4
            // 
            this.lbLine1Machine4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lbLine1Machine4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLine1Machine4.Location = new System.Drawing.Point(943, 0);
            this.lbLine1Machine4.Name = "lbLine1Machine4";
            this.lbLine1Machine4.Size = new System.Drawing.Size(182, 37);
            this.lbLine1Machine4.TabIndex = 5;
            this.lbLine1Machine4.Text = "4번설비";
            this.lbLine1Machine4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLine1Machine3
            // 
            this.lbLine1Machine3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lbLine1Machine3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLine1Machine3.Location = new System.Drawing.Point(755, 0);
            this.lbLine1Machine3.Name = "lbLine1Machine3";
            this.lbLine1Machine3.Size = new System.Drawing.Size(182, 37);
            this.lbLine1Machine3.TabIndex = 4;
            this.lbLine1Machine3.Text = "3번설비";
            this.lbLine1Machine3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLine1Machine2
            // 
            this.lbLine1Machine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lbLine1Machine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLine1Machine2.Location = new System.Drawing.Point(567, 0);
            this.lbLine1Machine2.Name = "lbLine1Machine2";
            this.lbLine1Machine2.Size = new System.Drawing.Size(182, 37);
            this.lbLine1Machine2.TabIndex = 3;
            this.lbLine1Machine2.Text = "2번설비";
            this.lbLine1Machine2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLine1Machine1
            // 
            this.lbLine1Machine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lbLine1Machine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLine1Machine1.Location = new System.Drawing.Point(379, 0);
            this.lbLine1Machine1.Name = "lbLine1Machine1";
            this.lbLine1Machine1.Size = new System.Drawing.Size(182, 37);
            this.lbLine1Machine1.TabIndex = 2;
            this.lbLine1Machine1.Text = "1번설비";
            this.lbLine1Machine1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTotalIdleTime1
            // 
            this.lbTotalIdleTime1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lbTotalIdleTime1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTotalIdleTime1.Location = new System.Drawing.Point(191, 0);
            this.lbTotalIdleTime1.Name = "lbTotalIdleTime1";
            this.lbTotalIdleTime1.Size = new System.Drawing.Size(182, 37);
            this.lbTotalIdleTime1.TabIndex = 1;
            this.lbTotalIdleTime1.Text = "총비가동시간";
            this.lbTotalIdleTime1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.tableLayoutPanel2.SetRowSpan(this.label1, 2);
            this.label1.Size = new System.Drawing.Size(178, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "1번라인";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(5, 79);
            this.label9.Margin = new System.Windows.Forms.Padding(5);
            this.label9.Name = "label9";
            this.tableLayoutPanel2.SetRowSpan(this.label9, 2);
            this.label9.Size = new System.Drawing.Size(178, 64);
            this.label9.TabIndex = 9;
            this.label9.Text = "2번라인";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTotalIdleTime2
            // 
            this.lbTotalIdleTime2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lbTotalIdleTime2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTotalIdleTime2.Location = new System.Drawing.Point(191, 74);
            this.lbTotalIdleTime2.Name = "lbTotalIdleTime2";
            this.lbTotalIdleTime2.Size = new System.Drawing.Size(182, 37);
            this.lbTotalIdleTime2.TabIndex = 11;
            this.lbTotalIdleTime2.Text = "총비가동시간";
            this.lbTotalIdleTime2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLine2Machine1
            // 
            this.lbLine2Machine1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lbLine2Machine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLine2Machine1.Location = new System.Drawing.Point(379, 74);
            this.lbLine2Machine1.Name = "lbLine2Machine1";
            this.lbLine2Machine1.Size = new System.Drawing.Size(182, 37);
            this.lbLine2Machine1.TabIndex = 12;
            this.lbLine2Machine1.Text = "1번설비";
            this.lbLine2Machine1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLine2Machine2
            // 
            this.lbLine2Machine2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lbLine2Machine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLine2Machine2.Location = new System.Drawing.Point(567, 74);
            this.lbLine2Machine2.Name = "lbLine2Machine2";
            this.lbLine2Machine2.Size = new System.Drawing.Size(182, 37);
            this.lbLine2Machine2.TabIndex = 13;
            this.lbLine2Machine2.Text = "2번설비";
            this.lbLine2Machine2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLine2Machine3
            // 
            this.lbLine2Machine3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lbLine2Machine3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLine2Machine3.Location = new System.Drawing.Point(755, 74);
            this.lbLine2Machine3.Name = "lbLine2Machine3";
            this.lbLine2Machine3.Size = new System.Drawing.Size(182, 37);
            this.lbLine2Machine3.TabIndex = 14;
            this.lbLine2Machine3.Text = "3번설비";
            this.lbLine2Machine3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLine2Machine4
            // 
            this.lbLine2Machine4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lbLine2Machine4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLine2Machine4.Location = new System.Drawing.Point(943, 74);
            this.lbLine2Machine4.Name = "lbLine2Machine4";
            this.lbLine2Machine4.Size = new System.Drawing.Size(182, 37);
            this.lbLine2Machine4.TabIndex = 15;
            this.lbLine2Machine4.Text = "4번설비";
            this.lbLine2Machine4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLine2Machine5
            // 
            this.lbLine2Machine5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.lbLine2Machine5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLine2Machine5.Location = new System.Drawing.Point(1131, 74);
            this.lbLine2Machine5.Name = "lbLine2Machine5";
            this.lbLine2Machine5.Size = new System.Drawing.Size(187, 37);
            this.lbLine2Machine5.TabIndex = 16;
            this.lbLine2Machine5.Text = "5번설비";
            this.lbLine2Machine5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbTotalIdleTime1
            // 
            this.tbTotalIdleTime1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTotalIdleTime1.Location = new System.Drawing.Point(191, 40);
            this.tbTotalIdleTime1.Name = "tbTotalIdleTime1";
            this.tbTotalIdleTime1.ReadOnly = true;
            this.tbTotalIdleTime1.Size = new System.Drawing.Size(182, 29);
            this.tbTotalIdleTime1.TabIndex = 17;
            // 
            // tbLine1Machine1
            // 
            this.tbLine1Machine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLine1Machine1.Location = new System.Drawing.Point(379, 40);
            this.tbLine1Machine1.Name = "tbLine1Machine1";
            this.tbLine1Machine1.ReadOnly = true;
            this.tbLine1Machine1.Size = new System.Drawing.Size(182, 29);
            this.tbLine1Machine1.TabIndex = 18;
            // 
            // tbLine1Machine2
            // 
            this.tbLine1Machine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLine1Machine2.Location = new System.Drawing.Point(567, 40);
            this.tbLine1Machine2.Name = "tbLine1Machine2";
            this.tbLine1Machine2.ReadOnly = true;
            this.tbLine1Machine2.Size = new System.Drawing.Size(182, 29);
            this.tbLine1Machine2.TabIndex = 19;
            // 
            // tbLine1Machine3
            // 
            this.tbLine1Machine3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLine1Machine3.Location = new System.Drawing.Point(755, 40);
            this.tbLine1Machine3.Name = "tbLine1Machine3";
            this.tbLine1Machine3.ReadOnly = true;
            this.tbLine1Machine3.Size = new System.Drawing.Size(182, 29);
            this.tbLine1Machine3.TabIndex = 20;
            // 
            // tbLine1Machine4
            // 
            this.tbLine1Machine4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLine1Machine4.Location = new System.Drawing.Point(943, 40);
            this.tbLine1Machine4.Name = "tbLine1Machine4";
            this.tbLine1Machine4.ReadOnly = true;
            this.tbLine1Machine4.Size = new System.Drawing.Size(182, 29);
            this.tbLine1Machine4.TabIndex = 21;
            // 
            // tbLine1Machine5
            // 
            this.tbLine1Machine5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLine1Machine5.Location = new System.Drawing.Point(1131, 40);
            this.tbLine1Machine5.Name = "tbLine1Machine5";
            this.tbLine1Machine5.ReadOnly = true;
            this.tbLine1Machine5.Size = new System.Drawing.Size(187, 29);
            this.tbLine1Machine5.TabIndex = 22;
            // 
            // tbTotalIdleTime2
            // 
            this.tbTotalIdleTime2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTotalIdleTime2.Location = new System.Drawing.Point(191, 114);
            this.tbTotalIdleTime2.Name = "tbTotalIdleTime2";
            this.tbTotalIdleTime2.ReadOnly = true;
            this.tbTotalIdleTime2.Size = new System.Drawing.Size(182, 29);
            this.tbTotalIdleTime2.TabIndex = 23;
            // 
            // tbLine2Machine1
            // 
            this.tbLine2Machine1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLine2Machine1.Location = new System.Drawing.Point(379, 114);
            this.tbLine2Machine1.Name = "tbLine2Machine1";
            this.tbLine2Machine1.ReadOnly = true;
            this.tbLine2Machine1.Size = new System.Drawing.Size(182, 29);
            this.tbLine2Machine1.TabIndex = 24;
            // 
            // tbLine2Machine2
            // 
            this.tbLine2Machine2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLine2Machine2.Location = new System.Drawing.Point(567, 114);
            this.tbLine2Machine2.Name = "tbLine2Machine2";
            this.tbLine2Machine2.ReadOnly = true;
            this.tbLine2Machine2.Size = new System.Drawing.Size(182, 29);
            this.tbLine2Machine2.TabIndex = 25;
            // 
            // tbLine2Machine3
            // 
            this.tbLine2Machine3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLine2Machine3.Location = new System.Drawing.Point(755, 114);
            this.tbLine2Machine3.Name = "tbLine2Machine3";
            this.tbLine2Machine3.ReadOnly = true;
            this.tbLine2Machine3.Size = new System.Drawing.Size(182, 29);
            this.tbLine2Machine3.TabIndex = 26;
            // 
            // tbLine2Machine4
            // 
            this.tbLine2Machine4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLine2Machine4.Location = new System.Drawing.Point(943, 114);
            this.tbLine2Machine4.Name = "tbLine2Machine4";
            this.tbLine2Machine4.ReadOnly = true;
            this.tbLine2Machine4.Size = new System.Drawing.Size(182, 29);
            this.tbLine2Machine4.TabIndex = 27;
            // 
            // tbLine2Machine5
            // 
            this.tbLine2Machine5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLine2Machine5.Location = new System.Drawing.Point(1131, 114);
            this.tbLine2Machine5.Name = "tbLine2Machine5";
            this.tbLine2Machine5.ReadOnly = true;
            this.tbLine2Machine5.Size = new System.Drawing.Size(187, 29);
            this.tbLine2Machine5.TabIndex = 28;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.Line1Chart);
            this.panel2.Location = new System.Drawing.Point(4, 619);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 370);
            this.panel2.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(657, 32);
            this.label10.TabIndex = 2;
            this.label10.Text = "1번라인";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Line1Chart
            // 
            chartArea2.Name = "ChartArea1";
            this.Line1Chart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Line1Chart.Legends.Add(legend2);
            this.Line1Chart.Location = new System.Drawing.Point(2, 35);
            this.Line1Chart.Name = "Line1Chart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series3.CustomProperties = "PieStartAngle=270";
            series3.IsValueShownAsLabel = true;
            series3.Legend = "Legend1";
            series3.Name = "Line1";
            this.Line1Chart.Series.Add(series3);
            this.Line1Chart.Size = new System.Drawing.Size(659, 332);
            this.Line1Chart.TabIndex = 0;
            this.Line1Chart.Text = "chart2";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.Line2Chart);
            this.panel3.Location = new System.Drawing.Point(667, 619);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(658, 367);
            this.panel3.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(123)))), ((int)(((byte)(157)))));
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(658, 32);
            this.label11.TabIndex = 2;
            this.label11.Text = "2번라인";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Line2Chart
            // 
            chartArea3.Name = "ChartArea1";
            this.Line2Chart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.Line2Chart.Legends.Add(legend3);
            this.Line2Chart.Location = new System.Drawing.Point(7, 35);
            this.Line2Chart.Name = "Line2Chart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series4.CustomProperties = "PieStartAngle=270";
            series4.IsValueShownAsLabel = true;
            series4.Legend = "Legend1";
            series4.Name = "Line2";
            this.Line2Chart.Series.Add(series4);
            this.Line2Chart.Size = new System.Drawing.Size(645, 329);
            this.Line2Chart.TabIndex = 0;
            this.Line2Chart.Text = "chart3";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(9, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "검색년월 :";
            // 
            // dtpSelectDate
            // 
            this.dtpSelectDate.CustomFormat = "yyyy-MM";
            this.dtpSelectDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSelectDate.Location = new System.Drawing.Point(99, 17);
            this.dtpSelectDate.Name = "dtpSelectDate";
            this.dtpSelectDate.ShowUpDown = true;
            this.dtpSelectDate.Size = new System.Drawing.Size(92, 29);
            this.dtpSelectDate.TabIndex = 8;
            this.dtpSelectDate.ValueChanged += new System.EventHandler(this.dtpSelectDate_ValueChanged);
            // 
            // panSearch
            // 
            this.panSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panSearch.AutoSize = true;
            this.panSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(205)))), ((int)(((byte)(219)))));
            this.panSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSearch.Controls.Add(this.dtpSelectDate);
            this.panSearch.Controls.Add(this.label3);
            this.panSearch.Location = new System.Drawing.Point(2, 58);
            this.panSearch.Name = "panSearch";
            this.panSearch.Size = new System.Drawing.Size(1319, 71);
            this.panSearch.TabIndex = 0;
            // 
            // sP_Machine_IdleinfoTableAdapter
            // 
            this.sP_Machine_IdleinfoTableAdapter.ClearBeforeFill = true;
            // 
            // sP_Machine_Idleinfo2TableAdapter
            // 
            this.sP_Machine_Idleinfo2TableAdapter.ClearBeforeFill = true;
            // 
            // P1ED06_Machine_Idle2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.ClientSize = new System.Drawing.Size(1325, 990);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panSearch);
            this.Name = "P1ED06_Machine_Idle2";
            this.Text = "`";
            this.Load += new System.EventHandler(this.P1ED06_Machine_Idle2_Load);
            this.Controls.SetChildIndex(this.panSearch, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel2, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPMachineIdleinfo2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetP1E)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPMachineIdleinfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalChart)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Line1Chart)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Line2Chart)).EndInit();
            this.panSearch.ResumeLayout(false);
            this.panSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart TotalChart;
        private System.Windows.Forms.Label lblGraphTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lbLine1Machine5;
        private System.Windows.Forms.Label lbLine1Machine4;
        private System.Windows.Forms.Label lbLine1Machine3;
        private System.Windows.Forms.Label lbLine1Machine2;
        private System.Windows.Forms.Label lbLine1Machine1;
        private System.Windows.Forms.Label lbTotalIdleTime1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbTotalIdleTime2;
        private System.Windows.Forms.Label lbLine2Machine1;
        private System.Windows.Forms.Label lbLine2Machine2;
        private System.Windows.Forms.Label lbLine2Machine3;
        private System.Windows.Forms.Label lbLine2Machine4;
        private System.Windows.Forms.Label lbLine2Machine5;
        private System.Windows.Forms.TextBox tbTotalIdleTime1;
        private System.Windows.Forms.TextBox tbLine1Machine1;
        private System.Windows.Forms.TextBox tbLine1Machine2;
        private System.Windows.Forms.TextBox tbLine1Machine3;
        private System.Windows.Forms.TextBox tbLine1Machine4;
        private System.Windows.Forms.TextBox tbLine1Machine5;
        private System.Windows.Forms.TextBox tbTotalIdleTime2;
        private System.Windows.Forms.TextBox tbLine2Machine1;
        private System.Windows.Forms.TextBox tbLine2Machine2;
        private System.Windows.Forms.TextBox tbLine2Machine3;
        private System.Windows.Forms.TextBox tbLine2Machine4;
        private System.Windows.Forms.TextBox tbLine2Machine5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataVisualization.Charting.Chart Line1Chart;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataVisualization.Charting.Chart Line2Chart;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpSelectDate;
        private System.Windows.Forms.Panel panSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비가동일자DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 라인번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 설비번호DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 설비명DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비가동시간DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sPMachineIdleinfoBindingSource;
        private P1E.DataSetP1E dataSetP1E;
        private P1E.DataSetP1ETableAdapters.SP_Machine_IdleinfoTableAdapter sP_Machine_IdleinfoTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비가동일자DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 라인번호DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 비가동시간합DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource sPMachineIdleinfo2BindingSource;
        private P1E.DataSetP1ETableAdapters.SP_Machine_Idleinfo2TableAdapter sP_Machine_Idleinfo2TableAdapter;
    }
}
