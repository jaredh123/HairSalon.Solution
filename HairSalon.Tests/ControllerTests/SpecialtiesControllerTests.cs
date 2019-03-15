using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class SpecialtiesControllerTest
  {
    [TestMethod]
    public void Index()
    {
      SpecialtiesController controller = new SpecialtiesController();
      ActionResult indexView = controller.Index();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void Create()
    {
      SpecialtiesController controller = new SpecialtiesController();
      ActionResult newView = controller.Create("string");
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Create_Dictionary()
    {
      SpecialtiesController controller = new SpecialtiesController();
      ViewResult showView = controller.Create("string") as ViewResult;
      var result = showView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(List<Specialty>));
    }

    [TestMethod]
    public void Show_Dictionary()
    {
      SpecialtiesController controller = new SpecialtiesController();
      ViewResult showView = controller.Show(0) as ViewResult;
      var result = showView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void DeleteSpecialty_Index()
    {
      SpecialtiesController controller = new SpecialtiesController();
      RedirectToActionResult actionResult = controller.DeleteSpecialty(0) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual("Index", result);
    }

    [TestMethod]
    public void AddStylists_Show()
    {
      SpecialtiesController controller = new SpecialtiesController();
      RedirectToActionResult actionResult = controller.AddStylist(0, 0) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual("Show", result);
    }

    [TestMethod]
    public void DeleteAll()
    {
      SpecialtiesController controller = new SpecialtiesController();
      ActionResult newView = controller.DeleteAll();
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }
  }
}
