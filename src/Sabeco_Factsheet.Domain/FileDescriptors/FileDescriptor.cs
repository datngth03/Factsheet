using System;
using Volo.Abp.Domain.Entities;

namespace Sabeco_Factsheet.FileDescriptors;

public class FileDescriptor : AggregateRoot<Guid>
{
    public string Name { get; set; } = null!;

    public string MimeType { get; set; } = null!;

    private FileDescriptor()
    {

    }

    public FileDescriptor(Guid id, string name, string mimeType)
    {
        Id = id;
        Name = name;
        MimeType = mimeType;
    }
}