using Kuyumcu.Data;
using Kuyumcu.Models;
using Kuyumcu.Models.Kuyumcu;
using Kuyumcu.Models.Musteri_Islemleri;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace Kuyumcu.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        public ActionResult Index()
        {
            return View();
        }

        Kuyumcu.Data.KuyumcuContext appointmentContext = new Kuyumcu.Data.KuyumcuContext();
        object resourceContext = null;

        public ActionResult SchedulerPartial()
        {
            var appointments = appointmentContext.Ajandas;
            System.Collections.IEnumerable resources = null; // Get resources from the context

            ViewData["Appointments"] = appointments.ToList();
            ViewData["Resources"] = resources;

            return PartialView("_SchedulerPartial");
        }
        public ActionResult SchedulerPartialEditAppointment()
        {
            var appointments = appointmentContext.Ajandas;
            System.Collections.IEnumerable resources = null; // Get resources from the context

            try
            {
                AnasayfaControllerSchedulerSettings.UpdateEditableDataObject(appointmentContext, resourceContext);
            }
            catch (Exception e)
            {
                ViewData["SchedulerErrorText"] = e.Message;
            }

            ViewData["Appointments"] = appointments.ToList();
            ViewData["Resources"] = resources;

            return PartialView("_SchedulerPartial");
        }

       
    }
    public class AnasayfaControllerSchedulerSettings
    {
        static DevExpress.Web.Mvc.MVCxAppointmentStorage appointmentStorage;
        public static DevExpress.Web.Mvc.MVCxAppointmentStorage AppointmentStorage
        {
            get
            {
                if (appointmentStorage == null)
                {
                    appointmentStorage = new DevExpress.Web.Mvc.MVCxAppointmentStorage();
                    appointmentStorage.Mappings.AppointmentId = "Konu";
                    appointmentStorage.Mappings.Start = "Baslangic";
                    appointmentStorage.Mappings.End = "Bitis";
                    appointmentStorage.Mappings.Subject = "Konu";
                    appointmentStorage.Mappings.Description = "Aciklama";
                    appointmentStorage.Mappings.Location = "Lokasyon";
                    appointmentStorage.Mappings.AllDay = "TumGun";


                }
                return appointmentStorage;
            }
        }

        static DevExpress.Web.Mvc.MVCxResourceStorage resourceStorage;
        public static DevExpress.Web.Mvc.MVCxResourceStorage ResourceStorage
        {
            get
            {
                if (resourceStorage == null)
                {
                    resourceStorage = new DevExpress.Web.Mvc.MVCxResourceStorage();
                    resourceStorage.Mappings.ResourceId = "";
                    resourceStorage.Mappings.Caption = "";
                }
                return resourceStorage;
            }
        }

        public static void UpdateEditableDataObject(Kuyumcu.Data.KuyumcuContext appointmentContext, object resourceContext)
        {
            InsertAppointments(appointmentContext, resourceContext);
            UpdateAppointments(appointmentContext, resourceContext);
            DeleteAppointments(appointmentContext, resourceContext);
        }

        static void InsertAppointments(Kuyumcu.Data.KuyumcuContext appointmentContext, object resourceContext)
        {
            var appointments = appointmentContext.Ajandas.ToList();
            System.Collections.IEnumerable resources = null;

            var newAppointments = DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToInsert<Kuyumcu.Models.Ajanda>("Scheduler", appointments, resources,
                AppointmentStorage, ResourceStorage);
            foreach (var appointment in newAppointments)
            {
                appointmentContext.Ajandas.Add(appointment);
            }
            appointmentContext.SaveChanges();
        }
        static void UpdateAppointments(Kuyumcu.Data.KuyumcuContext appointmentContext, object resourceContext)
        {
            var appointments = appointmentContext.Ajandas.ToList();
            System.Collections.IEnumerable resources = null;

            var updAppointments = DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToUpdate<Kuyumcu.Models.Ajanda>("Scheduler", appointments, resources,
                AppointmentStorage, ResourceStorage);
            foreach (var appointment in updAppointments)
            {
                var origAppointment = appointments.FirstOrDefault(a => a.Konu == appointment.Konu);
                appointmentContext.Entry(origAppointment).CurrentValues.SetValues(appointment);
            }
            appointmentContext.SaveChanges();
        }

        static void DeleteAppointments(Kuyumcu.Data.KuyumcuContext appointmentContext, object resourceContext)
        {
            var appointments = appointmentContext.Ajandas.ToList();
            System.Collections.IEnumerable resources = null;

            var delAppointments = DevExpress.Web.Mvc.SchedulerExtension.GetAppointmentsToRemove<Kuyumcu.Models.Ajanda>("Scheduler", appointments, resources,
                AppointmentStorage, ResourceStorage);
            foreach (var appointment in delAppointments)
            {
                var delAppointment = appointments.FirstOrDefault(a => a.Konu == appointment.Konu);
                if (delAppointment != null)
                    appointmentContext.Ajandas.Remove(delAppointment);
            }
            appointmentContext.SaveChanges();
        }
    }

}