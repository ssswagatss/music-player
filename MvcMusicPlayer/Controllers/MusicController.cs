using MvcMusicPlayer.Models;
using System.Linq;
using System.Web.Mvc;

namespace MvcMusicPlayer.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music
        public ActionResult Index(int? id)
        {
            var songsVM = new SongViewModel();
            var allSongs = Song.GetSongs();
            if (allSongs != null && allSongs.Any())
            {
                if (id.HasValue && allSongs.Any(x => x.SongId == id.Value))
                {
                    songsVM.CurrentlyPlayingSong = allSongs.First(x => x.SongId == id.Value);
                    songsVM.OtherAvailableSongs.AddRange(allSongs);
                }
                else
                {
                    songsVM.CurrentlyPlayingSong = allSongs.ElementAt(0);
                    songsVM.OtherAvailableSongs.AddRange(allSongs);
                }
            }

            return View(songsVM);
        }

        // GET: Music/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Music/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Music/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Music/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Music/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Music/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Music/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
