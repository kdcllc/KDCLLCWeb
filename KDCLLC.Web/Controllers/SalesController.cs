using KDCLLC.Web.Data;
using KDCLLC.Web.Models.Data;
using KDCLLC.Web.ViewModels;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace KDCLLC.Web.Controllers
{
    //TODO: refactor the data access layer to the Repository object model
    public partial class SalesController : Controller
    {
        private DataContext _salesContext;

        public SalesController()
        {
            _salesContext = new DataContext();
        }


        public virtual ActionResult Index()
        {
            return View(_salesContext.SalesOrders.ToList());
        }


        public virtual ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = _salesContext.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }

            SalesOrderViewModel salesOrderViewModel = ViewModels.Helpers.CreateSalesOrderViewModelFromSalesOrder(salesOrder);
            salesOrderViewModel.MessageToClient = "I originated from the viewmodel, rather than the model.";

            return View(salesOrderViewModel);
        }


        public virtual ActionResult Create()
        {
            SalesOrderViewModel salesOrderViewModel = new SalesOrderViewModel();
            salesOrderViewModel.ObjectState = ObjectState.Added;
            return View(salesOrderViewModel);
        }


        public virtual ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = _salesContext.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }

            SalesOrderViewModel salesOrderViewModel = ViewModels.Helpers.CreateSalesOrderViewModelFromSalesOrder(salesOrder);
            salesOrderViewModel.MessageToClient = string.Format("The original value of Customer Name is {0}.", salesOrderViewModel.CustomerName);

            return View(salesOrderViewModel);
        }


        public virtual ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = _salesContext.SalesOrders.Find(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }

            SalesOrderViewModel salesOrderViewModel = ViewModels.Helpers.CreateSalesOrderViewModelFromSalesOrder(salesOrder);
            salesOrderViewModel.MessageToClient = "You are about to permanently delete this sales order.";
            salesOrderViewModel.ObjectState = ObjectState.Deleted;

            return View(salesOrderViewModel);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _salesContext.Dispose();
            }
            base.Dispose(disposing);
        }


        [HandleModelStateException]
        public virtual JsonResult Save(SalesOrderViewModel salesOrderViewModel)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelStateException(ModelState);
            }

            SalesOrder salesOrder = ViewModels.Helpers.CreateSalesOrderFromSalesOrderViewModel(salesOrderViewModel);

            _salesContext.SalesOrders.Attach(salesOrder);

            if (salesOrder.ObjectState == ObjectState.Deleted)
            {
                foreach (SalesOrderItemViewModel salesOrderItemViewModel in salesOrderViewModel.SalesOrderItems)
                {
                    SalesOrderItem salesOrderItem = _salesContext.SalesOrderItems.Find(salesOrderItemViewModel.SalesOrderItemId);
                    if (salesOrderItem != null)
                        salesOrderItem.ObjectState = ObjectState.Deleted;
                }
            }
            else
            {
                foreach (int salesOrderItemId in salesOrderViewModel.SalesOrderItemsToDelete)
                {
                    SalesOrderItem salesOrderItem = _salesContext.SalesOrderItems.Find(salesOrderItemId);
                    if (salesOrderItem != null)
                        salesOrderItem.ObjectState = ObjectState.Deleted;
                }
            }

            _salesContext.ApplyStateChanges();
            string messageToClient = string.Empty;

            try
            {
                _salesContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                messageToClient = "Someone else have modified this sales order since you retrieved it.  Your changes have not been applied.  What you see now are the current values in the database.";
            }
            catch (Exception ex)
            {
                throw new ModelStateException(ex);
            }

            if (salesOrder.ObjectState == ObjectState.Deleted)
                return Json(new { newLocation = "/Sales/Index/" });

            if (messageToClient.Trim().Length == 0)
                messageToClient = ViewModels.Helpers.GetMessageToClient(salesOrderViewModel.ObjectState, salesOrder.CustomerName);

            salesOrderViewModel.SalesOrderId = salesOrder.SalesOrderId;
            _salesContext.Dispose();
            _salesContext = new DataContext();
            salesOrder = _salesContext.SalesOrders.Find(salesOrderViewModel.SalesOrderId);

            salesOrderViewModel = ViewModels.Helpers.CreateSalesOrderViewModelFromSalesOrder(salesOrder);
            salesOrderViewModel.MessageToClient = messageToClient;

            return Json(new { salesOrderViewModel });
        }
    }
}