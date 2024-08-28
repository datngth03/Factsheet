using System;

namespace Sabeco_Factsheet.TbFileUploads;

public abstract class TbFileUploadDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}