using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using BCrypt.Net;


/// <summary>
/// Dit is de class voor <c>AccountsLogic</c>.
/// <remarks>
/// <example>
/// <code>
///     AccountsLogic accountsLogic = new AccountsLogic();
/// </code>
/// </example>
/// </remarks>
/// </summary>
class AccountsLogic
{
    private List<AccountModel> _accounts;

    public static AccountModel? CurrentAccount { get; set; } = null;

    public AccountsLogic()
    {
        _accounts = AccountsAccess.LoadAll();
    }

    // Nieuw account object wordt aangemaakt en het wachtwoord wordt ook meteen gehashed en opgeslagen
    public void NewAccount(string fullName, string email, string password)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, workFactor: 10);
        int id = _accounts.Count();
        AccountModel acc = new AccountModel(++id, email, passwordHash, fullName, "Customer");
        UpdateList(acc);
    }
    public void UpdateList(AccountModel acc)
    {
        //Find if there is already an model with the same id
        int index = _accounts.FindIndex(s => s.Id == acc.Id);

        if (index != -1)
        {
            //update existing model
            _accounts[index] = acc;
        }
        else
        {
            //add new model
            _accounts.Add(acc);
        }
        AccountsAccess.WriteAll(_accounts);
    }

    /// <summary>
    /// <c>Account</c> wordt opgehaald op basis van het id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>AccountModel</returns>
    /// <example>
    /// <code>
    ///    AccountModel account = accountsLogic.GetById(1);
    /// </code>
    /// </example>
    public AccountModel GetById(int id)
    {
        return _accounts.Find(i => i.Id == id);
    }

    // Login wordt gecheckt op emailadres en wachtwoord
    public AccountModel CheckLogin(string email, string password)
    {
        if (email == null || password == null)
        {
            return null;
        }
        CurrentAccount = _accounts.Find(i => i.EmailAddress == email);
        if (CurrentAccount == null)
        {
            return null;
        }
        bool result = BCrypt.Net.BCrypt.Verify(password, CurrentAccount.Password);
        if (result)
            return CurrentAccount;
        return null;
    }
    //Hoi
}