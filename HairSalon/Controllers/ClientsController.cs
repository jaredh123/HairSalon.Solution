using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    [HttpPost("/clients")]
    public ActionResult Create(string name, int phone, string notes)
    {
      Client newClient = new Client(name, phone, notes);
      newClient.Save();
      List<Client> allClients = Client.GetAll();
      return View("Index", allClients);
    }

    [HttpGet("/clients")]
    public ActionResult Index()
    {
      List<Client> allClients = Client.GetAll();
      return View(allClients);
    }

    [HttpGet("/clients/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/clients/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Client selectedClient = Client.Find(id);
      List<Stylist> clientStylists = selectedClient.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("selectedClient", selectedClient);
      model.Add("clientStylists", clientStylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }

    [HttpGet("/clients/{clientId}/edit")]
    public ActionResult Edit(int clientId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Client client = Client.Find(clientId);
      model.Add("client", client);
      return View(model);
    }

    [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
    public ActionResult Edit(int stylistId, int clientId)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylist = Stylist.Find(stylistId);
      Client client = Client.Find(clientId);
      model.Add("stylist", stylist);
      model.Add("client", client);
      return View(model);
    }

    [HttpPost("/clients/{clientId}")]
    public ActionResult Update(int clientId, string newName, int newPhone, string newNotes)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Client selectedClient = Client.Find(clientId);
      selectedClient.Edit(newName, newPhone, newNotes);
      List<Stylist> clientStylists = selectedClient.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("selectedClient", selectedClient);
      model.Add("clientStylists", clientStylists);
      model.Add("allStylists", allStylists);
      return View("Show", model);
    }

    [HttpPost("/clients/{clientId}/stylists/new")]
    public ActionResult AddStylist(int clientId, int stylistId)
    {
      Client client = Client.Find(clientId);
      Stylist stylist = Stylist.Find(stylistId);
      client.AddStylist(stylist);
      return RedirectToAction("Show", new { id = clientId });
    }

    [HttpPost("/clients/{id}/delete")]
    public ActionResult DeleteClient(int id)
    {
      Client selectedClient = Client.Find(id);
      selectedClient.DeleteClient(id);
      List<Client> allClients = Client.GetAll();
      return RedirectToAction("Index", allClients);
    }

    [HttpPost("/clients/delete")]
    public ActionResult DeleteAll()
    {
      Client.ClearAll();
      List<Client> allClients = Client.GetAll();
      return View("Index", allClients);
    }
  }
}
