﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u19325658_Hw3.Models;

namespace u19325658_Hw3.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            string[] filePath = Directory.GetFiles(Server.MapPath("~/Media/Videos"));
            List<FileModel> Files = new List<FileModel>();
            foreach (string filepaths in filePath)
            {
                Files.Add(new FileModel { FileName = Path.GetFileName(filepaths) });
            }

            return View(Files);
        }

        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.

            string path = Server.MapPath("~/Media/Videos/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            //The OCTET-STREAM format is used for file attachments on the Web with an
            //unknown file type. These .octet-stream files are arbitrary binary data
            //files that may be in any multimedia format.

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            //Delete requires reading the files and then the allocation of a file path.
            //The file is then deleted based on the identified file path.

            string path = Server.MapPath("~/Media/Videos/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}