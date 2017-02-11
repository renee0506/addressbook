using System;
using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private string _name;
    private string _phone;
    private Address _address;
    private int _id;

    private static List<Contact> _contacts = new List<Contact>{};

    public Contact(string name, string phone, Address address)
    {
      _name = name;
      _phone = phone;
      _address = address;
      _contacts.Add(this);
      _id = _contacts.Count;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public string GetPhone()
    {
      return _phone;
    }

    public void SetPhone(string newPhone)
    {
      _phone = newPhone;
    }

    public Address GetAddress()
    {
      return _address;
    }

    public void SetAddress(Address newAddress)
    {
      _address = newAddress;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetId(int newId)
    {
      _id = newId;
    }

    public static List<Contact> GetAll()
    {
      return _contacts;
    }

    public static void ClearAll()
    {
      _contacts.Clear();
    }

    public static Contact FindContact(int searchId)
    {
      return _contacts[searchId-1];
    }

    public static void RemoveContact(int searchId)
    {
      _contacts.RemoveAt(searchId-1);
      //reset id
      foreach (Contact person in _contacts)
      {
        person.SetId(_contacts.IndexOf(person)+1);
      }
    }

    public static List<Contact> SearchContactByName(string input)
    {
      List<Contact> Results = new List<Contact>{};
      foreach (Contact person in _contacts)
      {
         if (person.GetName().ToLower().Contains(input.ToLower())){
           Results.Add(person);
         }
      }
      return Results;
    }

    // public static List<Contact> SearchContactByFirst(string letter)
    // {
    //   List<Contact> Results = new List<Contact>{};
    //   foreach (Contact person in _contacts)
    //   {
    //     string name = person.GetName().ToUpper();
    //      if (name.ToCharArray()[0] == letter){
    //        Results.Add(person);
    //      }
    //   }
    //   return Results;
    // }
  }
}
