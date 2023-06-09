﻿using ApplicationCore.Services;
using Infraestructure.Model;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MVCPruebaTecnica.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Carlo Bonilla";

            return View();
        }

        public ActionResult IndexAll()
        {
            try
            {
                IEnumerable<Trabajo> lista = null;
                IServiceTarea serviceTarea = new ServiceTarea();
                lista = serviceTarea.GetAll();
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        public ActionResult IndexAllBy()
        {
            try
            {
                IEnumerable<Trabajo> lista = null;
                IServiceTarea serviceTarea = new ServiceTarea();
                lista = serviceTarea.GetAll();
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }



        //Get Tareas Completadas
        public ActionResult IndexTareasCompletadas()
        {
            try
            {
                IEnumerable<Trabajo> lista = null;
                IServiceTarea serviceTarea = new ServiceTarea();
                lista = serviceTarea.GetAlCompletadasl();
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        //Get Tareas Pendientes
        public ActionResult IndexTareasPendientes()
        {
            try
            {
                IEnumerable<Trabajo> lista = null;
                IServiceTarea serviceTarea = new ServiceTarea();
                lista = serviceTarea.GetAllPendientes();
                return View(lista);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        //Crear la Tarea nueva
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.idEstadoTarea = listaEstadoTareas();
            ViewBag.idBorrado = listaBorrado();
            return View();
        }

        //Get de la lista de los estados de las Tareas
        private SelectList listaEstadoTareas(int id = 0)
        {
            IServiceEstadoTarea service = new ServiceEstadoTarea();
            IEnumerable<Estado_Tarea> lista = service.GetEstadoTareas();
            return new SelectList(lista, "ID_ESTADO_TAREA", "DESCRIPCION", id);
        }

        //Get de la lista de la tabla de borrado lógico
        private SelectList listaBorrado(int id = 0)
        {
            IServiceBorrado service = new ServiceBorrado();
            IEnumerable<Borrado_Logico> lista = service.GetBorrado();
            return new SelectList(lista, "ID_BORRADO", "DESCRIPCION", id);
        }

        //Traer la lógica del save
        [HttpPost]
        public ActionResult Save(Trabajo trabajo)
        {
            try
            {
                IServiceTarea serviceTarea = new ServiceTarea();
                if (ModelState.IsValid)
                {
                    Trabajo oTrabajo = serviceTarea.Save(trabajo);
                }
                else
                {
                    ViewBag.idEstadoTarea = listaEstadoTareas(trabajo.ID_ESTADO_TAREA);
                    ViewBag.idBorrado = listaBorrado((int)trabajo.ID_BORRADO);

                    if (trabajo.ID_TAREA > 0)
                    {
                        return (ActionResult)View("Edit", trabajo);
                    }
                    else
                    {
                        return View("Create", trabajo);
                    }
                }

                return RedirectToAction("IndexAll");
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }


        //Editar toda la tarea
        public ActionResult Edit(int? id)
        {
            try
            {
                IServiceTarea serviceTarea = new ServiceTarea();
                Trabajo oTrabajo = null;

                if (id == null)
                {
                    return RedirectToAction("Index");
                }

                oTrabajo = serviceTarea.GetById(Convert.ToInt32(id));

                if (oTrabajo == null)
                {
                    TempData["Message"] = "No existe la Tarea solicitado";
                    TempData["Redirect"] = "Tarea";
                    TempData["Redirect-Action"] = "Index";
                    return RedirectToAction("Default", "Error");
                }

                ViewBag.ID_ESTADO_TAREA = listaEstadoTareas(oTrabajo.ID_ESTADO_TAREA);
                ViewBag.ID_BORRADO = listaBorrado((int)oTrabajo.ID_BORRADO);
                return View(oTrabajo);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        //Completar la Tarea con la fecha de finalización
        public ActionResult EditFinish(int? id)
        {
            try
            {
                IServiceTarea serviceTarea = new ServiceTarea();
                Trabajo oTrabajo = null;

                if (id == null)
                {
                    return RedirectToAction("IndexAll");
                }

                oTrabajo = serviceTarea.GetById(Convert.ToInt32(id));

                if (oTrabajo == null)
                {
                    TempData["Message"] = "No existe la Tarea solicitado";
                    TempData["Redirect"] = "Tarea";
                    TempData["Redirect-Action"] = "Index";
                    return RedirectToAction("Default", "Error");
                }

                ViewBag.ID_ESTADO_TAREA = listaEstadoTareas(oTrabajo.ID_ESTADO_TAREA);
                ViewBag.ID_BORRADO = listaBorrado((int)oTrabajo.ID_BORRADO);
                return View(oTrabajo);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        //Borrado lógico, por la relaciones
        public ActionResult Delete(int? id)
        {
            try
            {
                IServiceTarea serviceTarea = new ServiceTarea();
                Trabajo oTrabajo = null;

                if (id == null)
                {
                    return RedirectToAction("IndexAll");
                }

                oTrabajo = serviceTarea.GetById(Convert.ToInt32(id));

                if (oTrabajo == null)
                {
                    TempData["Message"] = "No existe la Tarea solicitado";
                    TempData["Redirect"] = "Tarea";
                    TempData["Redirect-Action"] = "Index";
                    return RedirectToAction("Default", "Error");
                }

                ViewBag.ID_ESTADO_TAREA = listaEstadoTareas(oTrabajo.ID_ESTADO_TAREA);
                ViewBag.ID_BORRADO = listaBorrado((int)oTrabajo.ID_BORRADO);
                return View(oTrabajo);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }

        //Obtener una Tarea
        public ActionResult Details(int? id)
        {
            IServiceTarea serviceTarea = new ServiceTarea();
            Trabajo oTrabajo = null;
            try
            {
                if (id == null)
                {
                    return RedirectToAction("IndexAll");
                }
                oTrabajo = serviceTarea.GetById(Convert.ToInt32(id));

                if (oTrabajo == null)
                {
                    TempData["Message"] = "No existe la Tarea solicitado";
                    TempData["Redirect"] = "Tarea";
                    TempData["Redirect-Action"] = "Index";
                    return RedirectToAction("Default", "Error");
                }

                ViewBag.ID_ESTADO_TAREA = listaEstadoTareas(oTrabajo.ID_ESTADO_TAREA);
                ViewBag.ID_BORRADO = listaBorrado((int)oTrabajo.ID_BORRADO);
                return View(oTrabajo);
            }
            catch (Exception ex)
            {
                Log.Error(ex, MethodBase.GetCurrentMethod());
                TempData["Message"] = "Error al procesar los datos!" + ex.Message;
                return RedirectToAction("Default", "Error");
            }
        }
    }
}