using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KucniBudzetEntity.Models;

namespace KucniBudzetEntity.Controllers
{
    public class BudzetController : Controller
    {
        private BazaPodatakaKucniBudzetEntities db = new BazaPodatakaKucniBudzetEntities();

        // GET: Budzet
        public ActionResult Index()
        {
            BudzetSuma.suma = dajSumu();
            return View(db.BudzetTabelas.ToList());
        }
        // GET: Budzet
        public ActionResult Ulaz()
        {
            //BudzetSuma.suma = dajSumu();
            return View(db.BudzetTabelas.ToList());
        }
        public ActionResult Izlaz()
        {
            //BudzetSuma.suma = dajSumu();
            return View(db.BudzetTabelas.ToList());
        }

        // GET: Budzet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudzetTabela budzetTabela = db.BudzetTabelas.Find(id);
            if (budzetTabela == null)
            {
                return HttpNotFound();
            }
            return View(budzetTabela);
        }

        // GET: Budzet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Budzet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Opis,Iznos,UlazIzlaz,Suma,Datum")] BudzetTabela budzetTabela)
        {
            
            if (ModelState.IsValid)
            {
                double sumaPom = dajSumu();
                BudzetSuma.suma = sumaPom;
                if (budzetTabela.UlazIzlaz == true)
                {
                    sumaPom += budzetTabela.Iznos;
                    //BudzetSuma.suma += budzetTabela.Iznos;
                }
                else
                {
                    sumaPom -= budzetTabela.Iznos;
                    //BudzetSuma.suma -= budzetTabela.Iznos;
                }
                db.BudzetTabelas.Add(budzetTabela);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(budzetTabela);
        }

        // GET: Budzet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudzetTabela budzetTabela = db.BudzetTabelas.Find(id);
            if (budzetTabela == null)
            {
                return HttpNotFound();
            }
            return View(budzetTabela);
        }

        // POST: Budzet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Opis,Iznos,UlazIzlaz,Suma,Datum")] BudzetTabela budzetTabela)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(budzetTabela).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(budzetTabela);
        }

        // GET: Budzet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudzetTabela budzetTabela = db.BudzetTabelas.Find(id);
            if (budzetTabela == null)
            {
                return HttpNotFound();
            }
            return View(budzetTabela);
        }

        // POST: Budzet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BudzetTabela budzetTabela = db.BudzetTabelas.Find(id);
            BudzetSuma.suma -= budzetTabela.Iznos;
            db.BudzetTabelas.Remove(budzetTabela);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private double dajSumu()
        {
            double sumaPom = 0;
            //u pitanju su primanja, dodaje se na sumu
            foreach (var item in db.BudzetTabelas)
            {
                if (item.UlazIzlaz == true)
                {
                    sumaPom += item.Iznos;
                }
                else
                {
                    sumaPom -= item.Iznos;
                }
            }
            return sumaPom;
        }
    }
}
