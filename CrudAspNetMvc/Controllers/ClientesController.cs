using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrudAspNetMvc.Models;

namespace CrudAspNetMvc.Controllers
{
    public class ClientesController : Controller
    {
        private CadastroContext db = new CadastroContext();

        private List<object> estados = new List<object>
        {
                new {Sigla = "AC", Nome = "Acre" },
                new {Sigla = "AL", Nome = "Alagoas" },
                new {Sigla = "AP", Nome = "Amapá" },
                new {Sigla = "AM", Nome = "Amazonas" },
                new {Sigla = "BA", Nome = "Bahia" },
                new {Sigla = "CE", Nome = "Ceará" },
                new {Sigla = "DF", Nome = "Distrito Federal" },
                new {Sigla = "ES", Nome = "Espírito Santo" },
                new {Sigla = "GO", Nome = "Goiás" },
                new {Sigla = "MA", Nome = "Maranhão" },
                new {Sigla = "MT", Nome = "Mato Grosso" },
                new {Sigla = "MS", Nome = "Mato Grosso do Sul" },
                new {Sigla = "MG", Nome = "Minas Gerais" },
                new {Sigla = "PA", Nome = "Pará" },
                new {Sigla = "PB", Nome = "Paraíba" },
                new {Sigla = "PR", Nome = "Paraná" },
                new {Sigla = "PE", Nome = "Pernambuco" },
                new {Sigla = "PI", Nome = "Piauí" },
                new {Sigla = "RJ", Nome = "Rio de Janeiro" },
                new {Sigla = "RN", Nome = "Rio Grande do Norte" },
                new {Sigla = "RS", Nome = "Rio Grande do Sul" },
                new {Sigla = "RO", Nome = "Rondônia" },
                new {Sigla = "RR", Nome = "Roraima" },
                new {Sigla = "SC", Nome = "Santa Catarina" },
                new {Sigla = "SP", Nome = "São Paulo" },
                new {Sigla = "SE", Nome = "Sergipe" },
                new {Sigla = "TO", Nome = "Tocantins" }
         };

        // GET: Clientes
        public ActionResult Index()
        {
            return View(db.Clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.Estados = new SelectList(estados, "Sigla", "Nome");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sexo,CPF,Email,Telefone,Logradouro,Numero,Complemento,Bairro,Cidade,Estado,EstadoCivil")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estados = new SelectList(estados, "Sigla", "Nome");

            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estados = new SelectList(estados, "Sigla", "Nome");
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sexo,CPF,Email,Telefone,Logradouro,Numero,Complemento,Bairro,Cidade,Estado,EstadoCivil")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estados = new SelectList(estados, "Sigla", "Nome");

            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
    }
}
