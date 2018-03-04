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
        public ActionResult Degenerado()
        {
            if (Datos.ArbolBinario.root != null)
            {
                if (Datos.ArbolBinario.Degenerado)
                {
                    TempData["msg"] = "<script>alert('Árbol es degenerado');</script>";
                }
                else
                {
                    TempData["msg"] = "<script>alert('Árbol no es degenerado');</script>";
                }

            }
            else
                TempData["msg"] = "<script>alert('No hay árbol Existente');</script>";
            return RedirectToAction("Index");
        }
        public ActionResult Balanceado()
        {
            if (Datos.ArbolBinario.root == null)
            {
                TempData["msg"] = "<script>alert('No hay árbol Existente');</script>";
            }
            else if (Datos.ArbolBinario.Balancedo)
            {
                TempData["msg"] = "<script>alert('Árbol balanceado');</script>";
            }
            else
            {
                Nodo<Country> nDesbalanceado = Datos.ArbolBinario.Desbalanceado();
                string Mensaje = "'Nodo desvalanceado => Pais: " + nDesbalanceado.valor.nombre +
                    " Grupo: " + nDesbalanceado.valor.Grupo + "'";
                Mensaje = "<script>alert(" + Mensaje + ");</script>";
                TempData["msg"] = Mensaje;
            }
            return RedirectToAction("Index");
        }

        public ActionResult IndexInt()
        {
            return View(Datos.ListaInt);
        }
        public ActionResult DegeneradoInt()
        {
            if (Datos.iArbolBinario.root != null)
            {
                if (Datos.iArbolBinario.Degenerado)
                {
                    TempData["msg"] = "<script>alert('Árbol es degenerado');</script>";
                }
                else
                {
                    TempData["msg"] = "<script>alert('Árbol no es degenerado');</script>";
                }

            }
            else
                TempData["msg"] = "<script>alert('No hay árbol Existente');</script>";
            return RedirectToAction("IndexInt");
        }
        public ActionResult BalanceadoInt()
        {
            if (Datos.iArbolBinario.root == null)
            {
                TempData["msg"] = "<script>alert('No hay árbol Existente');</script>";
            }
            else if (Datos.iArbolBinario.Balancedo)
            {
                TempData["msg"] = "<script>alert('Árbol balanceado');</script>";
            }
            else
            {
                Nodo<int> nDesbalanceado = Datos.iArbolBinario.Desbalanceado();
                string Mensaje = "'Nodo desvalanceado => Valor: " + nDesbalanceado.valor.ToString() + "'";
                Mensaje = "<script>alert(" + Mensaje + ");</script>";
                TempData["msg"] = Mensaje;
            }
            return RedirectToAction("IndexInt");
        }

        public ActionResult IndexString()
        {
            return View(Datos.ListaString);
        }
        public ActionResult DegeneradoString()
        {
            if (Datos.sArbolBinario.root != null)
            {
                if (Datos.sArbolBinario.Degenerado)
                {
                    TempData["msg"] = "<script>alert('Árbol es degenerado');</script>";
                }
                else
                {
                    TempData["msg"] = "<script>alert('Árbol no es degenerado');</script>";
                }
            }
            else
                TempData["msg"] = "<script>alert('No hay árbol Existente');</script>";


            return RedirectToAction("IndexString");
        }
        public ActionResult BalanceadoString()
        {
            if (Datos.sArbolBinario.root == null)
            {
                TempData["msg"] = "<script>alert('No hay árbol Existente');</script>";
            }
            else if (Datos.sArbolBinario.Balancedo)
            {
                TempData["msg"] = "<script>alert('Árbol balanceado');</script>";
            }
            else
            {
                Nodo<string> nDesbalanceado = Datos.sArbolBinario.Desbalanceado();
                string Mensaje = "'Nodo desvalanceado => Valor: " + nDesbalanceado.valor.ToString() + "'";
                Mensaje = "<script>alert(" + Mensaje + ");</script>";
                TempData["msg"] = Mensaje;
            }
            return RedirectToAction("IndexString");
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



        public ActionResult CreateInt()
        {
            
            
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult CreateInt(FormCollection collection)
        {
            try
            {
                Datos.iArbolBinario.Insertar(int.Parse(collection["Dato"]));
                Datos.ListaInt = Datos.iArbolBinario.Orders("PreOrder");

                return RedirectToAction("IndexInt");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteInt(int id)
        {
            return View(id);
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult DeleteInt(int id, FormCollection collection)
        {
            try
            {
                Datos.iArbolBinario.Eliminar(id);
                Datos.ListaInt = Datos.iArbolBinario.Orders("PreOrder");

                return RedirectToAction("IndexInt");
            }
            catch
            {
                return View(id);
            }
        }

        public ActionResult EditInt(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            return View(Datos.ListaInt.Find(x => x == id));
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult EditInt(int id, FormCollection collection)
        {
            try
            {
                Datos.iArbolBinario.Eliminar(id);
                int Dato = int.Parse(collection["Dato"]);
                Datos.iArbolBinario.Insertar(Dato);

                Datos.ListaInt = Datos.iArbolBinario.Orders("PreOrder");

                return RedirectToAction("IndexInt");
            }
            catch (Exception)
            {

                return View(id);
            }



        }


        //---------------------------------------String----------------------------------
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

        public ActionResult CreateString()
        {


            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult CreateString(FormCollection collection)
        {
            try
            {
                Datos.sArbolBinario.Insertar(collection["Dato"]);
                Datos.ListaString = Datos.sArbolBinario.Orders("PreOrder");

                return RedirectToAction("IndexString");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteString(string id)
        {
            return View((object)id);
        }

        // POST: Country/Delete/5
        [HttpPost]
        public ActionResult DeleteString(string id, FormCollection collection)
        {
            try
            {
                Datos.sArbolBinario.Eliminar(id);
                Datos.ListaString = Datos.sArbolBinario.Orders("PreOrder");

                return RedirectToAction("IndexString");
            }
            catch
            {
                return View((object)id);
            }
        }

        public ActionResult EditString(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            return View((object)Datos.ListaString.Find(x => x == id));
        }

        // POST: Country/Edit/5
        [HttpPost]
        public ActionResult EditString(string id, FormCollection collection)
        {
            try
            {
                Datos.sArbolBinario.Eliminar(id);
                string Dato = collection["Dato"];
                Datos.sArbolBinario.Insertar(Dato);

                Datos.ListaInt = Datos.iArbolBinario.Orders("PreOrder");

                return RedirectToAction("IndexString");
            }
            catch (Exception)
            {

                return View((object)id);
            }



        }



    }
}
