using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.TestTools
{
  [TestClass]
  public class StylistTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
      Stylist.ClearJoinTable();
      Specialty.ClearAll();
      Specialty.ClearJoinTable();
    }

    public StylistTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jared_hanson_test;";
    }

    [TestMethod]
    public void StylistConstructor()
    {
      Stylist newStylist = new Stylist("stylist1", "detail1", 1);
      Assert.AreEqual(typeof(Stylist), newStylist.GetType());
    }

    [TestMethod]
    public void GetAll_List()
    {
      Stylist newStylist = new Stylist("stylist1", "detail1");
      newStylist.Save();
      int result = Stylist.GetAll().Count;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetId()
    {
      Stylist newStylist = new Stylist("stylist1", "detail1");
      int result = newStylist.GetId();
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Save_Id()
    {
      Stylist newStylist = new Stylist("stylist1", "detail1");
      newStylist.Save();
      Stylist savedStylist = Stylist.GetAll()[0];
      int result = savedStylist.GetId();
      int testId = newStylist.GetId();
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Equals_Stylist()
    {
      Stylist firstStylist = new Stylist("stylist1", "detail1");
      Stylist secondStylist = new Stylist("stylist1", "detail1");
      Assert.AreEqual(firstStylist, secondStylist);
    }

    [TestMethod]
    public void GetName()
    {
      Stylist newStylist = new Stylist("stylist1", "detail1");
      newStylist.Save();
      string result = newStylist.GetName();
      Assert.AreEqual("stylist1", result);
    }

    [TestMethod]
    public void GetClients()
    {
      Stylist newStylist = new Stylist("stylist1", "detail1");
      newStylist.Save();
      Client newClient = new Client("client1", 1, "note1");
      newClient.Save();
      newStylist.AddClient(newClient);
      List<Client> newClientList = new List<Client> {newClient};
      List<Client> result = newStylist.GetClients();
      CollectionAssert.AreEqual(newClientList, result);
    }

    [TestMethod]
    public void Find_Stylist()
    {
      Stylist newStylist = new Stylist("stylist1", "detail1");
      newStylist.Save();
      Stylist foundStylist = Stylist.Find(newStylist.GetId());
      Assert.AreEqual(newStylist, foundStylist);
    }

    [TestMethod]
    public void AddSpecialty()
    {
      Stylist newStylist = new Stylist("stylist1", "detail1");
      newStylist.Save();
      Specialty newSpecialty = new Specialty("specialty");
      newSpecialty.Save();
      newStylist.AddSpecialty(newSpecialty);
      List<Specialty> test = new List<Specialty> {newSpecialty};
      List<Specialty> result = newStylist.GetSpecialties();
      CollectionAssert.AreEqual(test, result);
    }

    [TestMethod]
    public void GetSpecialties()
    {
      Stylist newStylist = new Stylist("stylist1", "detail1");
      newStylist.Save();
      Specialty newSpecialty = new Specialty("specialty");
      newSpecialty.Save();
      newStylist.AddSpecialty(newSpecialty);
      List<Specialty> result = new List<Specialty> {newSpecialty};
      List<Specialty> test = newStylist.GetSpecialties();
      CollectionAssert.AreEqual(test, result);
    }

    [TestMethod]
    public void Edit()
    {
      Stylist testStylist = new Stylist("stylist1", "detail1");
      Stylist result = new Stylist("stylist2", "detail2");
      result.Save();
      result.Edit("stylist1", "detail1");
      testStylist.Save();
      Assert.AreEqual(testStylist.GetName(), result.GetName());
    }
    [TestMethod]
    public void AddClient()
    {
      Client newClient = new Client("client1", 1, "note1");
      newClient.Save();
      List<Client> test = new List<Client> { newClient };
      Stylist newStylist = new Stylist("stylist1", "detail1");
      newStylist.Save();
      newStylist.AddClient(newClient);
      List<Client> result = newStylist.GetClients();
      CollectionAssert.AreEqual(test, result);
    }
  }
}
