using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;

namespace DXWinFormTest
{
    public partial class frmMasterDetail : XtraForm
    {
        public frmMasterDetail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 绑定数据源
        /// </summary>
        private void BindData()
        {
            //创建测试数据
            var result1 = new Detail2Result()
            {
                Name = "测试1",
                Description = "描述内容",
                Detail2List = new List<DetailInfo>()
                {
                    new DetailInfo()
                    {
                        Name = "111测试",
                        Description = "111描述内容"
                    },
                    new DetailInfo()
                    {
                        Name = "222测试",
                        Description = "222描述内容"
                    },
                    new DetailInfo()
                    {
                        Name = "333测试",
                        Description = "333描述内容"
                    }
                }
            };

            var result2 = new Detail2Result()
            {
                Name = "测试2",
                Description = "描述内容",
                Detail2List = new List<DetailInfo>()
                {
                    new DetailInfo()
                    {
                        Name = "111测试",
                        Description = "111描述内容"
                    },
                    new DetailInfo()
                    {
                        Name = "222测试",
                        Description = "222描述内容"
                    },
                    new DetailInfo()
                    {
                        Name = "333测试",
                        Description = "333描述内容"
                    }
                }
            };

            //构造一个记录的集合
            var list = new List<Detail2Result>() { result1, result2 };

            //绑定数据源
            this.gridControl.DataSource = list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //子表格获取行数据
            DevExpress.XtraGrid.Views.Grid.GridView currentView = (DevExpress.XtraGrid.Views.Grid.GridView)this.gridControl.FocusedView;
            DetailInfo focusRow = currentView.GetFocusedRow() as DetailInfo; //用在事件中：currentView.GetRow(e.RowHandle) as DetailInfo;
            XtraMessageBox.Show(focusRow.Name);
        }
    }

    /// <summary>
    /// 记录基础信息
    /// </summary>
    public class DetailInfo
    {
        public DetailInfo()
        {
            this.ID = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// ID标识
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }
    }

    /// <summary>
    /// 二级层次的列表
    /// </summary>
    public class Detail2Result : DetailInfo
    {
        public List<DetailInfo> Detail2List { get; set; }
    }
}