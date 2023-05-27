using Infraestructure.Model;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Infraestructure.Repository
{
    public class RepositoryTarea : IRepositoryTarea
    {
        //Este metodo solo trae las tareas que están completadas
        public IEnumerable<Trabajo> GetAlCompletadasl()
        {
            try
            {
                List<Trabajo> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    lista = ctx.Trabajo.Include("Estado_Tarea").Where(g => g.Estado_Tarea.ID_ESTADO_TAREA == 1).Where(x => x.Borrado_Logico.ID_BORRADO == 2).ToList();
                }
                return lista;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        //Este metodo trae todas las tareas sin filtro de la base de datos
        public IEnumerable<Trabajo> GetAll()
        {
            try
            {
                List<Trabajo> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    lista = ctx.Trabajo.Include("Estado_Tarea").Where(x => x.Borrado_Logico.ID_BORRADO == 2).ToList<Trabajo>();
                }

                return lista;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        //Este metodo se trae solo las Tareas pendientes
        public IEnumerable<Trabajo> GetAllPendientes()
        {
            try
            {
                List<Trabajo> lista = null;
                using (MyContext ctx = new MyContext())
                {
                    lista = ctx.Trabajo.Include("Estado_Tarea").Where(g => g.Estado_Tarea.ID_ESTADO_TAREA == 2).Where(x => x.Borrado_Logico.ID_BORRADO == 2).ToList<Trabajo>();
                }
                return lista;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        //Este metodo trae ciertas tareas dependiento del identificador
        public Trabajo GetById(int id)
        {
            try
            {
                Trabajo lista = null;
                using (MyContext ctx = new MyContext())
                {
                    lista = ctx.Trabajo.Where(x => x.ID_TAREA == id).
                        Include("Estado_Tarea").FirstOrDefault();
                }
                return lista;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        //Este metodo guarda o edita las tareas en la base de datos
        public Trabajo Save(Trabajo trabajo)
        {
            try
            {
                Trabajo oTrabajo = null;
                int retorno = 0;

                using (MyContext ctx = new MyContext())
                {
                    oTrabajo = GetById(trabajo.ID_TAREA);

                    if (oTrabajo == null)
                    {
                        //Inserta una Tarea y automaticamente que se guarde con el estado pendiente
                        trabajo.ID_ESTADO_TAREA = 2;
                        trabajo.ID_BORRADO = 2;
                        ctx.Trabajo.Add(trabajo);
                        retorno = ctx.SaveChanges();
                    }
                    else
                    {
                        //Editar la tarea ya existente
                        ctx.Trabajo.Add(trabajo);
                        ctx.Entry(trabajo).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }


                }
                if (retorno > 0)
                    oTrabajo = GetById((int)trabajo.ID_TAREA);

                return oTrabajo;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }
    }
}
