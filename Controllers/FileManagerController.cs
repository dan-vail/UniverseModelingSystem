using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text.Json.Serialization;
using System.Web;
using System.Web.Mvc;

namespace UniverseObjects.Controllers
{
    public class FileInfo
    {
        DirectoryInfo Directory { get; set; }
        string DirectoryName { get; set; }
        bool Exists { get; set; }
        bool IsReadOnly { get; set; }
        int Length { get; set; }
        string Name { get; set; }
        string FullName { get; set; }

        private bool AppendText(string text)
        {
            return false;
        }

        private bool CopyTo(DirectoryInfo directory)
        {
            return false;
        }
        private bool Create(DirectoryInfo directory, string name, string type)
        {
            return false;
        }

        private bool CreateText()
        {
            return false;
        }

        private FileInfo Decrypt(EncryptionPolicy encryptionPolicy)
        {
            FileInfo decryptedfileInfo = new FileInfo();
            return decryptedfileInfo;
        }

        private bool Delete()
        {
            return false;
        }

        private FileInfo Encrypt(FileInfo fileToEncrypt, 
            EncryptionPolicy encryptionPolicy, 
            DirectoryInfo directoryForEncryptedFileCopy)
        {
            return new FileInfo();
        }
        private FileInfo MoveTo(FileInfo fileInfo, DirectoryInfo newDirectory)
        {
            return new FileInfo();
        }
        private FileStream Open(FileInfo fileToOpen, FileMode fileMode)
        {
            FileStream fileStream = 
                new FileStream(fileToOpen.FullName, fileMode);
            return fileStream;
        }

        private FileStream OpenRead(FileInfo fileToRead, bool copyStream, Stream copyToStream)
        {
            FileStream fileStream = new FileStream(fileToRead.FullName, FileMode.Open);
                if (copyStream)
                {
                    fileStream.CopyToAsync(copyToStream);
                }
            return fileStream;
        }
        private bool OpenText()
        {
            return false;
        }
        private bool OpenWrite()
        {
            return false;
        }

        private bool Replace()
        {
            return false;
        }
    }

    public class FileManagerController : Controller
    {
        // GET: FileManager
        public ActionResult Index()
        {
            return View();
        }
    }
}