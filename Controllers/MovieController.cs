using Movie_Rental_Tri.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_Rental_Tri.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        Database1Entities db = new Database1Entities();

        public ActionResult User(Table obj)
        {
            return View(obj);
        }

        [HttpPost]
        public ActionResult AddUser(Table model)
        {
            if (ModelState.IsValid)
            {

                Table users = new Table();
                users.User_ID = model.User_ID;
                users.Full_Name = model.Full_Name;
                users.Email_Address = model.Email_Address;
                users.Password = model.Password;

                db.Table.Add(users);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View("User");
        }

        public ActionResult Movie(Table_Movie x)
        {
            return View();
        }

        public ActionResult MoviesList(Table_Movie model)
        {
            var x = db.Table_Movie.ToList();
            return View(x);
        }

        public ActionResult UserList(Table model)
        {
            var x = db.Table.ToList();
            return View(x);
        }



        [HttpPost]
        public ActionResult AddMovie(Table_Movie model)
        {
            if (ModelState.IsValid)
            {
                Table_Movie movies = new Table_Movie();
                movies.Movie_ID = model.Movie_ID;
                movies.Movie_Title = model.Movie_Title;
                movies.Movie_Description = model.Movie_Description;
                movies.IsRented = model.IsRented;
                movies.Rental_Date = model.Rental_Date;
                movies.isDeleted = model.isDeleted;

                db.Table_Movie.Add(movies);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View("User");
        }


        public ActionResult DeleteMovie(int id)
        {
            var res = db.Table_Movie.Where(x => x.Movie_ID == id).First();
            db.Table_Movie.Remove(res);
            db.SaveChanges();

            var list = db.Table_Movie.ToList();
            return View("MoviesList", list);

        }

        public ActionResult DeleteUser(int id)
        {
            var res = db.Table.Where(x => x.User_ID == id).First();
            db.Table.Remove(res);
            db.SaveChanges();

            var list = db.Table.ToList();
            return View("UserList", list);

        }





    }
}