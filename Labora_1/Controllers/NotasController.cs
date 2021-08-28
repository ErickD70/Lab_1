using Labora_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labora_1.Controllers
{
    public class NotasController : Controller
    {
        // GET: Notas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Notas()
        {
            using (EstudianteEntities1 notas = new EstudianteEntities1())
            {
                var listadoNotas = notas.TblNotasEstudiante.ToList();

                return View(listadoNotas);
            }

        }
        [HttpPost]
        public ActionResult Resultado(String nombre, String lab1, String par1, String lab2, String par2, String lab3, String par3)
        {
            using (EstudianteEntities1 db = new EstudianteEntities1())
            {
                TblNotasEstudiante tbl = new TblNotasEstudiante();
                tbl.Nombre = nombre;
                tbl.lab1 = lab1;
                tbl.lab2 = lab2;
                tbl.lab3 = lab3;
                tbl.par1 = par1; 
                tbl.par2 = par2; 
                tbl.par3 = par3;
                db.TblNotasEstudiante.Add(tbl);
                db.SaveChanges();
            }
            double Lab1 = Convert.ToDouble(lab1);
            double Lab2 = Convert.ToDouble(lab2);
            double Lab3 = Convert.ToDouble(lab3);
            double Par1 = Convert.ToDouble(par1);
            double Par2 = Convert.ToDouble(par2);
            double Par3 = Convert.ToDouble(par3);

            Double prom1 = (((Lab1 * 0.40) + (Par1 * 0.60)) / 3);
            Double prom2 = (((Lab2 * 0.40) + (Par2 * 0.60)) / 3);
            Double prom3 = (((Lab3 * 0.40) + (Par3 * 0.60)) / 3);
            Double promfinal = (prom1) + (prom2) + (prom3);
            ViewBag.nombre = nombre;
            ViewBag.promedio1 = prom1;
            ViewBag.promedio2 = prom2;
            ViewBag.promedio3 = prom3;
            ViewBag.promFinal = promfinal;

            return View();
        }
    }
}