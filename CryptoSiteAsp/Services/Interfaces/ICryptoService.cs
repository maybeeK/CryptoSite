﻿using CryptoSiteAsp.Entities;

namespace CryptoSiteAsp.Services.Interfaces
{
    public interface ICryptoService
    {
        public Task<IEnumerable<CryptoCurrencyCoin>> GetTopNCurrency(int amount);
        public Task<CryptoCurrencyCoin> GetCurrencyByName(string name);
    }
}
