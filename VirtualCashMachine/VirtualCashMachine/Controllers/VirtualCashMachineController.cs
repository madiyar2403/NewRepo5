using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VirtualCashMachine
{
    public class VirtualCashMachineController : Controller
    {
        static List<VirtualCashMachine.Models.VirtualCashMachine.VirtualCashMachineClass> VirtualCashMachine = new List<VirtualCashMachine.Models.VirtualCashMachine.VirtualCashMachineClass>
        {

        };
        public IActionResult Index()
        {
            return View(VirtualCashMachine);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(VirtualCashMachine.Models.VirtualCashMachine.VirtualCashMachineClass order)
        {
            VirtualCashMachine.Add(order);

            return View("Index", VirtualCashMachine);
        }
    }
}
