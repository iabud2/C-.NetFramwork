using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace DVLD_BusinessLayer.GeneralClasses
{
    static public class clsGlobal
    {
        static public clsUsers CurrentUserLogedin;
    
        public static bool RememberLoginInfo(string username, string password)
        {
            try
            {
                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath = CurrentDirectory + "\\LoginInfo.txt";

                if (username == "" && File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    return false;
                }

                string LoginData = username + "#//#" + password;

                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    writer.WriteLine(LoginData);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error!, Can't save login Info! : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        static public bool RestoreLoginInfo(ref string username, ref string password)
        {
            try
            {

                string CurrentDirectory = System.IO.Directory.GetCurrentDirectory();

                string FilePath = CurrentDirectory + "\\LoginInfo.txt";

                if(File.Exists(FilePath)) 
                {
                    using (StreamReader reader = new StreamReader(FilePath))
                    {
                        string DataLine;

                        while ((DataLine = reader.ReadLine()) != null)
                        {
                            string[] Data = DataLine.Split(new string[] { "#//#" }, StringSplitOptions.None);
                            username = Data[0];
                            password = Data[1];
                        }
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error!, Can't retrive Login Info! :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }




            return false;
        }
    }
}
