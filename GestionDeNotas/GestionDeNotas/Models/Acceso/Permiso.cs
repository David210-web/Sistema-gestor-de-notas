using GestionDeNotas.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionDeNotas.Models.Acceso
{
    public class Permiso : ActionFilterAttribute
    {
        public string Roles { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
                return;
            }

            var usuario = HttpContext.Current.Session["usuario"] as Usuarios;
            if (usuario == null)
            {
                filterContext.Result = new RedirectResult("~/Acceso/Login");
                return;
            }

            var rol = UsuarioMantenimiento.ObtenerRol(usuario.Carnet);

            if (!string.IsNullOrEmpty(Roles) && !Roles.Split(',').Any(r => r.Trim().Equals(rol, StringComparison.OrdinalIgnoreCase)))
            {
                filterContext.Result = new RedirectResult("~/Acceso/NoAutorizado");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}