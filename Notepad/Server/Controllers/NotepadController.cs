using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Notepad.Server.Repositories;
using Notepad.Shared;

namespace Notepad.Server.Controllers
{
    [ApiController]
    public class NotepadController : Controller
    {
        private NotepadContext _db;
        private static Random random = new Random();

        public NotepadController(NotepadContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("/")]
        public async Task<ActionResult<NotepadFile>> Index()
        {
            string randomFilename;
            do
            {
                randomFilename = RandomLetters(3, "ACDEFGHJKLMNPRSTWXYZ") + RandomLetters(3, "2345679");
            } while (_db.NotepadFiles.FirstOrDefault(f => f.FileName.Equals(randomFilename)) != null);

            return Redirect(randomFilename);
        }

        [HttpGet]
        [Route("api/notepad/{fileName}")]
        public async Task<ActionResult<NotepadFile>> GetOrCreateNotepadFile(string fileName)
        {
            NotepadFile file = _db.NotepadFiles.FirstOrDefault(f => f.FileName.Equals(fileName));

            if (file == null)
            {
                file = new NotepadFile()
                {
                    FileName = fileName,
                    FileContent = "",
                    LastAccessed = DateTime.Now,
                    LastModified = DateTime.Now
                };

                _db.NotepadFiles.Add(file);
            }

            return file;
        }


        [HttpPost]
        [Route("api/notepad/{fileName}")]
        public async Task<ActionResult<NotepadFile>> UpdateNotepadFile(NotepadFile notepadFile)
        {
            notepadFile.LastModified = DateTime.Now;
            _db.NotepadFiles.Update(notepadFile);
            await _db.SaveChangesAsync();
            return notepadFile;
        }

        [HttpPost]
        [Route("api/force")]
        public async Task<OkResult> ForcePost(ForceNotepadPost forceNotepadPost)
        {
            NotepadFile file = _db.NotepadFiles.FirstOrDefault(f => f.FileName.Equals(forceNotepadPost.FileName));
            if (file != null)
            {
                file.FileContent = forceNotepadPost.FileContent;
                _db.NotepadFiles.Update(file);
            }
            else
            {
                file = new NotepadFile()
                {
                    FileName = forceNotepadPost.FileName,
                    FileContent = forceNotepadPost.FileContent,
                    LastAccessed = DateTime.Now,
                    LastModified = DateTime.Now
                };

                _db.NotepadFiles.Add(file);
            }

            await _db.SaveChangesAsync();
            return Ok();
        }

        public static string RandomLetters(int length, string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789")
        {
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}