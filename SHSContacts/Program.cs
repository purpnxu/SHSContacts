using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA.Presentation;
using K12.Presentation;
using FISCA.Permission;
using K12.Data;

namespace SHSContacts
{
    // 高中通訊錄(郵寄格式)
    public class Program
    {
        [FISCA.MainMethod()]
        public static void Main()
        {
            RibbonBarItem rptItem = MotherForm.RibbonBarItems["學生", "資料統計"];
            rptItem["報表"]["學籍相關報表"]["通訊錄(郵寄格式)"].Enable = UserAcl.Current["SHSContacts_Student"].Executable;  //.Executable可以設定不同權限 例:可看的權限，Viewable
            rptItem["報表"]["學籍相關報表"]["通訊錄(郵寄格式)"].Click += delegate   //匿名寫法
            {
                if (NLDPanels.Student.SelectedSource.Count > 0)
                {       //取得資料學生id(SIDList)
                    List<string> classRefid = new List<string>();
                    List<string> StudentIDList=Utitlty.GetStudentIDListByStudentID( K12.Presentation.NLDPanels.Student.SelectedSource);
                    List<StudentRecord> StudentList = K12.Data.Student.SelectByIDs(StudentIDList);
                    foreach(StudentRecord stuid in StudentList)
                    {
                        classRefid.Add(stuid.RefClassID);
                    }
                    
                    Forms.SHSContactsForm scf = new Forms.SHSContactsForm(StudentIDList, classRefid);
                    
                    scf.ShowDialog();
                }
                else
                {
                    FISCA.Presentation.Controls.MsgBox.Show("請選擇學生");
                    return;
                }
            };

            RibbonBarItem rptItemC = MotherForm.RibbonBarItems["班級", "資料統計"];

            rptItemC["報表"]["學籍相關報表"]["通訊錄(郵寄格式)"].Enable = UserAcl.Current["SHSContacts_Class"].Executable;
            rptItemC["報表"]["學籍相關報表"]["通訊錄(郵寄格式)"].Click += delegate
            {
                if (NLDPanels.Class.SelectedSource.Count > 0)
                {   //取得資料學生id(SIDList)
                    List<string> ClassIDList = K12.Presentation.NLDPanels.Class.SelectedSource;

                    List<string> SIDList = Utitlty.GetStudentIDList1ByClassID(K12.Presentation.NLDPanels.Class.SelectedSource);
                    Forms.SHSContactsForm scf = new Forms.SHSContactsForm(SIDList, ClassIDList);
                    scf.ShowDialog();
                }
                else
                {
                    FISCA.Presentation.Controls.MsgBox.Show("請選擇班級");
                    return;
                }
            };


            // 列印學生通訊錄郵寄格式(學生)
            Catalog catalog1 = RoleAclSource.Instance["學生"]["功能按鈕"];
            catalog1.Add(new RibbonFeature("SHSContacts_Student", "學生通訊錄郵寄格式(學生)"));

            // 列印學生通訊錄郵寄格式(班級)
            Catalog catalog2 = RoleAclSource.Instance["班級"]["功能按鈕"];
            catalog2.Add(new RibbonFeature("SHSContacts_Class", "學生通訊錄郵寄格式(班級)"));
        }

    }
}
