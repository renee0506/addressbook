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
        string newName = Request.Form["new-name"];
        string newPhone = Request.Form["new-phone"];
        string newAddress = Request.Form["new-address"];
        Contact newContact = new Contact(newName, newPhone, newAddress);
        return View["contact_new.cshtml", newContact];
      };
      Get["/contact/{id}/info"] = parameter => {
        Contact contactInfo = Contact.FindContact(parameter.id);
        return View["contact_individual.cshtml", contactInfo];
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
        return View["index.cshtml", allContacts];
      };
    }
  }
}
