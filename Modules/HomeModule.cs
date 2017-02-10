using System;
using System.Collections.Generic;
using Nancy;
using AddressBook.Objects;

namespace AddressBook
{
  public class HomeModule: NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
      List<Contact> allContacts = new List<Contact>{};
      if (Contact.GetAll() != null){
        allContacts = Contact.GetAll();
      }
      return View["index.cshtml", allContacts];
      };
      Get["/contact_add_form"] = _ => View["contact_add_form.cshtml"];
      Post["/contact/new"] = _ =>{
        Dictionary<string, object> model = new Dictionary<string, object>();
        string newName = Request.Form["new-name"];
        string newPhone = Request.Form["new-phone"];
        string newStreet = Request.Form["new-street"];
        string newCity = Request.Form["new-city"];
        string newState = Request.Form["new-state"];
        int newZip = Request.Form["new-zipcode"];
        Address newAddress = new Address(newStreet, newCity, newState, newZip);
        Contact newContact = new Contact(newName, newPhone, newAddress);
        model.Add("address", newAddress);
        model.Add("contact", newContact);
        return View["contact_new.cshtml", model];
      };
      Get["/contact/{id}/info"] = parameter => {
        Contact contactInfo = Contact.FindContact(parameter.id);
        Address addressInfo = contactInfo.GetAddress();
        Dictionary<string, object> model = new Dictionary<string, object>();
        model.Add("address", addressInfo);
        model.Add("contact", contactInfo);
        return View["contact_individual.cshtml", model];
      };
      Post["/contacts/clear"] = _ => {
        Contact.ClearAll();
        return View["contacts_cleared.cshtml"];
      };
      Post["/contacts/{id}/deleted"] = parameter => {
        Contact.RemoveContact(parameter.id);
        List<Contact> allContacts = new List<Contact>{};
        if (Contact.GetAll() != null){
          allContacts = Contact.GetAll();
        }
        return View["contact_deleted.cshtml", allContacts];
      };
    }
  }
}
