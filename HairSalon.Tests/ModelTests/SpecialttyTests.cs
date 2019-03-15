using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;

namespace HairSalon.TestTools
{
  [TestClass]
  public class SpecialtyTest : IDisposable
  {
    public void Dispose()
    {
      Stylist.ClearAll();
      Client.ClearAll();
      Stylist.ClearJoinTable();
      Specialty.ClearAll();
      Specialty.ClearJoinTable();
    }

    public SpecialtyTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=jared_hanson_test;";
    }
    [TestMethod]
    public void SpecialtyConstructor()
    {
      Specialty newSpecialty = new Specialty("specialty");
      Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
    }

    [TestMethod]
    public void GetDescription()
    {
      Specialty newSpecialty = new Specialty("specialty");
      newSpecialty.Save();
      string result = newSpecialty.GetDescription();
      Assert.AreEqual("specialty", result);
    }

    [TestMethod]
    public void GetAll_List()
    {
      Specialty newSpecialty = new Specialty("specialty");
      newSpecialty.Save();
      int result = Specialty.GetAll().Count;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetStylists()
    {
      Specialty newSpecialty = new Specialty("specialty");
      newSpecialty.Save();
      List<Stylist> newStylistList = new List<Stylist> {};
      List<Stylist> result = newSpecialty.GetStylists();
      CollectionAssert.AreEqual(newStylistList, result);
    }

    [TestMethod]
    public void AddStylist()
    {
      Specialty newSpecialty = new Specialty("specialty");
      newSpecialty.Save();
      Stylist newStylist = new Stylist("stylist1", "detail1");
      newStylist.Save();
      newSpecialty.AddStylist(newStylist);
      List<Stylist> result = newSpecialty.GetStylists();
      List<Stylist> test = new List<Stylist> {newStylist};
      CollectionAssert.AreEqual(test, result);
    }

    [TestMethod]
    public void Find_Specialty()
    {
      Specialty newSpecialty = new Specialty("specialty");
      newSpecialty.Save();
      Specialty foundSpecialty = Specialty.Find(newSpecialty.GetId());
      Assert.AreEqual(newSpecialty, foundSpecialty);
    }

    [TestMethod]
    public void DeleteSpecialty_List()
    {
      Specialty newSpecialty = new Specialty("specialty");
      newSpecialty.Save();
      newSpecialty.DeleteSpecialty(newSpecialty.GetId());
      List<Specialty> test = new List<Specialty> {};
      List<Specialty> result = Specialty.GetAll();
      CollectionAssert.AreEqual(test, result);
    }
  }
}
