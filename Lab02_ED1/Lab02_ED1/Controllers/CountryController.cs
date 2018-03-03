using ArbolBinarioBu;
using Lab02_ED1.DataBase;
using Lab02_ED1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab02_ED1.Controllers
{
    public class CountryController : Controller
    {
        DataAdmin Datos = DataAdmin.getInstance;

        // GET: Country
        public ActionResult Index()
        {
            return View(Datos.ListaPaises);
        }
        public ActionResult IndexInt()
        {
            return View(Datos.ListaInt);
        }
        public ActionResult IndexString()
        {
            return View(Datos.ListaString);
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Country PaisNuevo = new Models.Country();
                PaisNuevo.nombre = collection["nombre"];
                PaisNuevo.Grupo = char.Parse(collection["Grupo"]);
                Datos.ArbolBinario.Insertar(PaisNuevo);
                Datos.ListaPaises = Datos.ArbolBinario.Orders("PreOrder");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
           Country PaisBuscado =  Datos.ListaPaises.Find(x => x.ID == id);
            return View(PaisBuscado);
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Country PaisEditado = new Country();
                Country PaisEliminar = Datos.ListaPaises.Find(x => x.ID == id);


                PaisEditado.nombre = collection["Nombre"];
                PaisEditado.Grupo = char.Parse(collection["Grupo"]);
                PaisEditado.ID = id;
                Datos.ArbolBinario.Eliminar(PaisEliminar);
                Datos.ArbolBinario.Insertar(PaisEditado);

                Datos.ListaPaises = Datos.ArbolBinario.Orders("PreOrder");

                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
           

            
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            Country PaisEliminar = Datos.ListaPaises.Find(x => x.ID == id);

            return View(PaisEliminar);
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Country PaisEliminar = Datos.ListaPaises.Find(x => x.ID == id);
                Datos.ArbolBinario.Eliminar(PaisEliminar);
                Datos.ListaPaises = Datos.ArbolBinario.Orders("PreOrder");

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //---------------------------------------Upload País----------------------------------
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload.FileName.EndsWith(".json"))
                    {
                        JsonReader<Country> LectorJson = new JsonReader<Country>();
                        Nodo<Country> RaizArbol = LectorJson.Datos(upload.InputStream);
                        Datos.ArbolBinario.root = RaizArbol;
                        Datos.ListaPaises = Datos.ArbolBinario.Orders("PreOrder");

                        // Asignar un ID al país para editar o eliminar

                        foreach (var item in Datos.ListaPaises)
                        {
                            item.ID = Datos.CountryId;
                            Datos.CountryId++;
                        }


                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }

        public ActionResult Orden(string Order)
        {
            Datos.ListaPaises = Datos.ArbolBinario.Orders(Order);
           return RedirectToAction("Index");
        }

        //---------------------------------------ENTEROS----------------------------------
        public ActionResult UploadInt()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadInt(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload.FileName.EndsWith(".json"))
                    {
                        JsonReader<int> LectorJson = new JsonReader<int>();
                        Nodo<int> RaizArbol = LectorJson.DatosI(upload.InputStream);
                        Datos.iArbolBinario.root = RaizArbol;
                        Datos.ListaInt = Datos.iArbolBinario.Orders("PreOrder");



                        return RedirectToAction("IndexInt");
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }

        public ActionResult OrdenInt(string Order)
        {
            Datos.ListaInt = Datos.iArbolBinario.Orders(Order);
            return RedirectToAction("IndexInt");
        }
        //---------------------------------------Upload String----------------------------------
        public ActionResult UploadString()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadString(HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {

                    if (upload.FileName.EndsWith(".json"))
                    {
                        JsonReader<string> LectorJson = new JsonReader<string>();
                        Nodo<string> RaizArbol = LectorJson.DatosS(upload.InputStream);
                        Datos.sArbolBinario.root = RaizArbol;
                        Datos.ListaString = Datos.sArbolBinario.Orders("PreOrder");


                        return RedirectToAction("IndexString");
                    }
                    else
                    {
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
            }
            return View();
        }

        public ActionResult OrdenString(string Order)
        {
            Datos.ListaString = Datos.sArbolBinario.Orders(Order);
            return RedirectToAction("IndexString");
        }
    }
}
