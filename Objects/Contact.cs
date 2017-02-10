using System;
using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private string _name;
    private string _phone;
    private string _address;
    private int _id;

    private static List<Contact> _contacts = new List<Contact>{};

    public Contact(string name, string phone, string address)
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

    public string GetAddress()
    {
      return _address;
    }

    public void SetAddress(string newAddress)
    {
      _address = newAddress;
    }

    public int GetId()
    {
      return _id;
    }

    public static List<Contact> GetAll()
    {
      return _contacts;
    }

    public static void ClearAll()
    {
      _contacts.Clear();
    }

    public static Contact FindContact(int SearchId)
    {
      Console.WriteLine(SearchId);
      Console.WriteLine(_contacts);
      return _contacts[SearchId-1];
    }
  }
}
