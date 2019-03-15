using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.TestTools
{
  [TestClass]
  public class ClientTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
      Client.ClearJoinTable();
    }

    public ClientTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jared_hanson_test;";
    }

    [TestMethod]
    public void ClientConstructor()
    {
      Client newClient = new Client("client1", 1, "note1");
      Assert.AreEqual(typeof(Client), newClient.GetType());
    }

    [TestMethod]
    public void GetName()
    {
      Client newClient = new Client("client1", 1, "note1");
      newClient.Save();
      string result = newClient.GetName();
      Assert.AreEqual("client1", result);
    }

    [TestMethod]
    public void SetName()
    {
      Client newClient = new Client("client1", 1, "note1");
      newClient.Save();
      newClient.SetName("client2");
      string result = newClient.GetName();
      Assert.AreEqual("client2", result);
    }

    [TestMethod]
    public void Equals_Client()
    {
      Client firstClient = new Client("client1", 1, "note1");
      Client secondClient = new Client("client1", 1, "note1");
      Assert.AreEqual(firstClient, secondClient);
    }

    [TestMethod]
    public void GetAll_List()
    {
      Client newClient = new Client("client1", 1, "note1");
      newClient.Save();
      int result = Client.GetAll().Count;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Save_Id()
    {
      Client newClient = new Client("client1", 1, "note1");
      newClient.Save();
      Client savedClient = Client.GetAll()[0];
      int result = savedClient.GetId();
      int testId = newClient.GetId();
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find()
    {
      Client newClient = new Client("client1", 1, "note1");
      newClient.Save();
      Client foundClient = Client.Find(newClient.GetId());
      Assert.AreEqual(newClient, foundClient);
    }

    [TestMethod]
    public void Edit()
    {
      Client testClient = new Client("client1", 1, "note1");
      testClient.Save();
      testClient.Edit("client2", 2, "note2");
      string result = Client.Find(testClient.GetId()).GetName();
      Assert.AreEqual("client2", result);
    }

    [TestMethod]
    public void GetStylists()
    {
      Stylist newStylist = new Stylist("stylist1", "detail1");
      newStylist.Save();
      Client newClient = new Client("client1", 1, "note1");
      newClient.Save();
      newStylist.AddClient(newClient);
      List<Stylist> test = new List<Stylist> {newStylist};
      List<Stylist> results = newClient.GetStylists();
      CollectionAssert.AreEqual(test, results);
    }

    [TestMethod]
    public void DeleteClient()
    {
      Client newClient = new Client("client1", 1, "note1");
      newClient.Save();
      List<Client> test = new List<Client> {};
      newClient.DeleteClient(newClient.GetId());
      List<Client> result = Client.GetAll();
      CollectionAssert.AreEqual(test, result);
    }

    [TestMethod]
    public void AddStylist()
    {
      Client newClient = new Client("client1", 1, "note1");
      newClient.Save();
      Stylist newStylist = new Stylist("stylist1", "detail1");
      newStylist.Save();
      newClient.AddStylist(newStylist);
      List<Stylist> result = newClient.GetStylists();
      List<Stylist> test = new List<Stylist> {newStylist};
      CollectionAssert.AreEqual(test, result);
    }
  }
}
