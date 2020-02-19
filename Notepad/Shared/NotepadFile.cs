using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notepad.Shared
{
    public class NotepadFile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        
        public string FileName { get; set; }
        public string FileContent { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime LastAccessed { get; set; }
    }
}
