using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientsControllerTest
  {
    [TestMethod]
    public void Index()
    {
      ClientsController controller = new ClientsController();
      ActionResult indexView = controller.Index();
      Assert.IsInstanceOfType(indexView, typeof(ViewResult));
    }

    [TestMethod]
    public void New()
    {
      ClientsController controller = new ClientsController();
      ActionResult newView = controller.New();
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }

    [TestMethod]
    public void Show_Dictionary()
    {
      ClientsController controller = new ClientsController();
      ViewResult showView = controller.Show(0) as ViewResult;
      var result = showView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void Edit_Dictionary()
    {
      ClientsController controller = new ClientsController();
      ViewResult editView = controller.Edit(0,0) as ViewResult;
      var result = editView.ViewData.Model;
      Assert.IsInstanceOfType(result, typeof(Dictionary<string, object>));
    }

    [TestMethod]
    public void DeleteClient_Index()
    {
      ClientsController controller = new ClientsController();
      RedirectToActionResult actionResult = controller.DeleteClient(0) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual("Index", result);
    }

    [TestMethod]
    public void AddStylist_Show()
    {
      ClientsController controller = new ClientsController();
      RedirectToActionResult actionResult = controller.AddStylist(0, 0) as RedirectToActionResult;
      string result = actionResult.ActionName;
      Assert.AreEqual("Show", result);
    }

    [TestMethod]
    public void DeleteAll()
    {
      ClientsController controller = new ClientsController();
      ActionResult newView = controller.DeleteAll();
      Assert.IsInstanceOfType(newView, typeof(ViewResult));
    }
  }
}
