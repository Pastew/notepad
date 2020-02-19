using System;
using Notepad.Shared;

namespace Notepad.Server.Repositories
{
    public class SeedData
    {
        public static void Initialize(NotepadContext db)
        {
            var NotepadFiles = new NotepadFile[]
            {
                new NotepadFile()
                {
                    FileName = "test",
                    FileContent = "test content",
                    LastAccessed = DateTime.Now,
                    LastModified = DateTime.Now
                }
            };
            
            db.NotepadFiles.AddRange(NotepadFiles);
            db.SaveChanges();
        }
    }
}