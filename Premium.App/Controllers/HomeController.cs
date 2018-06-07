using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Premium.App.Models;
using Premium.App.ViewModels;
using Premium.Services;

namespace Premium.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPremiumRepository premiumRepository;

        public HomeController(IPremiumRepository premiumRepository)
        {
            this.premiumRepository = premiumRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userModel = new User();
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GeneratePremium(User user)
        {
            // Checking whether the model is valid or not and 
            // also a sanity check that all variables are set
            // before the service call is made.
            if (!ModelState.IsValid || string.IsNullOrEmpty(user.Name) || user.Gender == null || user.DOB == null)
            {
                return View(nameof(Index));
            }

            try
            {
                var gender = GenderFactory.CreateInstance(user.Gender.ToString());
                gender.DOB = user.DOB;
                gender.Name = user.Name;
                var premium = await premiumRepository.CalculatePremiumAsync(gender);
                return RedirectToAction("EligiblePremium", new { premiumValue = premium, name = user.Name });
            }
            catch (Exception)
            {

                // log something over here
                // throw the user friendly error.
            }

            return View(nameof(Index));

        }


        public IActionResult EligiblePremium(double premiumValue, string name)
        {
            var premiumEligibility = new PremiumEligibility();

            if (premiumValue == 0)
            {
                // This could be extracted from the CMS
                premiumEligibility.EligiblityPremiumMessage = "You are not eligible for the Premium";
            }
            else
            {
                // this should be extracted out of CMS.
                premiumEligibility.EligiblityPremiumMessage = String.Format("Congratulations! {0}, You are eligible for a Premium of {1}.", name, premiumValue.ToString("C0"));
            }
            return View(premiumEligibility);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
