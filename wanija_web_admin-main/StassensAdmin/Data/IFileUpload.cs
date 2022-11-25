using BlazorInputFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Data
{
    public interface IFileUpload
    {
        Task UploadAsync(IFileListEntry file);
        string FilePath(IFileListEntry file);

        Task UploadSlipAsync(IFileListEntry fileEntry, string time);
        Task UploadBlogAsync(IFileListEntry fileEntry);
        Task UploadSliderAsync(IFileListEntry fileEntry);
        Task UploadBannerAsync(IFileListEntry fileEntry);
        Task UploadCatAsync(IFileListEntry fileEntry);
        string FilePathSlip(IFileListEntry fileEntry);
        Task UploadGalleryAsync(IFileListEntry fileEntry);
        Task DeleteGalleryAsync(string fileName);
        Task UploadInvoiceDocumentsAsync(IFileListEntry fileEntry , string referenceno);
        string FilePathInvoiceDocuments(IFileListEntry fileEntry , string referenceno);
    }
}
