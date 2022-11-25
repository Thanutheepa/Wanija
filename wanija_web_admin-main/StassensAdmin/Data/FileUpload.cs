using BlazorInputFile;
using MotherSLAdmin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Components;

namespace MotherSLAdmin.Data
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _environment;
        [Inject]
        IConfiguration Configuration { get; set; }
        private readonly IOptions<AppSettingsApi> options;

        string adminPath = "";
        string clientPath = "";
        public FileUpload(IWebHostEnvironment environment, IOptions<AppSettingsApi> options)
        {
            _environment = environment;
            adminPath = options.Value.adminPath;
            clientPath = options.Value.clientPath;
        }
        public async Task UploadAsync(IFileListEntry fileEntry)
        {
            var path = Path.Combine(_environment.ContentRootPath, "wwwroot/excelUpload", fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            using ( FileStream file = new FileStream (path, FileMode.Create,FileAccess.Write))
            {
                ms.WriteTo(file);
            }
        }

        public string FilePath(IFileListEntry fileEntry)
        {
            var path = Path.Combine(_environment.ContentRootPath, "wwwroot/excelUpload", fileEntry.Name);
            return path;
        }


        public async Task UploadSlipAsync(IFileListEntry fileEntry, string time)
        {
            var path = Path.Combine(_environment.ContentRootPath, "wwwroot/images/PRODUCT_IMAGES", time+"-"+fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(file);
            }
            string path1 = adminPath + "PRODUCT_IMAGES\\" + time + "-" + fileEntry.Name;
            string path2 = clientPath + "PRODUCT_IMAGES\\" + time + "-" + fileEntry.Name;
            System.IO.File.Move(path1, path2);
        } 
        public async Task UploadCatAsync(IFileListEntry fileEntry)
        {
            var path = Path.Combine(_environment.ContentRootPath, "wwwroot/images/Category_Images", fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(file);
            }
            string path1 = adminPath + "Category_Images\\" + fileEntry.Name;
            string path2 = clientPath + "Category_Images\\" + fileEntry.Name;
            if (File.Exists(path2))
            {
                File.Delete(path2);
            }
            System.IO.File.Move(path1, path2);
        }
        
        public async Task UploadBlogAsync(IFileListEntry fileEntry)
        {
            var path = Path.Combine(_environment.ContentRootPath, "wwwroot/images/blogImages", fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(file);
            }
            string path1 = adminPath + "blogImages\\" + fileEntry.Name;
            string path2 = clientPath + "blogImages\\" + fileEntry.Name;
            if (File.Exists(path2))
            {
                File.Delete(path2);
            }
            System.IO.File.Move(path1, path2);
        }
        public async Task UploadGalleryAsync(IFileListEntry fileEntry)
        {
            var path = Path.Combine(_environment.ContentRootPath, "wwwroot/images/galleryImages", fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(file);
                file.Close();
            }
            ms.Close();
            string path1 = adminPath + "galleryImages\\" + fileEntry.Name;
            string path2 = clientPath + "galleryImages\\" + fileEntry.Name;
            if (File.Exists(path2))
            {
                File.Delete(path2);
            }
            System.IO.File.Move(path1, path2);
        }
        public async Task DeleteGalleryAsync(string fileName)
        {
            string path2 = clientPath + "galleryImages\\" + fileName;
            File.Delete(path2);
        }
        public async Task UploadSliderAsync(IFileListEntry fileEntry)
        {
            var path = Path.Combine(_environment.ContentRootPath, "wwwroot/images/Slider", fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(file);
            }
            string path1 = adminPath + "Slider\\" + fileEntry.Name;
            string path2 = clientPath + "Slider\\" + fileEntry.Name;
            if (File.Exists(path2))
            {
                File.Delete(path2);
            }
            System.IO.File.Move(path1, path2);
        }
        public async Task UploadBannerAsync(IFileListEntry fileEntry)
        {
            var path = Path.Combine(_environment.ContentRootPath, "wwwroot/images/Banner", fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(file);
            }
            string path1 = adminPath + "Banner\\" + fileEntry.Name;
            string path2 = clientPath + "Banner\\" + fileEntry.Name;
            if (File.Exists(path2))
            {
                File.Delete(path2);
            }
            System.IO.File.Move(path1, path2);
        }

        public string FilePathSlip(IFileListEntry fileEntry)
        {
            var path = Path.Combine(_environment.ContentRootPath, "wwwroot/images/bankSlips", fileEntry.Name);
            return path;
        }

        public async Task UploadInvoiceDocumentsAsync(IFileListEntry fileEntry, string referenceno)
        {
           // var filename = referenceno + fileEntry.Name;
            var path = Path.Combine(_environment.ContentRootPath, "Upload", referenceno + fileEntry.Name);
            var ms = new MemoryStream();
            await fileEntry.Data.CopyToAsync(ms);
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(file);
            }
        }

        public string FilePathInvoiceDocuments(IFileListEntry fileEntry, string referenceno)
        {
            var filename = referenceno + fileEntry.Name;
            var path = Path.Combine(_environment.ContentRootPath, "Upload", filename);
            return path;
        }
    }
}
