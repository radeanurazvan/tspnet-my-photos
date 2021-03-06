//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyPhotos.Domain
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class File
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public File()
        {
            this.FileAttributes = new HashSet<FileAttribute>();
        }
    
        public System.Guid Id { get; private set; }
        public System.DateTime CreatedAt { get; private set; }
        public string Path { get; private set; }
        public bool IsDeleted { get; private set; }
        public string Title { get; private set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileAttribute> FileAttributes { get; private set; }
    }
}
