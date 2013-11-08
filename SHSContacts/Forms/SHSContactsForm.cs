using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Campus.Report;
using SHSchool.Data;
using Aspose.Words;
using Aspose.BarCode;
using Aspose.Words.Drawing;
using System.Drawing.Imaging;
using Aspose.Words.Reporting;
using K12.Data;



namespace SHSContacts.Forms
{
    public partial class SHSContactsForm : FISCA.Presentation.Controls.BaseForm
    {
        BackgroundWorker _bgWorker;
        private string _ReportName = "學生通訊錄郵寄格式樣板";
        private ReportConfiguration _Config;
        List<string> _StudentIDList;
        List<string> _ClassIDList;
        int count = 8;
        // 學生基本
        Dictionary<string, SHStudentRecord> _StudentRecDict = new Dictionary<string, SHStudentRecord>();

        // 班級學生二個基本(new)
        Dictionary<string, SHClassRecord> _ClassStuRecDict = new Dictionary<string, SHClassRecord>();

        // 電話
        Dictionary<string, SHPhoneRecord> _PhoneRecDict = new Dictionary<string, SHPhoneRecord>();

        // 父母監護人
        Dictionary<string, SHParentRecord> _ParentRecDict = new Dictionary<string, SHParentRecord>();

        // 地址
        Dictionary<string, AddressRecord> _AddressRecDict = new Dictionary<string, AddressRecord>();

        // 入學照片
        Dictionary<string, string> _PhotoPDict = new Dictionary<string, string>();

        // 畢業照片
        Dictionary<string, string> _PhotoGDict = new Dictionary<string, string>();

        DataTable _DataTable;

        public SHSContactsForm(List<string> StudentIDList, List<string> ClassIDList)
        {
            InitializeComponent();

            _StudentIDList = StudentIDList;
            _ClassIDList = ClassIDList;                //新加
            radiobtnCustodianName.Checked = true;       //新加
            radiobtnPermanentAddress.Checked = true;        //新加
            _bgWorker = new BackgroundWorker();
            _bgWorker.DoWork += new DoWorkEventHandler(_bgWorker_DoWork);
            _bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_bgWorker_RunWorkerCompleted);
            _bgWorker.WorkerReportsProgress = true;
            _bgWorker.ProgressChanged += new ProgressChangedEventHandler(_bgWorker_ProgressChanged);
        }

        void _bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            FISCA.Presentation.MotherForm.SetStatusBarMessage("學生通訊錄郵寄格式產生中", e.ProgressPercentage);
        }

        private void AddTableColumns()
        {
            _DataTable.Columns.Add("學校名稱");
            _DataTable.Columns.Add("科別");
            _DataTable.Columns.Add("班級");       //新加
            _DataTable.Columns.Add("學號");
            _DataTable.Columns.Add("座號");       //新加
            _DataTable.Columns.Add("姓名");
            _DataTable.Columns.Add("英文姓名");
            _DataTable.Columns.Add("性別");
            _DataTable.Columns.Add("身分證字號");
            _DataTable.Columns.Add("生日"); // 西元
            _DataTable.Columns.Add("生日2"); // 民國
            _DataTable.Columns.Add("戶籍電話");
            _DataTable.Columns.Add("聯絡電話");
            _DataTable.Columns.Add("監護人電話");
            _DataTable.Columns.Add("父親電話");
            _DataTable.Columns.Add("母親電話");
            _DataTable.Columns.Add("監護人姓名");
            _DataTable.Columns.Add("父親姓名");
            _DataTable.Columns.Add("母親姓名");
            _DataTable.Columns.Add("戶籍地址");
            _DataTable.Columns.Add("聯絡地址");
            _DataTable.Columns.Add("其它地址"); //新加
            _DataTable.Columns.Add("照片"); // 1吋
            _DataTable.Columns.Add("照片2"); // 2吋
            _DataTable.Columns.Add("畢業照片"); // 1吋
            _DataTable.Columns.Add("畢業照片2"); // 2吋

            _DataTable.Columns.Add("條碼"); // 學號
        }

        void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnPrint.Enabled = true;

            if (e.Error != null)
            {
                FISCA.Presentation.Controls.MsgBox.Show("產生過程發生錯誤:" + e.Error.Message);
                return;
            }

            FISCA.Presentation.MotherForm.SetStatusBarMessage("學生通訊錄郵寄格式產生完成。", 100);

            Document document = (Document)e.Result;
            string inputReportName = "學生通訊錄郵寄格式";
            string reportName = inputReportName;

            string path = Path.Combine(System.Windows.Forms.Application.StartupPath, "Reports");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = Path.Combine(path, reportName + ".doc");  //設定檔案路徑

            if (File.Exists(path))   //主要是下載與列印時的路徑
            {
                int i = 1;
                while (true)
                {
                    string newPath = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + (i++) + Path.GetExtension(path);
                    if (!File.Exists(newPath))
                    {
                        path = newPath;
                        break;
                    }
                }
            }

            try
            {
                document.Save(path, Aspose.Words.SaveFormat.Doc);
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                System.Windows.Forms.SaveFileDialog sd = new System.Windows.Forms.SaveFileDialog();
                sd.Title = "另存新檔";
                sd.FileName = reportName + ".doc";
                sd.Filter = "Word檔案 (*.doc)|*.doc|所有檔案 (*.*)|*.*";
                if (sd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        document.Save(sd.FileName, Aspose.Words.SaveFormat.Doc);

                    }
                    catch
                    {
                        FISCA.Presentation.Controls.MsgBox.Show("指定路徑無法存取。", "建立檔案失敗", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _DataTable = new DataTable();
            // 新增 DataTable Columns
            AddTableColumns();

            _bgWorker.ReportProgress(1);
            // word 資料合併
            Document doc = new Document();
            doc.Sections.Clear();

            // 取得資料
            _StudentRecDict.Clear();
            foreach (SHStudentRecord rec in SHStudent.SelectByIDs(_StudentIDList))
            {
                if (!_StudentRecDict.ContainsKey(rec.ID))  //假如沒有這個ID才加入
                {
                    _StudentRecDict.Add(rec.ID, rec);
                }
            }
            //新加
            _ClassStuRecDict.Clear();
            foreach (SHStudentRecord rec in _StudentRecDict.Values)
            {
                if (rec.RefClassID != "")
                {
                    SHClassRecord _class = SHClass.SelectByID(rec.RefClassID);
                    if (!_ClassStuRecDict.ContainsKey(_class.ID))
                    {
                        _ClassStuRecDict.Add(rec.ID, _class);
                    }
                }

                //foreach (SHClassRecord recCla in SHClass.SelectByIDs(_ClassIDList))
                //{
                //    if (rec.RefClassID == recCla.ID)
                //    {
                //        _ClassStuRecDict.Add(rec.ID, recCla);
                //    }
                //}
            }

            _PhoneRecDict.Clear();
            foreach (SHPhoneRecord rec in SHPhone.SelectByStudentIDs(_StudentIDList))
                _PhoneRecDict.Add(rec.RefStudentID, rec);

            // 入學照片
            _PhotoPDict.Clear();
            _PhotoPDict = K12.Data.Photo.SelectFreshmanPhoto(_StudentIDList);

            // 畢業照片
            _PhotoGDict.Clear();
            _PhotoGDict = K12.Data.Photo.SelectGraduatePhoto(_StudentIDList);

            //監護人(父母親)
            _ParentRecDict.Clear();
            foreach (SHParentRecord rec in SHParent.SelectByStudentIDs(_StudentIDList))
                _ParentRecDict.Add(rec.RefStudentID, rec);

            //地址
            _AddressRecDict.Clear();
            foreach (SHAddressRecord rec in SHAddress.SelectByStudentIDs(_StudentIDList))
                _AddressRecDict.Add(rec.RefStudentID, rec);

            // 學校名稱
            string SchoolName = K12.Data.School.ChineseName;

            _bgWorker.ReportProgress(30);



            // 開始填入資料
            foreach (string StudID in _StudentIDList)
            {

                DataRow row = _DataTable.NewRow();

                row["學校名稱"] = SchoolName;
                if (_StudentRecDict.ContainsKey(StudID))
                {
                    if (_StudentRecDict[StudID].Department != null)
                        row["科別"] = _StudentRecDict[StudID].Department.FullName;
                    else
                        row["科別"] = "";

                    row["班級"] = _ClassStuRecDict[StudID].Name;//新加
                    row["學號"] = _StudentRecDict[StudID].StudentNumber;
                    row["座號"] = _StudentRecDict[StudID].SeatNo;
                    row["條碼"] = _StudentRecDict[StudID].StudentNumber;
                    row["姓名"] = _StudentRecDict[StudID].Name;
                    row["英文姓名"] = _StudentRecDict[StudID].EnglishName;
                    row["性別"] = _StudentRecDict[StudID].Gender;
                    row["身分證字號"] = _StudentRecDict[StudID].IDNumber;
                    if (_StudentRecDict[StudID].Birthday.HasValue)
                    {
                        DateTime dtb = _StudentRecDict[StudID].Birthday.Value;
                        row["生日"] = dtb.Year + "/" + dtb.Month + "/" + dtb.Day;
                        row["生日2"] = (dtb.Year - 1911) + "/" + dtb.Month + "/" + dtb.Day;
                    }
                    else
                    {
                        row["生日"] = "";
                        row["生日2"] = "";
                    }
                }

                if (_PhotoPDict.ContainsKey(StudID))
                {
                    row["照片"] = _PhotoPDict[StudID];
                    row["照片2"] = _PhotoPDict[StudID];
                }

                if (_PhotoGDict.ContainsKey(StudID))
                {
                    row["畢業照片"] = _PhotoGDict[StudID];
                    row["畢業照片2"] = _PhotoGDict[StudID];
                }


                if (_PhoneRecDict.ContainsKey(StudID))
                {
                    row["戶籍電話"] = _PhoneRecDict[StudID].Permanent;
                    row["聯絡電話"] = _PhoneRecDict[StudID].Contact;
                }

                if (_ParentRecDict.ContainsKey(StudID))
                {
                    row["監護人電話"] = _ParentRecDict[StudID].CustodianPhone;
                    row["父親電話"] = _ParentRecDict[StudID].FatherPhone;
                    row["母親電話"] = _ParentRecDict[StudID].MotherPhone;
                    //新加
                    if (radiobtnCustodianName.Checked)
                    {
                        row["監護人姓名"] = _ParentRecDict[StudID].CustodianName;
                    }
                    else if (radiobtnFatherName.Checked)
                    {
                        row["父親姓名"] = _ParentRecDict[StudID].FatherName;
                    }
                    else
                    {
                        row["母親姓名"] = _ParentRecDict[StudID].MotherName;
                    }
                }

                if (_AddressRecDict.ContainsKey(StudID))
                {
                    //新加
                    if (radiobtnPermanentAddress.Checked)
                    {
                        row["戶籍地址"] = _AddressRecDict[StudID].PermanentAddress;
                    }
                    else if (radiobtnMailingAddress.Checked)
                    {
                        row["聯絡地址"] = _AddressRecDict[StudID].MailingAddress;
                    }
                    else
                    {
                        row["其它地址"] = _AddressRecDict[StudID].Address1;//新加
                    }
                }


                _DataTable.Rows.Add(row);

            }



            _bgWorker.ReportProgress(70);
            int page = 1;

            count = 0;
            List<string> mapNameList = _Config.Template.ToDocument().MailMerge.GetFieldNames().ToList();
            foreach (string str in mapNameList)
                if (str == "姓名")
                    count++;



            for (int i = 1; i <= _StudentIDList.Count; i++)
                if (i % count == 0 && i >= count)
                    page++;

            // 當人數與一頁個數相同,只有一頁
            if (count == _StudentIDList.Count)
                page = 1;

            for (int i = 1; i <= page; i++)
            {
                Document document = new Document();
                document = _Config.Template.ToDocument();
                doc.Sections.Add(doc.ImportNode(document.Sections[0], true));
            }
            doc.MailMerge.MergeField += new Aspose.Words.Reporting.MergeFieldEventHandler(MailMerge_MergeField);
            doc.MailMerge.Execute(_DataTable);
            doc.MailMerge.RemoveEmptyParagraphs = true;
            doc.MailMerge.DeleteFields();
            //doc.Sections.Add(doc.ImportNode(document.Sections[0], true));
            _bgWorker.ReportProgress(95);
            e.Result = doc;
        }


        void MailMerge_MergeField(object sender, Aspose.Words.Reporting.MergeFieldEventArgs e)
        {

            if (e.FieldName == "照片" || e.FieldName == "照片2")
            {
                if (e.FieldValue != null)
                {
                    byte[] photo = Convert.FromBase64String(e.FieldValue.ToString()); //e.FieldValue as byte[];

                    if (photo != null && photo.Length > 0)
                    {
                        DocumentBuilder photoBuilder = new DocumentBuilder(e.Document);
                        photoBuilder.MoveToField(e.Field, true);
                        e.Field.Remove();
                        //Paragraph paragraph = photoBuilder.InsertParagraph();// new Paragraph(e.Document);
                        Shape photoShape = new Shape(e.Document, ShapeType.Image);
                        photoShape.ImageData.SetImage(photo);
                        photoShape.WrapType = WrapType.Inline;
                        //Cell cell = photoBuilder.CurrentParagraph.ParentNode as Cell;
                        //cell.CellFormat.LeftPadding = 0;
                        //cell.CellFormat.RightPadding = 0;
                        if (e.FieldName == "照片")
                        {
                            // 1吋
                            photoShape.Width = ConvertUtil.MillimeterToPoint(25);
                            photoShape.Height = ConvertUtil.MillimeterToPoint(35);
                        }
                        else
                        {
                            //2吋
                            photoShape.Width = ConvertUtil.MillimeterToPoint(35);
                            photoShape.Height = ConvertUtil.MillimeterToPoint(45);
                        }
                        //paragraph.AppendChild(photoShape);
                        photoBuilder.InsertNode(photoShape);
                    }
                }
            }

            if (e.FieldName == "畢業照片" || e.FieldName == "畢業照片2")
            {
                if (e.FieldValue != null)
                {
                    byte[] photo = Convert.FromBase64String(e.FieldValue.ToString()); //e.FieldValue as byte[];

                    if (photo != null && photo.Length > 0)
                    {
                        DocumentBuilder photoBuilder = new DocumentBuilder(e.Document);
                        photoBuilder.MoveToField(e.Field, true);
                        e.Field.Remove();
                        //Paragraph paragraph = photoBuilder.InsertParagraph();// new Paragraph(e.Document);
                        Shape photoShape = new Shape(e.Document, ShapeType.Image);
                        photoShape.ImageData.SetImage(photo);
                        photoShape.WrapType = WrapType.Inline;
                        //Cell cell = photoBuilder.CurrentParagraph.ParentNode as Cell;
                        //cell.CellFormat.LeftPadding = 0;
                        //cell.CellFormat.RightPadding = 0;
                        if (e.FieldName == "畢業照片")
                        {
                            // 1吋
                            photoShape.Width = ConvertUtil.MillimeterToPoint(25);
                            photoShape.Height = ConvertUtil.MillimeterToPoint(35);
                        }
                        else
                        {
                            //2吋
                            photoShape.Width = ConvertUtil.MillimeterToPoint(35);
                            photoShape.Height = ConvertUtil.MillimeterToPoint(45);
                        }
                        //paragraph.AppendChild(photoShape);
                        photoBuilder.InsertNode(photoShape);
                    }
                }
            }

            if (e.FieldName == "條碼")
            {
                DocumentBuilder builder = new DocumentBuilder(e.Document);
                builder.MoveToField(e.Field, true);
                e.Field.Remove();
                BarCodeBuilder bb = new BarCodeBuilder();
                if (e.FieldValue != null && e.FieldValue.ToString() != "")
                {
                    bb.CodeText = e.FieldValue.ToString();
                    bb.SymbologyType = Symbology.Code128;
                    bb.CodeLocation = CodeLocation.None;
                    bb.xDimension = 0.5f;
                    bb.BarHeight = 6.0f;
                    MemoryStream stream = new MemoryStream();
                    bb.Save(stream, ImageFormat.Jpeg);
                    builder.InsertImage(stream);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lnkDownload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DownloadTemplate();
        }

        private void lnkUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UploadTemplate();
        }

        private void DownloadTemplate()
        {
            if (_Config.Template == null)
            {
                FISCA.Presentation.Controls.MsgBox.Show("目前沒有任何範本");
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Word (*.doc)|*.doc";
            saveDialog.FileName = "學生通訊錄郵寄格式樣板";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _Config.Template.ToDocument().Save(saveDialog.FileName);
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("儲存失敗。" + ex.Message);
                    return;
                }

                try
                {
                    System.Diagnostics.Process.Start(saveDialog.FileName);
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("開啟失敗。" + ex.Message);
                    return;
                }
            }
        }

        private void UploadTemplate()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Word (*.doc)|*.doc";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(openDialog.FileName);
                    TemplateType type = TemplateType.Word;
                    ReportTemplate template = new ReportTemplate(fileInfo, type);
                    _Config.Template = template;
                    _Config.Save();
                    FISCA.Presentation.Controls.MsgBox.Show("檔案上傳成功");
                }
                catch (Exception ex)
                {
                    FISCA.Presentation.Controls.MsgBox.Show("檔案上傳失敗," + ex.Message);
                }
            }
        }

        /// <summary>
        /// 設定預設樣版
        /// </summary>
        private void SetDefaultTemplate()
        {
            if (_Config.Template == null)
            {
                ReportTemplate rptTmp = new ReportTemplate(Properties.Resources.學生通訊錄郵寄格式樣板, TemplateType.Word);
                _Config.Template = rptTmp;
                _Config.Save();
            }
        }

        private void SHSContactsForm_Load(object sender, EventArgs e)
        {
            this.MaximumSize = this.MinimumSize = this.Size;
            _Config = new ReportConfiguration(_ReportName);
            SetDefaultTemplate();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;

            _Config.Save();
            _bgWorker.RunWorkerAsync();
        }

        private void lnkDesc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Document document = new Document(new MemoryStream(Properties.Resources.學生通訊錄郵寄格式可使用合併欄位));
            string inputReportName = "學生通訊錄郵寄格式可使用合併欄位";
            string reportName = inputReportName;

            string path = Path.Combine(System.Windows.Forms.Application.StartupPath, "Reports");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            path = Path.Combine(path, reportName + ".doc");

            if (File.Exists(path))
            {
                int i = 1;
                while (true)
                {
                    string newPath = Path.GetDirectoryName(path) + "\\" + Path.GetFileNameWithoutExtension(path) + (i++) + Path.GetExtension(path);
                    if (!File.Exists(newPath))
                    {
                        path = newPath;
                        break;
                    }
                }
            }

            try
            {
                document.Save(path, Aspose.Words.SaveFormat.Doc);
                System.Diagnostics.Process.Start(path);
            }
            catch
            {
                System.Windows.Forms.SaveFileDialog sd = new System.Windows.Forms.SaveFileDialog();
                sd.Title = "另存新檔";
                sd.FileName = reportName + ".doc";
                sd.Filter = "Word檔案 (*.doc)|*.doc|所有檔案 (*.*)|*.*";
                if (sd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        document.Save(sd.FileName, Aspose.Words.SaveFormat.Doc);

                    }
                    catch
                    {
                        FISCA.Presentation.Controls.MsgBox.Show("指定路徑無法存取。", "建立檔案失敗", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void lnkReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (FISCA.Presentation.Controls.MsgBox.Show("請問是否將目前樣板復原成系統預設樣板?", "復原預設樣板", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                ReportTemplate rptTmp = new ReportTemplate(Properties.Resources.學生通訊錄郵寄格式樣板, TemplateType.Word);
                _Config.Template = rptTmp;
                _Config.Save();
                FISCA.Presentation.Controls.MsgBox.Show("樣板已恢復預設樣板.");
            }
        }


    }
}
