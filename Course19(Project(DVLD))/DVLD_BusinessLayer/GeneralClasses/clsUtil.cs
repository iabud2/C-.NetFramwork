using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_BusinessLayer.GeneralClasses
{
    public static class clsUtil
    {
        public static string GenerateGUID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();        
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            //at the first we want to check if the Directory Exists or not:
            if(!Directory.Exists(FolderPath)) 
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (IOException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;        
                }
            }
            return true;    
        }

        public static string ReplaceFileNameWithGUID(string SourceFile)
        {
            string FileName = SourceFile;
            FileInfo Fi = new FileInfo(FileName);
            string ext = Fi.Extension;
            return GenerateGUID() + ext;
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            string DestinationFolder = @"C:\DVLD_People_Images\";
            if(!CreateFolderIfDoesNotExist(DestinationFolder)) 
            {
                return false;
            }

            string DestinationFile = DestinationFolder + ReplaceFileNameWithGUID(SourceFile);
            try
            {
                File.Copy(SourceFile, DestinationFile, true);
            }
            catch (IOException ex) 
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            SourceFile = DestinationFile;
            return true;
        }


    }
}
